using elibraryXMLApp.Models;

namespace elibraryXMLApp;

public partial class ArticleForm : Form
{
    public Article Article { get; private set; }
    
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
    
    private List<FileUrlEntry> fileUrlEntries = new List<FileUrlEntry>();
    private int editingEntryIndex = -1; // Index of entry being edited, -1 if adding new

    public ArticleForm(Article? article = null)
    {
        InitializeComponent();
        Article = article ?? new Article();
        
        // Initialize Article Type ComboBox with default selection
        cmbArticleType.SelectedIndex = 0; // Default to "RAR - Научная статья"
        
        if (article != null)
        {
            LoadArticleData();
        }
    }

    private void LoadArticleData()
    {
        txtPages.Text = Article.Pages;
        
        // Load Article Type into ComboBox
        int articleTypeIndex = Article.ArtType switch
        {
            "RAR" => 0,
            "ABS" => 1,
            "BRV" => 2,
            "CNF" => 3,
            "COR" => 4,
            "EDI" => 5,
            "MIS" => 6,
            "PER" => 7,
            "REP" => 8,
            "REV" => 9,
            "RPR" => 10,
            "SCO" => 11,
            "UNK" => 12,
            _ => 0 // Default to RAR
        };
        cmbArticleType.SelectedIndex = articleTypeIndex;

        if (Article.ArtTitles.TitleList.Any())
        {
            txtTitleRus.Text = Article.ArtTitles.TitleList.FirstOrDefault(t => t.Lang == "RUS")?.Value ?? "";
            txtTitleEng.Text = Article.ArtTitles.TitleList.FirstOrDefault(t => t.Lang == "ENG")?.Value ?? "";
        }

        if (Article.Abstracts?.AbstractList.Any() == true)
        {
            txtAbstractRus.Text = Article.Abstracts.AbstractList.FirstOrDefault(a => a.Lang == "RUS")?.Value ?? "";
            txtAbstractEng.Text = Article.Abstracts.AbstractList.FirstOrDefault(a => a.Lang == "ENG")?.Value ?? "";
        }

        txtDoi.Text = Article.Codes?.Doi ?? "";
        txtEdn.Text = Article.Codes?.Edn ?? "";
        txtBbk.Text = Article.Codes?.Bbk ?? "";
        txtVak.Text = Article.Codes?.Vak ?? "";
        txtJel.Text = Article.Codes?.Jel ?? "";
        txtMsc.Text = Article.Codes?.Msc ?? "";
        txtPacs.Text = Article.Codes?.Pacs ?? "";

        // Load dates
        txtDateReceived.Text = Article.Dates?.DateReceived ?? "";
        txtDateAccepted.Text = Article.Dates?.DateAccepted ?? "";
        txtDatePublication.Text = Article.Dates?.DatePublication ?? "";

        // Load funding
        if (Article.Fundings?.FundingList.Any() == true)
        {
            txtFunding.Text = Article.Fundings.FundingList.FirstOrDefault()?.Value ?? "";
        }

        // Load keywords
        if (Article.Keywords?.KwdGroupList.Any() == true)
        {
            var rusKeywords = Article.Keywords.KwdGroupList.FirstOrDefault(k => k.Lang == "RUS");
            if (rusKeywords != null && rusKeywords.KeywordList.Any())
            {
                txtKeywordsRus.Text = string.Join(", ", rusKeywords.KeywordList);
            }

            var engKeywords = Article.Keywords.KwdGroupList.FirstOrDefault(k => k.Lang == "ENG");
            if (engKeywords != null && engKeywords.KeywordList.Any())
            {
                txtKeywordsEng.Text = string.Join(", ", engKeywords.KeywordList);
            }
        }

        // Load files/URLs into entries list
        fileUrlEntries.Clear();
        
        // Load article text first
        if (Article.Texts.Any())
        {
            var articleText = Article.Texts.FirstOrDefault();
            if (articleText != null)
            {
                fileUrlEntries.Add(new FileUrlEntry
                {
                    Type = "text",
                    Value = articleText.Value,
                    Lang = articleText.Lang ?? "RUS"
                });
            }
        }
        
        if (Article.Files != null)
        {
            foreach (var file in Article.Files.FileList)
            {
                fileUrlEntries.Add(new FileUrlEntry
                {
                    Type = "file",
                    Value = file.Value,
                    Desc = file.Desc,
                    Lang = file.Lang
                });
            }
            foreach (var url in Article.Files.UrlList)
            {
                fileUrlEntries.Add(new FileUrlEntry
                {
                    Type = "url",
                    Value = url.Value,
                    Desc = url.Desc,
                    Lang = url.Lang
                });
            }
        }
        
        RefreshFileUrlList();

        lstAuthors.Items.Clear();
        int authorNum = 1;
        foreach (var author in Article.Authors)
        {
            // Get RUS info first, fallback to first available language
            var info = author.IndividInfoList.FirstOrDefault(i => i.Lang == "RUS") 
                       ?? author.IndividInfoList.FirstOrDefault();
            if (info != null)
            {
                lstAuthors.Items.Add($"{authorNum}. {info.Surname} {info.Initials}");
            }
            authorNum++;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPages.Text))
        {
            MessageBox.Show("Пожалуйста, введите страницы статьи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTitleRus.Text))
        {
            MessageBox.Show("Пожалуйста, введите название статьи на русском", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Article.Pages = txtPages.Text;
        
        // Save Article Type from ComboBox
        Article.ArtType = cmbArticleType.SelectedIndex switch
        {
            0 => "RAR",
            1 => "ABS",
            2 => "BRV",
            3 => "CNF",
            4 => "COR",
            5 => "EDI",
            6 => "MIS",
            7 => "PER",
            8 => "REP",
            9 => "REV",
            10 => "RPR",
            11 => "SCO",
            12 => "UNK",
            _ => "RAR" // Default to RAR
        };

        Article.ArtTitles.TitleList.Clear();
        if (!string.IsNullOrWhiteSpace(txtTitleRus.Text))
        {
            Article.ArtTitles.TitleList.Add(new ArtTitle { Lang = "RUS", Value = txtTitleRus.Text });
        }
        if (!string.IsNullOrWhiteSpace(txtTitleEng.Text))
        {
            Article.ArtTitles.TitleList.Add(new ArtTitle { Lang = "ENG", Value = txtTitleEng.Text });
        }

        if (!string.IsNullOrWhiteSpace(txtAbstractRus.Text) || !string.IsNullOrWhiteSpace(txtAbstractEng.Text))
        {
            Article.Abstracts = new Abstracts();
            if (!string.IsNullOrWhiteSpace(txtAbstractRus.Text))
            {
                Article.Abstracts.AbstractList.Add(new Abstract { Lang = "RUS", Value = txtAbstractRus.Text });
            }
            if (!string.IsNullOrWhiteSpace(txtAbstractEng.Text))
            {
                Article.Abstracts.AbstractList.Add(new Abstract { Lang = "ENG", Value = txtAbstractEng.Text });
            }
        }

        // Save article text and files/URLs from entries list
        Article.Texts.Clear();
        Article.Files = null;
        
        var files = new Models.Files();
        
        foreach (var entry in fileUrlEntries)
        {
            if (entry.Type == "text")
            {
                Article.Texts.Add(new ArticleText { Lang = entry.Lang, Value = entry.Value });
            }
            else if (entry.Type == "file")
            {
                files.FileList.Add(new Models.FileItem
                {
                    Desc = entry.Desc,
                    Lang = entry.Lang,
                    Value = entry.Value
                });
            }
            else if (entry.Type == "url")
            {
                files.UrlList.Add(new Models.FileUrl
                {
                    Desc = entry.Desc,
                    Lang = entry.Lang,
                    Value = entry.Value
                });
            }
        }
        
        if (files.FileList.Any() || files.UrlList.Any())
        {
            Article.Files = files;
        }

        // Save all codes (including extended ones)
        if (!string.IsNullOrWhiteSpace(txtDoi.Text) || !string.IsNullOrWhiteSpace(txtEdn.Text) ||
            !string.IsNullOrWhiteSpace(txtBbk.Text) || !string.IsNullOrWhiteSpace(txtVak.Text) ||
            !string.IsNullOrWhiteSpace(txtJel.Text) || !string.IsNullOrWhiteSpace(txtMsc.Text) ||
            !string.IsNullOrWhiteSpace(txtPacs.Text))
        {
            Article.Codes = new ArticleCodes 
            { 
                Doi = txtDoi.Text,
                Edn = txtEdn.Text,
                Bbk = txtBbk.Text,
                Vak = txtVak.Text,
                Jel = txtJel.Text,
                Msc = txtMsc.Text,
                Pacs = txtPacs.Text
            };
        }

        // Save dates
        if (!string.IsNullOrWhiteSpace(txtDateReceived.Text) || 
            !string.IsNullOrWhiteSpace(txtDateAccepted.Text) ||
            !string.IsNullOrWhiteSpace(txtDatePublication.Text))
        {
            Article.Dates = new ArticleDates
            {
                DateReceived = txtDateReceived.Text,
                DateAccepted = txtDateAccepted.Text,
                DatePublication = txtDatePublication.Text
            };
        }

        // Save funding
        if (!string.IsNullOrWhiteSpace(txtFunding.Text))
        {
            Article.Fundings = new Fundings();
            Article.Fundings.FundingList.Add(new Funding { Lang = "RUS", Value = txtFunding.Text });
        }

        // Save keywords
        if (!string.IsNullOrWhiteSpace(txtKeywordsRus.Text) || !string.IsNullOrWhiteSpace(txtKeywordsEng.Text))
        {
            Article.Keywords = new Keywords();
            
            if (!string.IsNullOrWhiteSpace(txtKeywordsRus.Text))
            {
                var rusKwdGroup = new KwdGroup { Lang = "RUS" };
                var keywords = txtKeywordsRus.Text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .ToList();
                rusKwdGroup.KeywordList.AddRange(keywords);
                Article.Keywords.KwdGroupList.Add(rusKwdGroup);
            }

            if (!string.IsNullOrWhiteSpace(txtKeywordsEng.Text))
            {
                var engKwdGroup = new KwdGroup { Lang = "ENG" };
                var keywords = txtKeywordsEng.Text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .ToList();
                engKwdGroup.KeywordList.AddRange(keywords);
                Article.Keywords.KwdGroupList.Add(engKwdGroup);
            }
        }

        // Assign author numbers
        for (int i = 0; i < Article.Authors.Count; i++)
        {
            Article.Authors[i].Num = (uint)(i + 1);
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void btnAddAuthor_Click(object? sender, EventArgs e)
    {
        using var authorForm = new AuthorForm();
        if (authorForm.ShowDialog() == DialogResult.OK)
        {
            Article.Authors.Add(authorForm.Author);
            LoadArticleData();
        }
    }

    private void btnRemoveAuthor_Click(object? sender, EventArgs e)
    {
        if (lstAuthors.SelectedIndex >= 0)
        {
            Article.Authors.RemoveAt(lstAuthors.SelectedIndex);
            LoadArticleData();
        }
    }

    private void btnEditAuthor_Click(object? sender, EventArgs e)
    {
        if (lstAuthors.SelectedIndex >= 0)
        {
            var selectedAuthor = Article.Authors[lstAuthors.SelectedIndex];
            using var authorForm = new AuthorForm(selectedAuthor);
            if (authorForm.ShowDialog() == DialogResult.OK)
            {
                Article.Authors[lstAuthors.SelectedIndex] = authorForm.Author;
                LoadArticleData();
            }
        }
    }

    public void ApplyParsedData(Services.ParsedArticleData parsedData)
    {
        // Apply DOI
        if (!string.IsNullOrEmpty(parsedData.Doi))
        {
            txtDoi.Text = parsedData.Doi;
        }

        // Apply EDN
        if (!string.IsNullOrEmpty(parsedData.Edn))
        {
            txtEdn.Text = parsedData.Edn;
        }

        // Apply titles
        if (parsedData.Titles.Any())
        {
            // First title to Russian field
            if (parsedData.Titles.Count > 0)
            {
                txtTitleRus.Text = parsedData.Titles[0];
            }
            // Second title to English field if available
            if (parsedData.Titles.Count > 1)
            {
                txtTitleEng.Text = parsedData.Titles[1];
            }
        }

        // Apply abstract
        if (!string.IsNullOrEmpty(parsedData.Abstract))
        {
            // Try to detect if it's Russian or English
            bool isCyrillic = parsedData.Abstract.Any(c => c >= 'А' && c <= 'я');
            if (isCyrillic)
            {
                txtAbstractRus.Text = parsedData.Abstract;
            }
            else
            {
                txtAbstractEng.Text = parsedData.Abstract;
            }
        }

        // Apply keywords
        if (parsedData.Keywords.Any())
        {
            var keywordsText = string.Join(", ", parsedData.Keywords);
            // Try to detect language
            bool isCyrillic = parsedData.Keywords.First().Any(c => c >= 'А' && c <= 'я');
            if (isCyrillic)
            {
                txtKeywordsRus.Text = keywordsText;
            }
            else
            {
                txtKeywordsEng.Text = keywordsText;
            }
        }

        // Apply pages
        if (!string.IsNullOrEmpty(parsedData.Pages))
        {
            txtPages.Text = parsedData.Pages;
        }

        // Show info about parsed data including new fields
        var infoMessage = "";
        
        if (parsedData.Authors.Any() || parsedData.Emails.Any())
        {
            infoMessage += "Обнаружены авторы и email адреса:\n\n";
            
            if (parsedData.Authors.Any())
            {
                infoMessage += "Авторы:\n";
                foreach (var author in parsedData.Authors)
                {
                    infoMessage += $"  • {author}\n";
                }
            }
            
            if (parsedData.Emails.Any())
            {
                infoMessage += "\nEmail:\n";
                foreach (var email in parsedData.Emails)
                {
                    infoMessage += $"  • {email}\n";
                }
            }
            
            infoMessage += "\nИспользуйте кнопки 'Добавить автора' для ручного добавления авторов.\n";
        }

        // Additional codes info
        var additionalCodes = new List<string>();
        if (!string.IsNullOrEmpty(parsedData.Udk)) additionalCodes.Add($"УДК: {parsedData.Udk}");
        if (!string.IsNullOrEmpty(parsedData.Bbk)) additionalCodes.Add($"ББК: {parsedData.Bbk}");
        if (!string.IsNullOrEmpty(parsedData.Vak)) additionalCodes.Add($"ВАК: {parsedData.Vak}");
        if (!string.IsNullOrEmpty(parsedData.Jel)) additionalCodes.Add($"JEL: {parsedData.Jel}");
        if (!string.IsNullOrEmpty(parsedData.Msc)) additionalCodes.Add($"MSC: {parsedData.Msc}");
        if (!string.IsNullOrEmpty(parsedData.Pacs)) additionalCodes.Add($"PACS: {parsedData.Pacs}");
        
        if (additionalCodes.Any())
        {
            infoMessage += "\nДополнительные коды:\n  " + string.Join("\n  ", additionalCodes) + "\n";
        }

        // Author codes info
        var authorCodes = new List<string>();
        if (!string.IsNullOrEmpty(parsedData.Orcid)) authorCodes.Add($"ORCID: {parsedData.Orcid}");
        if (!string.IsNullOrEmpty(parsedData.Spin)) authorCodes.Add($"SPIN: {parsedData.Spin}");
        if (!string.IsNullOrEmpty(parsedData.ScopusId)) authorCodes.Add($"Scopus ID: {parsedData.ScopusId}");
        if (!string.IsNullOrEmpty(parsedData.ResearcherId)) authorCodes.Add($"Researcher ID: {parsedData.ResearcherId}");
        
        if (authorCodes.Any())
        {
            infoMessage += "\nКоды автора:\n  " + string.Join("\n  ", authorCodes) + "\n";
        }

        // Dates info
        var dates = new List<string>();
        if (!string.IsNullOrEmpty(parsedData.DateReceived)) dates.Add($"Получено: {parsedData.DateReceived}");
        if (!string.IsNullOrEmpty(parsedData.DateAccepted)) dates.Add($"Принято: {parsedData.DateAccepted}");
        if (!string.IsNullOrEmpty(parsedData.DatePublication)) dates.Add($"Опубликовано: {parsedData.DatePublication}");
        
        if (dates.Any())
        {
            infoMessage += "\nДаты:\n  " + string.Join("\n  ", dates) + "\n";
        }

        // Additional fields info
        if (parsedData.Fundings.Any())
        {
            infoMessage += $"\nФинансирование: {parsedData.Fundings.Count} записей\n";
        }
        if (parsedData.Rubrics.Any())
        {
            infoMessage += $"Рубрики: {parsedData.Rubrics.Count} записей\n";
        }
        if (parsedData.Files.Any())
        {
            infoMessage += $"Файлы/URL: {parsedData.Files.Count} записей\n";
            // Apply files to Article
            Article.Files = ParseFilesFromStrings(parsedData.Files);
            
            // Also update the fileUrlEntries list
            if (Article.Files != null)
            {
                foreach (var file in Article.Files.FileList)
                {
                    fileUrlEntries.Add(new FileUrlEntry
                    {
                        Type = "file",
                        Value = file.Value,
                        Desc = file.Desc,
                        Lang = file.Lang
                    });
                }
                foreach (var url in Article.Files.UrlList)
                {
                    fileUrlEntries.Add(new FileUrlEntry
                    {
                        Type = "url",
                        Value = url.Value,
                        Desc = url.Desc,
                        Lang = url.Lang
                    });
                }
                RefreshFileUrlList();
            }
        }
        if (parsedData.References.Any())
        {
            infoMessage += $"Ссылки: {parsedData.References.Count} записей\n";
        }

        if (!string.IsNullOrEmpty(infoMessage))
        {
            MessageBox.Show(infoMessage, "Информация о распознанных данных", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    /// <summary>
    /// Parse files from string format (url|type|lang) to Files model
    /// </summary>
    private Models.Files? ParseFilesFromStrings(List<string> fileStrings)
    {
        if (fileStrings == null || !fileStrings.Any())
            return null;
            
        var files = new Models.Files();
        
        foreach (var fileString in fileStrings)
        {
            if (string.IsNullOrWhiteSpace(fileString))
                continue;
                
            var parts = fileString.Split('|');
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
            
            if (isUrl)
            {
                files.UrlList.Add(new Models.FileUrl
                {
                    Desc = desc,
                    Lang = lang,
                    Value = value
                });
            }
            else
            {
                files.FileList.Add(new Models.FileItem
                {
                    Desc = desc,
                    Lang = lang,
                    Value = value
                });
            }
        }
        
        return (files.FileList.Any() || files.UrlList.Any()) ? files : null;
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
        fileUrlEntries.RemoveAll(e => e.Type == "text");
        
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
}
