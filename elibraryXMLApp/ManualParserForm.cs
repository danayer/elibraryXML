using elibraryXMLApp.Models;
using elibraryXMLApp.Services;
using System.Text.RegularExpressions;

namespace elibraryXMLApp;

public partial class ManualParserForm : Form
{
    private static readonly Regex CyrillicRegex = new Regex(@"\p{IsCyrillic}", RegexOptions.Compiled);
    // Regex to match emoji characters - covers most common emoji ranges
    // Fixed: Removed problematic character class ranges that were matching regular text
    private static readonly Regex EmojiRegex = new Regex(
        @"[\u2600-\u26FF]|[\u2700-\u27BF]|" +
        @"[\u231A-\u231B]|[\u23E9-\u23F3]|[\u23F8-\u23FA]|" +
        @"[\u25AA-\u25AB]|[\u25B6]|[\u25C0]|[\u25FB-\u25FE]|" +
        @"[\u2614-\u2615]|[\u2648-\u2653]|[\u267F]|[\u2693]|" +
        @"[\u26A1]|[\u26AA-\u26AB]|[\u26BD-\u26BE]|" +
        @"[\u26C4-\u26C5]|[\u26CE]|[\u26D4]|[\u26EA]|" +
        @"[\u26F2-\u26F3]|[\u26F5]|[\u26FA]|[\u26FD]|" +
        @"[\u2705]|[\u270A-\u270B]|[\u2728]|[\u274C]|[\u274E]|" +
        @"[\u2753-\u2755]|[\u2757]|[\u2795-\u2797]|[\u27B0]|[\u27BF]|" +
        @"[\u2B1B-\u2B1C]|[\u2B50]|[\u2B55]|" +
        @"[\uD83C][\uDC00-\uDFFF]|" +
        @"[\uD83D][\uDC00-\uDFFF]|" +
        @"[\uD83E][\uDD00-\uDDFF]",
        RegexOptions.Compiled);
    
    private readonly ITextParsingService parsingService;
    public ParsedArticleData? ParsedData { get; private set; }
    public List<ParsedArticleData> ParsedArticles { get; private set; }
    private TextBox? activeField;
    private Stack<FieldChange> undoStack;
    private Stack<FieldChange> redoStack;
    private string? currentHtmlPath;
    private int? currentEditingIndex = null;
    private List<FileUrlEntry> fileUrlEntries = new List<FileUrlEntry>();
    private int editingEntryIndex = -1; // Index of entry being edited, -1 if adding new

    public ManualParserForm(ITextParsingService parsingService)
    {
        InitializeComponent();
        this.parsingService = parsingService;
        ParsedArticles = new List<ParsedArticleData>();
        undoStack = new Stack<FieldChange>();
        redoStack = new Stack<FieldChange>();
        UpdateUndoRedoButtons();
        UpdateArticlesList();
    }

