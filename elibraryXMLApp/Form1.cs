using elibraryXMLApp.Models;
using elibraryXMLApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace elibraryXMLApp;

public partial class Form1 : Form
{
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern bool DestroyIcon(IntPtr handle);

    private Journal journal;
    private readonly IXmlService xmlService;
    private readonly IJsonService jsonService;
    private readonly IJatsExportService jatsExportService;
    private readonly IJournal3ExportService journal3ExportService;
    private System.Windows.Forms.Timer autoSaveTimer;

    public Form1(
        IXmlService xmlService,
        IJsonService jsonService,
        IJatsExportService jatsExportService,
        IJournal3ExportService journal3ExportService,
        Journal? initialJournal = null)
    {
        InitializeComponent();
        
        // Inject dependencies
        this.xmlService = xmlService;
        this.jsonService = jsonService;
        this.jatsExportService = jatsExportService;
        this.journal3ExportService = journal3ExportService;
        
        journal = initialJournal ?? new Journal
        {
            JournalInfo = new JournalInfo(),
            Issue = new Issue { Articles = new Articles() }
        };
        
        // Setup auto-save timer (every 30 seconds)
        autoSaveTimer = new System.Windows.Forms.Timer();
        autoSaveTimer.Interval = 30000; // 30 seconds
        autoSaveTimer.Tick += AutoSaveTimer_Tick;
        autoSaveTimer.Start();
        
        // Initialize Issue Type ComboBox with default selection
        cmbIssueType.SelectedIndex = 0; // Default to "ISS - Выпуск журнала"
        
        // Load form data if journal was provided
        if (initialJournal != null)
        {
            LoadFormData();
        }
    }

    private void AutoSaveTimer_Tick(object? sender, EventArgs e)
    {
        try
        {
            jsonService.AutoSave(journal);
        }
        catch
        {
            // Silent fail for auto-save
        }
    }

