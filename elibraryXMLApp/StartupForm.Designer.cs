namespace elibraryXMLApp;

partial class StartupForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.menuStrip = new MenuStrip();
        this.fileMenu = new ToolStripMenuItem();
        this.saveJsonMenuItem = new ToolStripMenuItem();
        this.loadJsonMenuItem = new ToolStripMenuItem();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.exitMenuItem = new ToolStripMenuItem();
        this.toolsMenu = new ToolStripMenuItem();
        this.manualParserMenuItem = new ToolStripMenuItem();
        this.exportMenu = new ToolStripMenuItem();
        this.exportJatsMenuItem = new ToolStripMenuItem();
        this.exportJournal3MenuItem = new ToolStripMenuItem();
        this.helpMenu = new ToolStripMenuItem();
        this.aboutMenuItem = new ToolStripMenuItem();
        this.lblTitle = new Label();
        this.lblDescription = new Label();
        this.grpOption1 = new GroupBox();
        this.btnLoadDoajXml = new Button();
        this.lblOption1 = new Label();
        this.grpOption3 = new GroupBox();
        this.btnCreateEmpty = new Button();
        this.lblOption3 = new Label();
        this.grpOption4 = new GroupBox();
        this.btnRestoreJson = new Button();
        this.lblOption4 = new Label();
        this.btnPrepareArchive = new Button();
        this.menuStrip.SuspendLayout();
        this.grpOption1.SuspendLayout();
        this.grpOption3.SuspendLayout();
        this.grpOption4.SuspendLayout();
        this.SuspendLayout();
        
        // 
        // menuStrip
        // 
        this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.exportMenu,
            this.helpMenu});
        this.menuStrip.Location = new Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new Size(700, 24);
        this.menuStrip.TabIndex = 0;
        this.menuStrip.Text = "menuStrip";
        
        // 
        // fileMenu
        // 
        this.fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.saveJsonMenuItem,
            this.loadJsonMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
        this.fileMenu.Name = "fileMenu";
        this.fileMenu.Size = new Size(48, 20);
        this.fileMenu.Text = "Файл";
        
        // 
        // saveJsonMenuItem
        // 
        this.saveJsonMenuItem.Name = "saveJsonMenuItem";
        this.saveJsonMenuItem.Size = new Size(250, 22);
        this.saveJsonMenuItem.Text = "Сохранить резервную копию (JSON)";
        this.saveJsonMenuItem.Enabled = false;
        
        // 
        // loadJsonMenuItem
        // 
        this.loadJsonMenuItem.Name = "loadJsonMenuItem";
        this.loadJsonMenuItem.Size = new Size(250, 22);
        this.loadJsonMenuItem.Text = "Загрузить резервную копию (JSON)";
        this.loadJsonMenuItem.Enabled = false;
        
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(247, 6);
        
        // 
        // exitMenuItem
        // 
        this.exitMenuItem.Name = "exitMenuItem";
        this.exitMenuItem.Size = new Size(250, 22);
        this.exitMenuItem.Text = "Выход";
        this.exitMenuItem.Click += new EventHandler(this.exitMenuItem_Click);
        
        // 
        // toolsMenu
        // 
        this.toolsMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.manualParserMenuItem});
        this.toolsMenu.Name = "toolsMenu";
        this.toolsMenu.Size = new Size(95, 20);
        this.toolsMenu.Text = "Инструменты";
        this.toolsMenu.Enabled = false;
        
        // 
        // manualParserMenuItem
        // 
        this.manualParserMenuItem.Name = "manualParserMenuItem";
        this.manualParserMenuItem.Size = new Size(180, 22);
        this.manualParserMenuItem.Text = "Ручной парсер";
        
        // 
        // exportMenu
        // 
        this.exportMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.exportJatsMenuItem,
            this.exportJournal3MenuItem});
        this.exportMenu.Name = "exportMenu";
        this.exportMenu.Size = new Size(68, 20);
        this.exportMenu.Text = "Экспорт";
        this.exportMenu.Enabled = false;
        
        // 
        // exportJatsMenuItem
        // 
        this.exportJatsMenuItem.Name = "exportJatsMenuItem";
        this.exportJatsMenuItem.Size = new Size(180, 22);
        this.exportJatsMenuItem.Text = "JATS XML (по статьям)";
        
        // 
        // exportJournal3MenuItem
        // 
        this.exportJournal3MenuItem.Name = "exportJournal3MenuItem";
        this.exportJournal3MenuItem.Size = new Size(180, 22);
        this.exportJournal3MenuItem.Text = "journal3 XML";
        
        // 
        // helpMenu
        // 
        this.helpMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.aboutMenuItem});
        this.helpMenu.Name = "helpMenu";
        this.helpMenu.Size = new Size(68, 20);
        this.helpMenu.Text = "Помощь";
        
        // 
        // aboutMenuItem
        // 
        this.aboutMenuItem.Name = "aboutMenuItem";
        this.aboutMenuItem.Size = new Size(149, 22);
        this.aboutMenuItem.Text = "О программе";
        this.aboutMenuItem.Click += new EventHandler(this.aboutMenuItem_Click);
        
        // 
        // lblTitle
        // 
        this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblTitle.Location = new Point(20, 35);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(660, 30);
        this.lblTitle.TabIndex = 1;
        this.lblTitle.Text = "Универсальный редактор метаданных научных статей";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // lblDescription
        // 
        this.lblDescription.Location = new Point(20, 70);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new Size(660, 40);
        this.lblDescription.TabIndex = 2;
        this.lblDescription.Text = "Выберите способ начала работы:";
        this.lblDescription.TextAlign = ContentAlignment.TopCenter;
        
        // 
        // grpOption1
        // 
        this.grpOption1.Controls.Add(this.lblOption1);
        this.grpOption1.Controls.Add(this.btnLoadDoajXml);
        this.grpOption1.Location = new Point(20, 115);
        this.grpOption1.Name = "grpOption1";
        this.grpOption1.Size = new Size(660, 80);
        this.grpOption1.TabIndex = 3;
        this.grpOption1.TabStop = false;
        this.grpOption1.Text = "Вариант 1: Загрузить DOAJ XML";
        
        // 
        // lblOption1
        // 
        this.lblOption1.Location = new Point(10, 20);
        this.lblOption1.Name = "lblOption1";
        this.lblOption1.Size = new Size(450, 50);
        this.lblOption1.TabIndex = 0;
        this.lblOption1.Text = "Загрузите файл DOAJ XML или elibrary XML, чтобы автоматически извлечь метаданные статей.";
        
        // 
        // btnLoadDoajXml
        // 
        this.btnLoadDoajXml.Location = new Point(470, 25);
        this.btnLoadDoajXml.Name = "btnLoadDoajXml";
        this.btnLoadDoajXml.Size = new Size(180, 40);
        this.btnLoadDoajXml.TabIndex = 1;
        this.btnLoadDoajXml.Text = "Загрузить XML";
        this.btnLoadDoajXml.UseVisualStyleBackColor = true;
        this.btnLoadDoajXml.Click += new EventHandler(this.btnLoadDoajXml_Click);
        
        // 
        // grpOption3
        // 
        this.grpOption3.Controls.Add(this.lblOption3);
        this.grpOption3.Controls.Add(this.btnCreateEmpty);
        this.grpOption3.Location = new Point(20, 205);
        this.grpOption3.Name = "grpOption3";
        this.grpOption3.Size = new Size(660, 80);
        this.grpOption3.TabIndex = 4;
        this.grpOption3.TabStop = false;
        this.grpOption3.Text = "Вариант 2: Начать с нуля";
        
        // 
        // lblOption3
        // 
        this.lblOption3.Location = new Point(10, 20);
        this.lblOption3.Name = "lblOption3";
        this.lblOption3.Size = new Size(450, 50);
        this.lblOption3.TabIndex = 0;
        this.lblOption3.Text = "Создайте выпуск без загрузки файлов. Все метаданные нужно будет ввести вручную.";
        
        // 
        // btnCreateEmpty
        // 
        this.btnCreateEmpty.Location = new Point(470, 25);
        this.btnCreateEmpty.Name = "btnCreateEmpty";
        this.btnCreateEmpty.Size = new Size(180, 40);
        this.btnCreateEmpty.TabIndex = 1;
        this.btnCreateEmpty.Text = "Создать выпуск";
        this.btnCreateEmpty.UseVisualStyleBackColor = true;
        this.btnCreateEmpty.Click += new EventHandler(this.btnCreateEmpty_Click);
        
        // 
        // grpOption4
        // 
        this.grpOption4.Controls.Add(this.lblOption4);
        this.grpOption4.Controls.Add(this.btnRestoreJson);
        this.grpOption4.Location = new Point(20, 295);
        this.grpOption4.Name = "grpOption4";
        this.grpOption4.Size = new Size(660, 80);
        this.grpOption4.TabIndex = 5;
        this.grpOption4.TabStop = false;
        this.grpOption4.Text = "Вариант 3: Восстановить из резервной копии";
        
        // 
        // lblOption4
        // 
        this.lblOption4.Location = new Point(10, 20);
        this.lblOption4.Name = "lblOption4";
        this.lblOption4.Size = new Size(450, 50);
        this.lblOption4.TabIndex = 0;
        this.lblOption4.Text = "Загрузите ранее сохранённый JSON файл для восстановления работы.";
        
        // 
        // btnRestoreJson
        // 
        this.btnRestoreJson.Location = new Point(470, 25);
        this.btnRestoreJson.Name = "btnRestoreJson";
        this.btnRestoreJson.Size = new Size(180, 40);
        this.btnRestoreJson.TabIndex = 1;
        this.btnRestoreJson.Text = "Восстановить из JSON";
        this.btnRestoreJson.UseVisualStyleBackColor = true;
        this.btnRestoreJson.Click += new EventHandler(this.btnRestoreJson_Click);
        
        // 
        // btnPrepareArchive
        // 
        this.btnPrepareArchive.BackColor = Color.LightBlue;
        this.btnPrepareArchive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnPrepareArchive.Location = new Point(20, 385);
        this.btnPrepareArchive.Name = "btnPrepareArchive";
        this.btnPrepareArchive.Size = new Size(660, 50);
        this.btnPrepareArchive.TabIndex = 6;
        this.btnPrepareArchive.Text = "📦 Подготовка архива выпуска / Prepare Release Archive";
        this.btnPrepareArchive.UseVisualStyleBackColor = false;
        this.btnPrepareArchive.Click += new EventHandler(this.btnPrepareArchive_Click);
        
        // 
        // StartupForm
        // 
        this.ClientSize = new Size(700, 450);
        this.Controls.Add(this.btnPrepareArchive);
        this.Controls.Add(this.grpOption4);
        this.Controls.Add(this.grpOption3);
        this.Controls.Add(this.grpOption1);
        this.Controls.Add(this.lblDescription);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.menuStrip);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MainMenuStrip = this.menuStrip;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "StartupForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "elibraryXML - Редактор метаданных";
        
        // Set the form icon from embedded resource
        try
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = "elibraryXMLApp.ico.ico";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    this.Icon = new Icon(stream);
                }
            }
        }
        catch
        {
            // If icon loading fails, continue with default icon
        }
        
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.grpOption1.ResumeLayout(false);
        this.grpOption3.ResumeLayout(false);
        this.grpOption4.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem saveJsonMenuItem;
    private ToolStripMenuItem loadJsonMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitMenuItem;
    private ToolStripMenuItem toolsMenu;
    private ToolStripMenuItem manualParserMenuItem;
    private ToolStripMenuItem exportMenu;
    private ToolStripMenuItem exportJatsMenuItem;
    private ToolStripMenuItem exportJournal3MenuItem;
    private ToolStripMenuItem helpMenu;
    private ToolStripMenuItem aboutMenuItem;
    private Label lblTitle;
    private Label lblDescription;
    private GroupBox grpOption1;
    private Label lblOption1;
    private Button btnLoadDoajXml;
    private GroupBox grpOption3;
    private Label lblOption3;
    private Button btnCreateEmpty;
    private GroupBox grpOption4;
    private Label lblOption4;
    private Button btnRestoreJson;
    private Button btnPrepareArchive;
}
