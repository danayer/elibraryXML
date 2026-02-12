using elibraryXMLApp.Models;
using elibraryXMLApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace elibraryXMLApp;

public partial class StartupForm : Form
{
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern bool DestroyIcon(IntPtr handle);

    private readonly IJsonService jsonService;
    private readonly IXmlService xmlService;
    private readonly IHtmlParsingService htmlParsingService;
    
    public Journal? LoadedJournal { get; private set; }
    public bool ShouldContinue { get; private set; }

    public StartupForm(
        IJsonService jsonService,
        IXmlService xmlService,
        IHtmlParsingService htmlParsingService)
    {
        InitializeComponent();
        
        // Inject dependencies
        this.jsonService = jsonService;
        this.xmlService = xmlService;
        this.htmlParsingService = htmlParsingService;
        
        ShouldContinue = false;
    }

    private void btnLoadDoajXml_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
            Title = "Выберите DOAJ XML файл"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // For now, we'll treat DOAJ XML similar to regular XML
                // In future, we can add specific DOAJ parser
                LoadedJournal = xmlService.LoadJournalFromXml(openDialog.FileName);
                
                if (LoadedJournal != null)
                {
                    MessageBox.Show("DOAJ XML успешно загружен!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShouldContinue = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки DOAJ XML: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCreateEmpty_Click(object? sender, EventArgs e)
    {
        LoadedJournal = new Journal
        {
            JournalInfo = new JournalInfo(),
            Issue = new Issue { Articles = new Articles() }
        };
        ShouldContinue = true;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnRestoreJson_Click(object? sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            Title = "Выберите JSON файл резервной копии"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                LoadedJournal = jsonService.LoadJournalFromJson(openDialog.FileName);
                
                if (LoadedJournal != null)
                {
                    MessageBox.Show("Резервная копия успешно восстановлена!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShouldContinue = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка восстановления из JSON: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        ShouldContinue = false;
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void exitMenuItem_Click(object? sender, EventArgs e)
    {
        ShouldContinue = false;
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void aboutMenuItem_Click(object? sender, EventArgs e)
    {
        using var aboutForm = new AboutForm();
        aboutForm.ShowDialog(this);
    }

    private void btnPrepareArchive_Click(object? sender, EventArgs e)
    {
        // Ask user to load or create a journal first
        var result = MessageBox.Show(
            "Для подготовки архива выпуска нужен загруженный журнал.\n\n" +
            "Загрузить существующий журнал?",
            "Подготовка архива выпуска",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            // Try to load from JSON first
            using var openDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml|All files (*.*)|*.*",
                Title = "Выберите файл журнала"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Journal? journal = null;
                    
                    if (Path.GetExtension(openDialog.FileName).Equals(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        journal = jsonService.LoadJournalFromJson(openDialog.FileName);
                    }
                    else if (Path.GetExtension(openDialog.FileName).Equals(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        journal = xmlService.LoadJournalFromXml(openDialog.FileName);
                    }

                    if (journal != null)
                    {
                        // Open the Archive Builder form
                        using var archiveForm = ActivatorUtilities.CreateInstance<ArchiveBuilderForm>(
                            Program.ServiceProvider, 
                            journal);
                        archiveForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка загрузки файла: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
        else if (result == DialogResult.No)
        {
            // Create empty journal
            var emptyJournal = new Journal
            {
                JournalInfo = new JournalInfo(),
                Issue = new Issue { Articles = new Articles() }
            };

            using var archiveForm = ActivatorUtilities.CreateInstance<ArchiveBuilderForm>(
                Program.ServiceProvider, 
                emptyJournal);
            archiveForm.ShowDialog();
        }
    }
}