    private void btnSaveXml_Click(object? sender, EventArgs e)
    {
        try
        {
            // Collect data from form
            if (!uint.TryParse(txtTitleId.Text, out uint titleId))
            {
                MessageBox.Show("Пожалуйста, введите корректный ID журнала (число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtJournalTitle.Text))
            {
                MessageBox.Show("Пожалуйста, введите название журнала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ushort.TryParse(txtDateUni.Text, out ushort dateUni))
            {
                MessageBox.Show("Пожалуйста, введите корректный год издания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            journal.TitleId = titleId;
            journal.Issn = txtIssn.Text;
            journal.Eissn = txtEissn.Text;
            journal.JournalInfo.Title = txtJournalTitle.Text;
            journal.JournalInfo.Lang = "RUS";

            if (uint.TryParse(txtVolume.Text, out uint volume))
                journal.Issue.Volume = volume;

            journal.Issue.Number = txtNumber.Text;
            journal.Issue.Pages = txtPages.Text;
            journal.Issue.DateUni = dateUni;
            
            // Save Issue Type
            journal.Issue.Type = cmbIssueType.SelectedIndex switch
            {
                0 => "ISS",
                1 => "OFI",
                2 => "SPI",
                _ => "ISS" // Default to ISS
            };

            // Show save file dialog
            using var saveDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                DefaultExt = "xml",
                FileName = "journal.xml"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                xmlService.SaveJournalToXml(journal, saveDialog.FileName);
                MessageBox.Show("XML файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLoadXml_Click(object? sender, EventArgs e)
    {
        try
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                DefaultExt = "xml"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var loadedJournal = xmlService.LoadJournalFromXml(openDialog.FileName);
                if (loadedJournal != null)
                {
                    journal = loadedJournal;
                    LoadFormData();
                    MessageBox.Show("XML файл успешно загружен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadFormData()
    {
        txtTitleId.Text = journal.TitleId.ToString();
        txtIssn.Text = journal.Issn ?? "";
        txtEissn.Text = journal.Eissn ?? "";
        txtJournalTitle.Text = journal.JournalInfo?.Title ?? "";
        txtVolume.Text = journal.Issue.Volume.ToString();
        txtNumber.Text = journal.Issue.Number ?? "";
        txtPages.Text = journal.Issue.Pages ?? "";
        txtDateUni.Text = journal.Issue.DateUni.ToString();
        
        // Load Issue Type
        int issueTypeIndex = (journal.Issue.Type ?? "ISS") switch
        {
            "ISS" => 0,
            "OFI" => 1,
            "SPI" => 2,
            _ => 0 // Default to ISS
        };
        cmbIssueType.SelectedIndex = issueTypeIndex;

        lstArticles.Items.Clear();
        foreach (var article in journal.Issue.Articles.ArticleList)
        {
            var title = article.ArtTitles.TitleList.FirstOrDefault()?.Value ?? "Без названия";
            lstArticles.Items.Add($"{title} ({article.Pages})");
        }
    }

    private void btnAddArticle_Click(object? sender, EventArgs e)
    {
        using var articleForm = new ArticleForm();
        if (articleForm.ShowDialog() == DialogResult.OK)
        {
            journal.Issue.Articles.ArticleList.Add(articleForm.Article);
            LoadFormData();
        }
    }

    private void btnEditArticle_Click(object? sender, EventArgs e)
    {
        if (lstArticles.SelectedIndex >= 0)
        {
            var article = journal.Issue.Articles.ArticleList[lstArticles.SelectedIndex];
            using var articleForm = new ArticleForm(article);
            if (articleForm.ShowDialog() == DialogResult.OK)
            {
                journal.Issue.Articles.ArticleList[lstArticles.SelectedIndex] = articleForm.Article;
                LoadFormData();
            }
        }
        else
        {
            MessageBox.Show("Пожалуйста, выберите статью для редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnRemoveArticle_Click(object? sender, EventArgs e)
    {
        if (lstArticles.SelectedIndex >= 0)
        {
            journal.Issue.Articles.ArticleList.RemoveAt(lstArticles.SelectedIndex);
            LoadFormData();
        }
        else
        {
            MessageBox.Show("Пожалуйста, выберите статью для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void saveJsonMenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                FileName = "backup.json"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                jsonService.SaveJournalToJson(journal, saveDialog.FileName);
                MessageBox.Show("Резервная копия успешно сохранена!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении резервной копии: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void loadJsonMenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var loadedJournal = jsonService.LoadJournalFromJson(openDialog.FileName);
                if (loadedJournal != null)
                {
                    journal = loadedJournal;
                    LoadFormData();
                    MessageBox.Show("Резервная копия успешно загружена!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке резервной копии: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void exitMenuItem_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void manualParserMenuItem_Click(object? sender, EventArgs e)
    {
        using var parserForm = Program.ServiceProvider.GetRequiredService<ManualParserForm>();
        if (parserForm.ShowDialog() == DialogResult.OK && parserForm.ParsedArticles.Count > 0)
        {
            int addedCount = 0;
            
            // Process each parsed article
            for (int i = 0; i < parserForm.ParsedArticles.Count; i++)
            {
                var parsedData = parserForm.ParsedArticles[i];
                
                // Show article form with parsed data pre-filled
                using var articleForm = new ArticleForm();
                articleForm.ApplyParsedData(parsedData);
                
                if (articleForm.ShowDialog() == DialogResult.OK)
                {
                    journal.Issue.Articles.ArticleList.Add(articleForm.Article);
                    addedCount++;
                }
                else
                {
                    // User cancelled, ask if they want to continue with remaining articles
                    if (i < parserForm.ParsedArticles.Count - 1)
                    {
                        var result = MessageBox.Show(
                            $"Пропустить эту статью и продолжить с остальными?\nSkip this article and continue with others?",
                            "Вопрос / Question",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        
                        if (result == DialogResult.No)
                            break;
                    }
                }
            }
            
            if (addedCount > 0)
            {
                LoadFormData();
                MessageBox.Show($"Добавлено статей: {addedCount} из {parserForm.ParsedArticles.Count}\nArticles added: {addedCount} of {parserForm.ParsedArticles.Count}", 
                    "Успех / Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void archiveBuilderMenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            using var archiveForm = ActivatorUtilities.CreateInstance<ArchiveBuilderForm>(
                Program.ServiceProvider, 
                journal);
            archiveForm.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при открытии построителя архива: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void exportJatsMenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!journal.Issue.Articles.ArticleList.Any())
            {
                MessageBox.Show("Нет статей для экспорта!", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Выберите папку для сохранения JATS XML файлов"
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                jatsExportService.ExportToJats(journal, folderDialog.SelectedPath);
                MessageBox.Show(
                    $"Экспорт в JATS XML выполнен успешно!\n" +
                    $"Создано файлов: {journal.Issue.Articles.ArticleList.Count}\n" +
                    $"Путь: {folderDialog.SelectedPath}",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте в JATS XML: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void exportJournal3MenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!journal.Issue.Articles.ArticleList.Any())
            {
                MessageBox.Show("Нет статей для экспорта!", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                DefaultExt = "xml",
                FileName = "journal3.xml",
                Title = "Сохранить journal3 XML"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                journal3ExportService.ExportToJournal3(journal, saveDialog.FileName);
                MessageBox.Show(
                    "Экспорт в journal3 XML выполнен успешно!\n" +
                    "Формат для ИС «Метафора».",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте в journal3 XML: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void aboutMenuItem_Click(object? sender, EventArgs e)
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog(this);
    }
}
