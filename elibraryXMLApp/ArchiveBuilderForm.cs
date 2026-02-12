using elibraryXMLApp.Services;
using elibraryXMLApp.Models;

namespace elibraryXMLApp;

public partial class ArchiveBuilderForm : Form
{
    private Journal journal;
    private readonly IArchiveBuilderService archiveService;
    private List<string> articlePdfPaths;

    public ArchiveBuilderForm(IArchiveBuilderService archiveService, Journal journal)
    {
        InitializeComponent();
        this.journal = journal;
        this.archiveService = archiveService;
        this.articlePdfPaths = new List<string>();
    }

    private void btnBrowseCover_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "JPEG Images (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*",
            Title = "Выберите обложку выпуска"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtCoverPath.Text = openDialog.FileName;
        }
    }

    private void btnBrowseCoverRussian_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "JPEG Images (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*",
            Title = "Выберите обложку выпуска на русском языке"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtCoverRussianPath.Text = openDialog.FileName;
        }
    }

    private void btnBrowseCoverEnglish_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "JPEG Images (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*",
            Title = "Выберите обложку выпуска на английском языке"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtCoverEnglishPath.Text = openDialog.FileName;
        }
    }

    private void btnBrowseArticles_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
            Title = "Выберите PDF файлы статей",
            Multiselect = true
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            articlePdfPaths.AddRange(openDialog.FileNames);
            UpdateArticlesList();
        }
    }

    private void btnClearArticles_Click(object? sender, EventArgs e)
    {
        articlePdfPaths.Clear();
        UpdateArticlesList();
    }

    private void btnBrowseCombined_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
            Title = "Выберите объединенный PDF выпуска"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtCombinedPath.Text = openDialog.FileName;
        }
    }

    private void btnBrowseXml_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*",
            Title = "Выберите XML файл метаданных"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            txtXmlPath.Text = openDialog.FileName;
        }
    }

    private void btnBrowseOutput_Click(object? sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog
        {
            Description = "Выберите папку для сохранения архива выпуска"
        };

        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            txtOutputPath.Text = folderDialog.SelectedPath;
        }
    }

    private void btnBuildArchive_Click(object? sender, EventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(txtOutputPath.Text))
        {
            MessageBox.Show("Пожалуйста, выберите папку для сохранения архива", 
                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var settings = new ArchiveBuilderSettings
        {
            OutputDirectory = txtOutputPath.Text,
            CoverImagePath = string.IsNullOrWhiteSpace(txtCoverPath.Text) ? null : txtCoverPath.Text,
            CoverImageRussianPath = string.IsNullOrWhiteSpace(txtCoverRussianPath.Text) ? null : txtCoverRussianPath.Text,
            CoverImageEnglishPath = string.IsNullOrWhiteSpace(txtCoverEnglishPath.Text) ? null : txtCoverEnglishPath.Text,
            ArticlePdfPaths = articlePdfPaths.Any() ? articlePdfPaths : null,
            CombinedPdfPath = string.IsNullOrWhiteSpace(txtCombinedPath.Text) ? null : txtCombinedPath.Text,
            XmlMetadataPath = string.IsNullOrWhiteSpace(txtXmlPath.Text) ? null : txtXmlPath.Text
        };

        // Build archive
        var result = archiveService.BuildArchive(journal, settings);

        // Display results
        txtLog.Text = string.Join(Environment.NewLine, result.Messages);

        if (result.Success)
        {
            var summaryParts = new List<string>();
            
            if (result.CoverImageProcessed)
                summaryParts.Add("Обложка (legacy): ✓");
            if (result.CoverImageRussianProcessed)
                summaryParts.Add("Обложка (RU): ✓");
            if (result.CoverImageEnglishProcessed)
                summaryParts.Add("Обложка (EN): ✓");
            if (result.ArticlePdfsProcessed > 0)
                summaryParts.Add($"PDF статей: {result.ArticlePdfsProcessed}");
            if (result.CombinedPdfProcessed)
                summaryParts.Add("Объединенный PDF: ✓");
            if (result.XmlMetadataGenerated)
                summaryParts.Add("XML метаданные: ✓ (сгенерированы)");
            if (result.XmlMetadataAttached)
                summaryParts.Add("XML метаданные: ✓ (прикреплены)");
            
            var verificationStatus = result.VerificationPassed ? "✓ Пройдена" : "⚠ Есть предупреждения";
            summaryParts.Add($"Верификация: {verificationStatus}");

            var summary = string.Join("\n", summaryParts);

            MessageBox.Show(
                $"Архив выпуска успешно подготовлен!\n\n" +
                $"{summary}\n\n" +
                $"Путь: {settings.OutputDirectory}",
                "Успех",
                MessageBoxButtons.OK,
                result.VerificationPassed ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }
        else
        {
            MessageBox.Show(
                "При подготовке архива возникли ошибки.\n" +
                "См. подробности в журнале ниже.",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }

    private void UpdateArticlesList()
    {
        lstArticles.Items.Clear();
        foreach (var path in articlePdfPaths)
        {
            lstArticles.Items.Add(Path.GetFileName(path));
        }
        lblArticleCount.Text = $"Файлов: {articlePdfPaths.Count}";
    }
}