    private async void ManualParserForm_Load(object? sender, EventArgs e)
    {
        try
        {
            await webView.EnsureCoreWebView2Async(null);
            
            // Set up event handler for text selection
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка инициализации WebView2: {ex.Message}\n\nWebView2 Runtime может быть не установлен.", 
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnLoadDocument_Click(object? sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm|All Files (*.*)|*.*";
            openFileDialog.Title = "Выберите HTML документ / Select HTML Document";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentHtmlPath = openFileDialog.FileName;
                    // Use file:// protocol for local files
                    webView.CoreWebView2.Navigate($"file:///{currentHtmlPath.Replace("\\", "/")}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки документа: {ex.Message}", 
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void txtField_Click(object? sender, EventArgs e)
    {
        if (sender is TextBox textBox)
        {
            activeField = textBox;
            
            // Highlight the active field across all tabs
            HighlightActiveField(tabBasic);
            HighlightActiveField(tabContent);
            HighlightActiveField(tabCodes);
            HighlightActiveField(tabAuthors);
            HighlightActiveField(tabDates);
            HighlightActiveField(tabAdditional);

            // Get selected text from WebView2
            if (webView.CoreWebView2 != null)
            {
                try
                {
                    string script = "window.getSelection().toString();";
                    string selectedText = await webView.CoreWebView2.ExecuteScriptAsync(script);
                    
                    // Remove quotes from JSON string
                    if (selectedText.Length >= 2 && selectedText.StartsWith("\"") && selectedText.EndsWith("\""))
                    {
                        selectedText = selectedText.Substring(1, selectedText.Length - 2);
                    }
                    
                    // Unescape special characters
                    selectedText = System.Text.RegularExpressions.Regex.Unescape(selectedText);
                    
                    // Remove emojis from selected text
                    selectedText = StripEmojis(selectedText);

                    if (!string.IsNullOrWhiteSpace(selectedText))
                    {
                        // Save the old value for undo
                        SaveFieldChange(textBox, textBox.Text, selectedText);
                        
                        // Transfer the selected text to the field
                        if (textBox.Multiline && !string.IsNullOrEmpty(textBox.Text))
                        {
                            // For multiline fields, append with a separator
                            textBox.Text += (textBox.Text.EndsWith("\n") ? "" : "\n") + selectedText.Trim();
                        }
                        else
                        {
                            textBox.Text = selectedText.Trim();
                        }
                        
                        // Clear the HTML selection to prevent it from being reused on next click
                        await webView.CoreWebView2.ExecuteScriptAsync("window.getSelection().removeAllRanges();");
                        
                        // Clear redo stack when a new change is made
                        redoStack.Clear();
                        UpdateUndoRedoButtons();
                    }
                }
                catch (Exception)
                {
                    // Silently ignore errors - might happen if no text is selected
                }
            }
        }
    }

    private void HighlightActiveField(TabPage tab)
    {
        foreach (Control control in tab.Controls)
        {
            if (control is TextBox tb)
            {
                tb.BackColor = (tb == activeField) ? Color.LightYellow : Color.White;
            }
        }
    }

    private void WebView_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
    {
        // This can be used for more complex interactions if needed
    }

    private void btnAddArticle_Click(object? sender, EventArgs e)
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtTitleEng.Text))
        {
            MessageBox.Show("Пожалуйста, укажите название статьи / Please enter article title", 
                "Ошибка / Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Create article data from fields
        var articleData = CreateArticleDataFromFields();

        // Validate that article has at least one title after stripping
        if (articleData.Titles.Count == 0)
        {
            MessageBox.Show("Название статьи не может состоять только из эмодзи или специальных символов.\n" +
                          "Пожалуйста, введите текстовое название.\n\n" +
                          "Article title cannot consist only of emojis or special characters.\n" +
                          "Please enter a text title.", 
                "Ошибка / Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Add to the list or update existing
        if (currentEditingIndex.HasValue && currentEditingIndex.Value >= 0 && currentEditingIndex.Value < ParsedArticles.Count)
        {
            // Update existing article
            ParsedArticles[currentEditingIndex.Value] = articleData;
            MessageBox.Show($"Статья обновлена!\nArticle updated!", 
                "Успех / Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            // Add new article
            ParsedArticles.Add(articleData);
            MessageBox.Show($"Статья добавлена! Всего статей: {ParsedArticles.Count}\nArticle added! Total articles: {ParsedArticles.Count}", 
                "Успех / Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        UpdateArticlesList();
        
        // Clear fields for next article
        ClearFields();
    }

    private void btnDone_Click(object? sender, EventArgs e)
    {
        if (ParsedArticles.Count == 0)
        {
            MessageBox.Show("Добавьте хотя бы одну статью / Add at least one article", 
                "Предупреждение / Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnClearFields_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Очистить все поля? / Clear all fields?", 
            "Подтверждение / Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            ClearFields();
        }
    }

    private void btnDeleteArticle_Click(object? sender, EventArgs e)
    {
        if (lstArticles.SelectedIndex >= 0 && lstArticles.SelectedIndex < ParsedArticles.Count)
        {
            if (MessageBox.Show("Удалить выбранную статью? / Delete selected article?", 
                "Подтверждение / Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int deletedIndex = lstArticles.SelectedIndex;
                ParsedArticles.RemoveAt(deletedIndex);
                
                // If we were editing the deleted article, clear fields
                if (currentEditingIndex.HasValue && currentEditingIndex.Value == deletedIndex)
                {
                    ClearFields();
                }
                // If we were editing an article after the deleted one, adjust the index
                else if (currentEditingIndex.HasValue && currentEditingIndex.Value > deletedIndex)
                {
                    currentEditingIndex = currentEditingIndex.Value - 1;
                }
                
                UpdateArticlesList();
            }
        }
        else
        {
            MessageBox.Show("Выберите статью для удаления / Select an article to delete", 
                "Ошибка / Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ClearFields()
    {
        // Clear all text fields
        txtTitle.Clear();
        txtTitleEng.Clear();
        txtAuthors.Clear();
        txtDoi.Clear();
        txtPages.Clear();
        txtYear.Clear();
        txtEmail.Clear();
        txtKeywords.Clear();
        txtKeywordsEng.Clear();
        txtAbstract.Clear();
        txtAbstractEng.Clear();
        txtTextContent.Clear();
        txtLangPubl.Clear();
        txtEdn.Clear();
        txtUdk.Clear();
        txtBbk.Clear();
        txtVak.Clear();
        txtJel.Clear();
        txtMsc.Clear();
        txtPacs.Clear();
        txtArtType.Clear();
        txtOrcid.Clear();
        txtSpin.Clear();
        txtScopusId.Clear();
        txtResearcherId.Clear();
        txtOrgName.Clear();
        txtDateReceived.Clear();
        txtDateAccepted.Clear();
        txtDatePublication.Clear();
        txtFundings.Clear();
        txtRubrics.Clear();
        txtReferences.Clear();
        
        // Clear file/URL entries
        fileUrlEntries.Clear();
        RefreshFileUrlList();
        
        // Clear undo/redo stacks
        undoStack.Clear();
        redoStack.Clear();
        UpdateUndoRedoButtons();
        
        // Reset editing index
        currentEditingIndex = null;
        UpdateButtonText();
    }

    private void UpdateArticlesList()
    {
        lstArticles.Items.Clear();
        for (int i = 0; i < ParsedArticles.Count; i++)
        {
            var article = ParsedArticles[i];
            string title = article.Titles.FirstOrDefault() ?? "(без названия / no title)";
            if (title.Length > 60)
                title = title[..57] + "...";
            
            // Highlight the currently edited article for better accessibility
            string prefix = (currentEditingIndex.HasValue && currentEditingIndex.Value == i) ? "[Редактируется] " : "";
            lstArticles.Items.Add($"{prefix}{i + 1}. {title}");
        }
        
        btnDeleteArticle.Enabled = lstArticles.Items.Count > 0;
        btnDone.Enabled = lstArticles.Items.Count > 0;
    }

    private void LoadArticleIntoFields(int index)
    {
        if (index < 0 || index >= ParsedArticles.Count)
            return;

        currentEditingIndex = index;
        var article = ParsedArticles[index];

        // Load titles
        txtTitle.Text = article.Titles.Count > 0 ? article.Titles[0] : "";
        txtTitleEng.Text = article.Titles.Count > 1 ? article.Titles[1] : "";

        // Load authors
        txtAuthors.Text = string.Join("\n", article.Authors);

        // Load basic fields
        txtDoi.Text = article.Doi ?? "";
        txtPages.Text = article.Pages ?? "";
        txtYear.Text = article.Year.HasValue ? article.Year.Value.ToString() : "";
        txtEmail.Text = string.Join(", ", article.Emails);
        txtLangPubl.Text = article.LangPubl ?? "";
        txtArtType.Text = article.ArtType ?? "";

        // Load keywords
        var russianKeywords = new List<string>();
        var englishKeywords = new List<string>();
        foreach (var keyword in article.Keywords)
        {
            // Simple heuristic: if keyword contains Cyrillic characters, it's Russian
            if (CyrillicRegex.IsMatch(keyword))
                russianKeywords.Add(keyword);
            else
                englishKeywords.Add(keyword);
        }
        txtKeywords.Text = string.Join(", ", russianKeywords);
        txtKeywordsEng.Text = string.Join(", ", englishKeywords);

        // Load abstracts (ParsedArticleData stores abstracts in a single field)
        txtAbstract.Text = article.Abstract ?? "";
        txtAbstractEng.Text = "";

        // Load text content
        txtTextContent.Text = article.TextContent ?? "";

        // Load codes
        txtEdn.Text = article.Edn ?? "";
        txtUdk.Text = article.Udk ?? "";
        txtBbk.Text = article.Bbk ?? "";
        txtVak.Text = article.Vak ?? "";
        txtJel.Text = article.Jel ?? "";
        txtMsc.Text = article.Msc ?? "";
        txtPacs.Text = article.Pacs ?? "";

        // Load author codes
        txtOrcid.Text = article.Orcid ?? "";
        txtSpin.Text = article.Spin ?? "";
        txtScopusId.Text = article.ScopusId ?? "";
        txtResearcherId.Text = article.ResearcherId ?? "";

        // Load organization
        txtOrgName.Text = article.OrgName ?? "";

        // Load dates
        txtDateReceived.Text = article.DateReceived ?? "";
        txtDateAccepted.Text = article.DateAccepted ?? "";
        txtDatePublication.Text = article.DatePublication ?? "";

        // Load funding
        txtFundings.Text = string.Join("\n", article.Fundings);

        // Load rubrics
        txtRubrics.Text = string.Join(", ", article.Rubrics);

        // Load files/URLs into fileUrlEntries
        fileUrlEntries.Clear();
        
        // First add text content if it exists
        if (!string.IsNullOrWhiteSpace(article.TextContent))
        {
            fileUrlEntries.Add(new FileUrlEntry
            {
                Type = "text",
                Value = article.TextContent,
                Lang = article.LangPubl ?? "RUS"
            });
        }
        
        // Then add files and URLs
        foreach (var fileStr in article.Files)
        {
            if (string.IsNullOrWhiteSpace(fileStr))
                continue;
                
            var parts = fileStr.Split('|');
            var value = parts[0].Trim();
            
            if (string.IsNullOrWhiteSpace(value))
                continue;
            
            // Determine if it's a URL using Uri validation
            bool isUrl = Uri.TryCreate(value, UriKind.Absolute, out var uri) && 
                        (uri.Scheme == Uri.UriSchemeHttp || 
                         uri.Scheme == Uri.UriSchemeHttps || 
                         uri.Scheme == Uri.UriSchemeFtp);
            
            string? desc = parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]) ? parts[1].Trim() : null;
            string? lang = parts.Length > 2 && !string.IsNullOrWhiteSpace(parts[2]) ? parts[2].Trim() : null;
            
            fileUrlEntries.Add(new FileUrlEntry
            {
                Type = isUrl ? "url" : "file",
                Value = value,
                Desc = desc,
                Lang = lang
            });
        }
        
        RefreshFileUrlList();

        // Load references
        txtReferences.Text = string.Join("\n", article.References);

        UpdateButtonText();
        UpdateArticlesList();
    }

    private void UpdateButtonText()
    {
        if (currentEditingIndex.HasValue)
        {
            btnAddArticle.Text = "Обновить статью / Update Article";
        }
        else
        {
            btnAddArticle.Text = "Добавить статью / Add Article";
        }
    }

    private void lstArticles_DoubleClick(object? sender, EventArgs e)
    {
        if (lstArticles.SelectedIndex >= 0)
        {
            // Auto-save current article before switching
            AutoSaveCurrentArticle();
            
            LoadArticleIntoFields(lstArticles.SelectedIndex);
        }
    }

    private static List<string> SplitAndTrimText(string text, char[] separators)
    {
        var result = new List<string>();
        if (string.IsNullOrWhiteSpace(text))
            return result;

        var items = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in items)
        {
            if (!string.IsNullOrWhiteSpace(item))
                result.Add(item.Trim());
        }
        return result;
    }

    /// <summary>
    /// Split, trim, strip emojis, and filter out empty strings
    /// </summary>
    private List<string> SplitTrimAndStripEmojis(string text, char[] separators)
    {
        var items = SplitAndTrimText(text, separators);
        var result = new List<string>();
        foreach (var item in items)
        {
            string stripped = StripEmojis(item);
            if (!string.IsNullOrWhiteSpace(stripped))
                result.Add(stripped);
        }
        return result;
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void btnUndo_Click(object? sender, EventArgs e)
    {
        if (undoStack.Count > 0)
        {
            var change = undoStack.Pop();
            
            // Save current state to redo stack before undoing
            redoStack.Push(new FieldChange(change.Field, change.NewValue, change.OldValue));
            
            // Restore the old value
            change.Field.Text = change.OldValue;
            
            UpdateUndoRedoButtons();
        }
    }

    private void btnRedo_Click(object? sender, EventArgs e)
    {
        if (redoStack.Count > 0)
        {
            var change = redoStack.Pop();
            
            // Save current state to undo stack before redoing
            undoStack.Push(new FieldChange(change.Field, change.NewValue, change.OldValue));
            
            // Restore the new value
            change.Field.Text = change.NewValue;
            
            UpdateUndoRedoButtons();
        }
    }

    // Helper method to refresh the list of files/URLs
    private void RefreshFileUrlList()
    {
        lstFilesUrls.Items.Clear();
        foreach (var entry in fileUrlEntries)
        {
            lstFilesUrls.Items.Add(entry);
        }
    }
    
    // Helper method to get type code from dropdown text
    private string? GetTypeFromDropdownSelection(string selection)
    {
        if (selection == "(не указан)") return null;
        var parts = selection.Split(new[] { " - " }, StringSplitOptions.None);
        return parts.Length > 0 ? parts[0] : null;
    }
    
    // Add File button click handler
    private void btnAddFile_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFilePath.Text))
        {
            MessageBox.Show("Пожалуйста, введите путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var entry = new FileUrlEntry
        {
            Type = "file",
            Value = txtFilePath.Text,
            Desc = GetTypeFromDropdownSelection(cmbFileType.Text),
            Lang = cmbFileLang.SelectedIndex > 0 ? cmbFileLang.Text : null
        };
        
        if (editingEntryIndex >= 0)
        {
            fileUrlEntries[editingEntryIndex] = entry;
            editingEntryIndex = -1;
        }
        else
        {
            fileUrlEntries.Add(entry);
        }
        
        RefreshFileUrlList();
        
        // Clear form
        txtFilePath.Clear();
        cmbFileType.SelectedIndex = 0;
        cmbFileLang.SelectedIndex = 0;
    }
    
    // Add URL button click handler
    private void btnAddUrl_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUrlPath.Text))
        {
            MessageBox.Show("Пожалуйста, введите URL адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var entry = new FileUrlEntry
        {
            Type = "url",
            Value = txtUrlPath.Text,
            Desc = GetTypeFromDropdownSelection(cmbUrlType.Text),
            Lang = cmbUrlLang.SelectedIndex > 0 ? cmbUrlLang.Text : null
        };
        
        if (editingEntryIndex >= 0)
        {
            fileUrlEntries[editingEntryIndex] = entry;
            editingEntryIndex = -1;
        }
        else
        {
            fileUrlEntries.Add(entry);
        }
        
        RefreshFileUrlList();
        
        // Clear form
        txtUrlPath.Clear();
        cmbUrlType.SelectedIndex = 0;
        cmbUrlLang.SelectedIndex = 0;
    }
    
    // Set Article Text button click handler
    private void btnSetArticleText_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtArticleTextContent.Text))
        {
            MessageBox.Show("Пожалуйста, введите текст статьи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Remove existing article text entry if any
        fileUrlEntries.RemoveAll(entry => entry.Type == "text");
        
        var entry = new FileUrlEntry
        {
            Type = "text",
            Value = txtArticleTextContent.Text,
            Lang = cmbArticleTextLang.Text
        };
        
        fileUrlEntries.Insert(0, entry); // Add at the beginning
        
        RefreshFileUrlList();
        
        MessageBox.Show("Текст статьи установлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    // Edit File/URL button click handler
    private void btnEditFileUrl_Click(object? sender, EventArgs e)
    {
        if (lstFilesUrls.SelectedIndex < 0)
        {
            MessageBox.Show("Пожалуйста, выберите запись для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        editingEntryIndex = lstFilesUrls.SelectedIndex;
        var entry = fileUrlEntries[editingEntryIndex];
        
        if (entry.Type == "file")
        {
            tabControlFiles.SelectedIndex = 0; // File tab
            txtFilePath.Text = entry.Value;
            
            // Find and select the type
            for (int i = 0; i < cmbFileType.Items.Count; i++)
            {
                var itemText = cmbFileType.Items[i]?.ToString();
                if (itemText != null && GetTypeFromDropdownSelection(itemText) == entry.Desc)
                {
                    cmbFileType.SelectedIndex = i;
                    break;
                }
            }
            
            // Select language
            if (entry.Lang == "RUS") cmbFileLang.SelectedIndex = 1;
            else if (entry.Lang == "ENG") cmbFileLang.SelectedIndex = 2;
            else cmbFileLang.SelectedIndex = 0;
        }
        else if (entry.Type == "url")
        {
            tabControlFiles.SelectedIndex = 1; // URL tab
            txtUrlPath.Text = entry.Value;
            
            // Find and select the type
            for (int i = 0; i < cmbUrlType.Items.Count; i++)
            {
                var itemText = cmbUrlType.Items[i]?.ToString();
                if (itemText != null && GetTypeFromDropdownSelection(itemText) == entry.Desc)
                {
                    cmbUrlType.SelectedIndex = i;
                    break;
                }
            }
            
            // Select language
            if (entry.Lang == "RUS") cmbUrlLang.SelectedIndex = 1;
            else if (entry.Lang == "ENG") cmbUrlLang.SelectedIndex = 2;
            else cmbUrlLang.SelectedIndex = 0;
        }
        else if (entry.Type == "text")
        {
            tabControlFiles.SelectedIndex = 2; // Article Text tab
            txtArticleTextContent.Text = entry.Value;
            
            // Select language
            if (entry.Lang == "ENG") cmbArticleTextLang.SelectedIndex = 1;
            else cmbArticleTextLang.SelectedIndex = 0;
        }
    }
    
    // Remove File/URL button click handler
    private void btnRemoveFileUrl_Click(object? sender, EventArgs e)
    {
        if (lstFilesUrls.SelectedIndex < 0)
        {
            MessageBox.Show("Пожалуйста, выберите запись для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var result = MessageBox.Show(
            "Вы уверены, что хотите удалить эту запись?",
            "Подтверждение удаления",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
        {
            fileUrlEntries.RemoveAt(lstFilesUrls.SelectedIndex);
            RefreshFileUrlList();
        }
    }
    
    private void btnFilesHelp_Click(object? sender, EventArgs e)
    {
        var helpMessage = @"Управление файлами и URL / Files and URLs Management:

Используйте вкладки для добавления / Use tabs to add:
• Файлы (File) - Локальные файлы / Local files
• URL - Ссылки на внешние ресурсы / Links to external resources
• Текст статьи (Article Text) - Полный текст статьи / Full article text

Доступные типы (Type) / Available types:
• fullText - Полный текст / Full Text
• description - Описание / Description  
• preprint - Препринт / Preprint
• versionAnotherLanguage - Версия на другом языке
• anotherEdition - Другое издание
• continuation - Продолжение / Continuation
• beginning - Начало / Beginning
• application - Приложение / Application
• correction - Исправление / Correction
• addition - Дополнение / Addition
• review - Рецензия / Review
• comment - Комментарий / Comment
• mediaFile - Медиафайл / Media File
• presentation - Презентация / Presentation
• data - Данные / Data
• additionalMaterials - Доп. материалы / Additional Materials
• other - Другое / Other

Язык (Language):
• RUS - Русский
• ENG - English";

        MessageBox.Show(helpMessage, "Справка: Файлы и URL / Help: Files and URLs", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void SaveFieldChange(TextBox field, string oldValue, string newValue)
    {
        undoStack.Push(new FieldChange(field, oldValue, newValue));
    }

    private void UpdateUndoRedoButtons()
    {
        btnUndo.Enabled = undoStack.Count > 0;
        btnRedo.Enabled = redoStack.Count > 0;
    }
    
    /// <summary>
    /// Remove all emoji characters from the text
    /// </summary>
    private string StripEmojis(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        
        return EmojiRegex.Replace(text, "");
    }
    
    /// <summary>
    /// Create ParsedArticleData from current form fields with emoji stripping
    /// </summary>
    private ParsedArticleData CreateArticleDataFromFields()
    {
        // Create ParsedArticleData from the fields, stripping emojis from all text
        var articleData = new ParsedArticleData
        {
            Doi = StripEmojis(txtDoi.Text.Trim()),
            Pages = StripEmojis(txtPages.Text.Trim()),
            ArtType = string.IsNullOrWhiteSpace(txtArtType.Text) ? ParsedArticleData.DefaultArticleType : StripEmojis(txtArtType.Text.Trim()),
            LangPubl = StripEmojis(txtLangPubl.Text.Trim())
        };

        // Add titles (validate after emoji stripping)
        if (!string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            string strippedTitle = StripEmojis(txtTitle.Text.Trim());
            if (!string.IsNullOrWhiteSpace(strippedTitle))
                articleData.Titles.Add(strippedTitle);
        }
        if (!string.IsNullOrWhiteSpace(txtTitleEng.Text))
        {
            string strippedTitleEng = StripEmojis(txtTitleEng.Text.Trim());
            if (!string.IsNullOrWhiteSpace(strippedTitleEng))
                articleData.Titles.Add(strippedTitleEng);
        }

        // Add authors (with emoji stripping and empty string filtering)
        articleData.Authors = SplitTrimAndStripEmojis(txtAuthors.Text, new[] { '\n', '\r' });

        // Add emails (with emoji stripping and empty string filtering)
        articleData.Emails = SplitTrimAndStripEmojis(txtEmail.Text, new[] { ',', ';', '\n', '\r' });

        // Add keywords (with emoji stripping and empty string filtering)
        articleData.Keywords = SplitTrimAndStripEmojis(txtKeywords.Text, new[] { ',', ';', '\n', '\r' });
        articleData.Keywords.AddRange(SplitTrimAndStripEmojis(txtKeywordsEng.Text, new[] { ',', ';', '\n', '\r' }));

        // Add abstracts
        if (!string.IsNullOrWhiteSpace(txtAbstract.Text))
            articleData.Abstract = StripEmojis(txtAbstract.Text.Trim());
        else if (!string.IsNullOrWhiteSpace(txtAbstractEng.Text))
            articleData.Abstract = StripEmojis(txtAbstractEng.Text.Trim());

        // Parse year
        if (int.TryParse(txtYear.Text.Trim(), out int year))
            articleData.Year = year;

        // Additional codes
        articleData.Edn = StripEmojis(txtEdn.Text.Trim());
        articleData.Udk = StripEmojis(txtUdk.Text.Trim());
        articleData.Bbk = StripEmojis(txtBbk.Text.Trim());
        articleData.Vak = StripEmojis(txtVak.Text.Trim());
        articleData.Jel = StripEmojis(txtJel.Text.Trim());
        articleData.Msc = StripEmojis(txtMsc.Text.Trim());
        articleData.Pacs = StripEmojis(txtPacs.Text.Trim());

        // Author codes
        articleData.Orcid = StripEmojis(txtOrcid.Text.Trim());
        articleData.Spin = StripEmojis(txtSpin.Text.Trim());
        articleData.ScopusId = StripEmojis(txtScopusId.Text.Trim());
        articleData.ResearcherId = StripEmojis(txtResearcherId.Text.Trim());
        
        // Organization
        articleData.OrgName = StripEmojis(txtOrgName.Text.Trim());

        // Dates
        articleData.DateReceived = StripEmojis(txtDateReceived.Text.Trim());
        articleData.DateAccepted = StripEmojis(txtDateAccepted.Text.Trim());
        articleData.DatePublication = StripEmojis(txtDatePublication.Text.Trim());

        // Funding (with emoji stripping and empty string filtering)
        articleData.Fundings = SplitTrimAndStripEmojis(txtFundings.Text, new[] { '\n', '\r' });

        // Rubrics (with emoji stripping and empty string filtering)
        articleData.Rubrics = SplitTrimAndStripEmojis(txtRubrics.Text, new[] { ',', ';', '\n', '\r' });

        // Files and URLs (from fileUrlEntries with emoji stripping)
        articleData.Files = new List<string>();
        articleData.TextContent = null; // Will be set from fileUrlEntries if present
        
        foreach (var entry in fileUrlEntries)
        {
            if (entry.Type == "text")
            {
                // Store text content separately
                articleData.TextContent = StripEmojis(entry.Value);
                continue;
            }
            
            // Build file/URL string in format: value|desc|lang
            var fileStr = StripEmojis(entry.Value);
            if (!string.IsNullOrWhiteSpace(entry.Desc))
            {
                fileStr += "|" + StripEmojis(entry.Desc);
                if (!string.IsNullOrWhiteSpace(entry.Lang))
                {
                    fileStr += "|" + entry.Lang;
                }
            }
            else if (!string.IsNullOrWhiteSpace(entry.Lang))
            {
                // Add double pipe for empty desc field
                fileStr += "||" + entry.Lang;
            }
            
            if (!string.IsNullOrWhiteSpace(fileStr))
                articleData.Files.Add(fileStr);
        }
        
        // If no text content from fileUrlEntries, check the old txtTextContent field for backward compatibility
        if (string.IsNullOrWhiteSpace(articleData.TextContent) && !string.IsNullOrWhiteSpace(txtTextContent.Text))
        {
            articleData.TextContent = StripEmojis(txtTextContent.Text.Trim());
        }

        // References (with emoji stripping and empty string filtering)
        articleData.References = SplitTrimAndStripEmojis(txtReferences.Text, new[] { '\n', '\r' });

        return articleData;
    }
    
    /// <summary>
    /// Auto-save current article without showing success message
    /// Returns true if save was successful or there was nothing to save
    /// </summary>
    private bool AutoSaveCurrentArticle()
    {
        // If not editing an existing article, nothing to auto-save
        if (!currentEditingIndex.HasValue)
            return true;
        
        // Validate required fields (at least one title should exist)
        if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtTitleEng.Text))
        {
            // If editing but no title, just allow switching (user might have cleared intentionally)
            return true;
        }

        // Create article data from fields
        var articleData = CreateArticleDataFromFields();

        // Update existing article
        if (currentEditingIndex.Value >= 0 && currentEditingIndex.Value < ParsedArticles.Count)
        {
            ParsedArticles[currentEditingIndex.Value] = articleData;
            UpdateArticlesList();
            return true;
        }
        
        return false;
    }
    
    private class FieldChange
    {
        public TextBox Field { get; }
        public string OldValue { get; }
        public string NewValue { get; }

        public FieldChange(TextBox field, string oldValue, string newValue)
        {
            Field = field;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
    
    // Helper class to store file/URL entries in the list
    private class FileUrlEntry
    {
        public string Type { get; set; } = ""; // "file", "url", or "text"
        public string Value { get; set; } = "";
        public string? Desc { get; set; }
        public string? Lang { get; set; }
        
        public override string ToString()
        {
            var parts = new List<string>();
            
            if (Type == "text")
            {
                parts.Add($"[Текст статьи]");
                if (!string.IsNullOrEmpty(Lang))
                    parts.Add($"({Lang})");
                parts.Add($": {(Value.Length > 50 ? Value.Substring(0, 50) + "..." : Value)}");
            }
            else
            {
                parts.Add($"[{Type.ToUpper()}]");
                parts.Add(Value);
                if (!string.IsNullOrEmpty(Desc))
                    parts.Add($"({Desc})");
                if (!string.IsNullOrEmpty(Lang))
                    parts.Add($"[{Lang}]");
            }
            
            return string.Join(" ", parts);
        }
    }
}
