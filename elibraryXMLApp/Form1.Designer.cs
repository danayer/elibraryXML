namespace elibraryXMLApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.tabControl = new TabControl();
        this.tabJournal = new TabPage();
        this.tabIssue = new TabPage();
        this.tabArticles = new TabPage();
        this.lblTitleId = new Label();
        this.txtTitleId = new TextBox();
        this.lblIssn = new Label();
        this.txtIssn = new TextBox();
        this.lblEissn = new Label();
        this.txtEissn = new TextBox();
        this.lblJournalTitle = new Label();
        this.txtJournalTitle = new TextBox();
        this.lblVolume = new Label();
        this.txtVolume = new TextBox();
        this.lblNumber = new Label();
        this.txtNumber = new TextBox();
        this.lblVolumeNumberNote = new Label();
        this.lblPages = new Label();
        this.txtPages = new TextBox();
        this.lblDateUni = new Label();
        this.txtDateUni = new TextBox();
        this.lblIssueType = new Label();
        this.cmbIssueType = new ComboBox();
        this.btnAddArticle = new Button();
        this.lstArticles = new ListBox();
        this.btnRemoveArticle = new Button();
        this.btnEditArticle = new Button();
        this.menuStrip = new MenuStrip();
        this.fileMenu = new ToolStripMenuItem();
        this.saveXmlMenuItem = new ToolStripMenuItem();
        this.loadXmlMenuItem = new ToolStripMenuItem();
        this.toolStripSeparator2 = new ToolStripSeparator();
        this.saveJsonMenuItem = new ToolStripMenuItem();
        this.loadJsonMenuItem = new ToolStripMenuItem();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.exitMenuItem = new ToolStripMenuItem();
        this.toolsMenu = new ToolStripMenuItem();
        this.manualParserMenuItem = new ToolStripMenuItem();
        this.archiveBuilderMenuItem = new ToolStripMenuItem();
        this.exportMenu = new ToolStripMenuItem();
        this.exportJatsMenuItem = new ToolStripMenuItem();
        this.exportJournal3MenuItem = new ToolStripMenuItem();
        this.helpMenu = new ToolStripMenuItem();
        this.aboutMenuItem = new ToolStripMenuItem();
        this.menuStrip.SuspendLayout();
        this.tabControl.SuspendLayout();
        this.tabJournal.SuspendLayout();
        this.tabIssue.SuspendLayout();
        this.tabArticles.SuspendLayout();
        this.SuspendLayout();
        // 
        // tabControl
        // 
        this.tabControl.Controls.Add(this.tabJournal);
        this.tabControl.Controls.Add(this.tabIssue);
        this.tabControl.Controls.Add(this.tabArticles);
        this.tabControl.Dock = DockStyle.Fill;
        this.tabControl.Location = new Point(0, 24);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new Size(800, 426);
        this.tabControl.TabIndex = 0;
        // 
        // tabJournal
        // 
        this.tabJournal.Controls.Add(this.txtJournalTitle);
        this.tabJournal.Controls.Add(this.lblJournalTitle);
        this.tabJournal.Controls.Add(this.txtEissn);
        this.tabJournal.Controls.Add(this.lblEissn);
        this.tabJournal.Controls.Add(this.txtIssn);
        this.tabJournal.Controls.Add(this.lblIssn);
        this.tabJournal.Controls.Add(this.txtTitleId);
        this.tabJournal.Controls.Add(this.lblTitleId);
        this.tabJournal.Location = new Point(4, 24);
        this.tabJournal.Name = "tabJournal";
        this.tabJournal.Padding = new Padding(3);
        this.tabJournal.Size = new Size(792, 398);
        this.tabJournal.TabIndex = 0;
        this.tabJournal.Text = "Журнал";
        this.tabJournal.UseVisualStyleBackColor = true;
        // 
        // tabIssue
        // 
        this.tabIssue.Controls.Add(this.cmbIssueType);
        this.tabIssue.Controls.Add(this.lblIssueType);
        this.tabIssue.Controls.Add(this.txtDateUni);
        this.tabIssue.Controls.Add(this.lblDateUni);
        this.tabIssue.Controls.Add(this.txtPages);
        this.tabIssue.Controls.Add(this.lblPages);
        this.tabIssue.Controls.Add(this.lblVolumeNumberNote);
        this.tabIssue.Controls.Add(this.txtNumber);
        this.tabIssue.Controls.Add(this.lblNumber);
        this.tabIssue.Controls.Add(this.txtVolume);
        this.tabIssue.Controls.Add(this.lblVolume);
        this.tabIssue.Location = new Point(4, 24);
        this.tabIssue.Name = "tabIssue";
        this.tabIssue.Padding = new Padding(3);
        this.tabIssue.Size = new Size(792, 398);
        this.tabIssue.TabIndex = 1;
        this.tabIssue.Text = "Выпуск";
        this.tabIssue.UseVisualStyleBackColor = true;
        // 
        // tabArticles
        // 
        this.tabArticles.Controls.Add(this.btnEditArticle);
        this.tabArticles.Controls.Add(this.btnRemoveArticle);
        this.tabArticles.Controls.Add(this.lstArticles);
        this.tabArticles.Controls.Add(this.btnAddArticle);
        this.tabArticles.Location = new Point(4, 24);
        this.tabArticles.Name = "tabArticles";
        this.tabArticles.Size = new Size(792, 398);
        this.tabArticles.TabIndex = 2;
        this.tabArticles.Text = "Статьи";
        this.tabArticles.UseVisualStyleBackColor = true;
        // 
        // lblTitleId
        // 
        this.lblTitleId.AutoSize = true;
        this.lblTitleId.Location = new Point(20, 20);
        this.lblTitleId.Name = "lblTitleId";
        this.lblTitleId.Size = new Size(140, 15);
        this.lblTitleId.TabIndex = 0;
        this.lblTitleId.Text = "ID журнала (titleid): *";
        // 
        // txtTitleId
        // 
        this.txtTitleId.Location = new Point(180, 17);
        this.txtTitleId.Name = "txtTitleId";
        this.txtTitleId.Size = new Size(200, 23);
        this.txtTitleId.TabIndex = 1;
        // 
        // lblIssn
        // 
        this.lblIssn.AutoSize = true;
        this.lblIssn.Location = new Point(20, 60);
        this.lblIssn.Name = "lblIssn";
        this.lblIssn.Size = new Size(40, 15);
        this.lblIssn.TabIndex = 2;
        this.lblIssn.Text = "ISSN:";
        // 
        // txtIssn
        // 
        this.txtIssn.Location = new Point(180, 57);
        this.txtIssn.Name = "txtIssn";
        this.txtIssn.Size = new Size(200, 23);
        this.txtIssn.TabIndex = 3;
        // 
        // lblEissn
        // 
        this.lblEissn.AutoSize = true;
        this.lblEissn.Location = new Point(20, 100);
        this.lblEissn.Name = "lblEissn";
        this.lblEissn.Size = new Size(47, 15);
        this.lblEissn.TabIndex = 4;
        this.lblEissn.Text = "eISSN:";
        // 
        // txtEissn
        // 
        this.txtEissn.Location = new Point(180, 97);
        this.txtEissn.Name = "txtEissn";
        this.txtEissn.Size = new Size(200, 23);
        this.txtEissn.TabIndex = 5;
        // 
        // lblJournalTitle
        // 
        this.lblJournalTitle.AutoSize = true;
        this.lblJournalTitle.Location = new Point(20, 140);
        this.lblJournalTitle.Name = "lblJournalTitle";
        this.lblJournalTitle.Size = new Size(122, 15);
        this.lblJournalTitle.TabIndex = 6;
        this.lblJournalTitle.Text = "Название журнала: *";
        // 
        // txtJournalTitle
        // 
        this.txtJournalTitle.Location = new Point(180, 137);
        this.txtJournalTitle.Name = "txtJournalTitle";
        this.txtJournalTitle.Size = new Size(400, 23);
        this.txtJournalTitle.TabIndex = 7;
        // 
        // lblVolume
        // 
        this.lblVolume.AutoSize = true;
        this.lblVolume.Location = new Point(20, 20);
        this.lblVolume.Name = "lblVolume";
        this.lblVolume.Size = new Size(35, 15);
        this.lblVolume.TabIndex = 0;
        this.lblVolume.Text = "Том:";
        // 
        // txtVolume
        // 
        this.txtVolume.Location = new Point(180, 17);
        this.txtVolume.Name = "txtVolume";
        this.txtVolume.Size = new Size(200, 23);
        this.txtVolume.TabIndex = 1;
        // 
        // lblNumber
        // 
        this.lblNumber.AutoSize = true;
        this.lblNumber.Location = new Point(20, 60);
        this.lblNumber.Name = "lblNumber";
        this.lblNumber.Size = new Size(51, 15);
        this.lblNumber.TabIndex = 2;
        this.lblNumber.Text = "Номер:";
        // 
        // txtNumber
        // 
        this.txtNumber.Location = new Point(180, 57);
        this.txtNumber.Name = "txtNumber";
        this.txtNumber.Size = new Size(200, 23);
        this.txtNumber.TabIndex = 3;
        // 
        // lblVolumeNumberNote
        // 
        this.lblVolumeNumberNote.AutoSize = true;
        this.lblVolumeNumberNote.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
        this.lblVolumeNumberNote.ForeColor = SystemColors.GrayText;
        this.lblVolumeNumberNote.Location = new Point(390, 40);
        this.lblVolumeNumberNote.Name = "lblVolumeNumberNote";
        this.lblVolumeNumberNote.Size = new Size(200, 13);
        this.lblVolumeNumberNote.TabIndex = 8;
        this.lblVolumeNumberNote.Text = "* Обязательно Том или Номер";
        // 
        // lblPages
        // 
        this.lblPages.AutoSize = true;
        this.lblPages.Location = new Point(20, 100);
        this.lblPages.Name = "lblPages";
        this.lblPages.Size = new Size(71, 15);
        this.lblPages.TabIndex = 4;
        this.lblPages.Text = "Страницы:";
        // 
        // txtPages
        // 
        this.txtPages.Location = new Point(180, 97);
        this.txtPages.Name = "txtPages";
        this.txtPages.Size = new Size(200, 23);
        this.txtPages.TabIndex = 5;
        // 
        // lblDateUni
        // 
        this.lblDateUni.AutoSize = true;
        this.lblDateUni.Location = new Point(20, 140);
        this.lblDateUni.Name = "lblDateUni";
        this.lblDateUni.Size = new Size(85, 15);
        this.lblDateUni.TabIndex = 6;
        this.lblDateUni.Text = "Год издания: *";
        // 
        // txtDateUni
        // 
        this.txtDateUni.Location = new Point(180, 137);
        this.txtDateUni.Name = "txtDateUni";
        this.txtDateUni.Size = new Size(200, 23);
        this.txtDateUni.TabIndex = 7;
        // 
        // lblIssueType
        // 
        this.lblIssueType.AutoSize = true;
        this.lblIssueType.Location = new Point(20, 180);
        this.lblIssueType.Name = "lblIssueType";
        this.lblIssueType.Size = new Size(84, 15);
        this.lblIssueType.TabIndex = 8;
        this.lblIssueType.Text = "Тип выпуска:";
        // 
        // cmbIssueType
        // 
        this.cmbIssueType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbIssueType.FormattingEnabled = true;
        this.cmbIssueType.Items.AddRange(new object[] {
            "ISS - Выпуск журнала",
            "OFI - Выпуск Online First",
            "SPI - Спец.выпуск"});
        this.cmbIssueType.Location = new Point(180, 177);
        this.cmbIssueType.Name = "cmbIssueType";
        this.cmbIssueType.Size = new Size(300, 23);
        this.cmbIssueType.TabIndex = 9;
        // 
        // btnAddArticle
        // 
        this.btnAddArticle.Location = new Point(20, 20);
        this.btnAddArticle.Name = "btnAddArticle";
        this.btnAddArticle.Size = new Size(120, 30);
        this.btnAddArticle.TabIndex = 0;
        this.btnAddArticle.Text = "Добавить статью";
        this.btnAddArticle.UseVisualStyleBackColor = true;
        this.btnAddArticle.Click += new EventHandler(this.btnAddArticle_Click);
        // 
        // lstArticles
        // 
        this.lstArticles.FormattingEnabled = true;
        this.lstArticles.ItemHeight = 15;
        this.lstArticles.Location = new Point(20, 60);
        this.lstArticles.Name = "lstArticles";
        this.lstArticles.Size = new Size(750, 319);
        this.lstArticles.TabIndex = 1;
        // 
        // btnRemoveArticle
        // 
        this.btnRemoveArticle.Location = new Point(270, 20);
        this.btnRemoveArticle.Name = "btnRemoveArticle";
        this.btnRemoveArticle.Size = new Size(120, 30);
        this.btnRemoveArticle.TabIndex = 2;
        this.btnRemoveArticle.Text = "Удалить";
        this.btnRemoveArticle.UseVisualStyleBackColor = true;
        this.btnRemoveArticle.Click += new EventHandler(this.btnRemoveArticle_Click);
        // 
        // fileMenu
        // 
        this.fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.saveXmlMenuItem,
            this.loadXmlMenuItem,
            this.toolStripSeparator2,
            this.saveJsonMenuItem,
            this.loadJsonMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
        this.fileMenu.Name = "fileMenu";
        this.fileMenu.Size = new Size(48, 20);
        this.fileMenu.Text = "Файл";
        // 
        // saveXmlMenuItem
        // 
        this.saveXmlMenuItem.Name = "saveXmlMenuItem";
        this.saveXmlMenuItem.Size = new Size(280, 22);
        this.saveXmlMenuItem.Text = "Сохранить XML";
        this.saveXmlMenuItem.Click += new EventHandler(this.btnSaveXml_Click);
        // 
        // loadXmlMenuItem
        // 
        this.loadXmlMenuItem.Name = "loadXmlMenuItem";
        this.loadXmlMenuItem.Size = new Size(280, 22);
        this.loadXmlMenuItem.Text = "Загрузить XML";
        this.loadXmlMenuItem.Click += new EventHandler(this.btnLoadXml_Click);
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new Size(277, 6);
        // 
        // saveJsonMenuItem
        // 
        this.saveJsonMenuItem.Name = "saveJsonMenuItem";
        this.saveJsonMenuItem.Size = new Size(280, 22);
        this.saveJsonMenuItem.Text = "Сохранить резервную копию (JSON)";
        this.saveJsonMenuItem.Click += new EventHandler(this.saveJsonMenuItem_Click);
        // 
        // loadJsonMenuItem
        // 
        this.loadJsonMenuItem.Name = "loadJsonMenuItem";
        this.loadJsonMenuItem.Size = new Size(280, 22);
        this.loadJsonMenuItem.Text = "Загрузить резервную копию (JSON)";
        this.loadJsonMenuItem.Click += new EventHandler(this.loadJsonMenuItem_Click);
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new Size(277, 6);
        // 
        // exitMenuItem
        // 
        this.exitMenuItem.Name = "exitMenuItem";
        this.exitMenuItem.Size = new Size(280, 22);
        this.exitMenuItem.Text = "Выход";
        this.exitMenuItem.Click += new EventHandler(this.exitMenuItem_Click);
        // 
        // btnEditArticle
        // 
        this.btnEditArticle.Location = new Point(145, 20);
        this.btnEditArticle.Name = "btnEditArticle";
        this.btnEditArticle.Size = new Size(120, 30);
        this.btnEditArticle.TabIndex = 3;
        this.btnEditArticle.Text = "Редактировать";
        this.btnEditArticle.UseVisualStyleBackColor = true;
        this.btnEditArticle.Click += new EventHandler(this.btnEditArticle_Click);
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
        this.menuStrip.Size = new Size(800, 24);
        this.menuStrip.TabIndex = 3;
        this.menuStrip.Text = "menuStrip1";
        // 
        // exportMenu
        // 
        this.exportMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.exportJatsMenuItem,
            this.exportJournal3MenuItem});
        this.exportMenu.Name = "exportMenu";
        this.exportMenu.Size = new Size(68, 20);
        this.exportMenu.Text = "Экспорт";
        // 
        // exportJatsMenuItem
        // 
        this.exportJatsMenuItem.Name = "exportJatsMenuItem";
        this.exportJatsMenuItem.Size = new Size(180, 22);
        this.exportJatsMenuItem.Text = "JATS XML (по статьям)";
        this.exportJatsMenuItem.Click += new EventHandler(this.exportJatsMenuItem_Click);
        // 
        // exportJournal3MenuItem
        // 
        this.exportJournal3MenuItem.Name = "exportJournal3MenuItem";
        this.exportJournal3MenuItem.Size = new Size(180, 22);
        this.exportJournal3MenuItem.Text = "journal3 XML";
        this.exportJournal3MenuItem.Click += new EventHandler(this.exportJournal3MenuItem_Click);
        // 
        // toolsMenu
        // 
        this.toolsMenu.DropDownItems.AddRange(new ToolStripItem[] {
            this.manualParserMenuItem,
            this.archiveBuilderMenuItem});
        this.toolsMenu.Name = "toolsMenu";
        this.toolsMenu.Size = new Size(95, 20);
        this.toolsMenu.Text = "Инструменты";
        // 
        // manualParserMenuItem
        // 
        this.manualParserMenuItem.Name = "manualParserMenuItem";
        this.manualParserMenuItem.Size = new Size(200, 22);
        this.manualParserMenuItem.Text = "Ручной парсер";
        this.manualParserMenuItem.Click += new EventHandler(this.manualParserMenuItem_Click);
        // 
        // archiveBuilderMenuItem
        // 
        this.archiveBuilderMenuItem.Name = "archiveBuilderMenuItem";
        this.archiveBuilderMenuItem.Size = new Size(200, 22);
        this.archiveBuilderMenuItem.Text = "Архив выпуска";
        this.archiveBuilderMenuItem.Click += new EventHandler(this.archiveBuilderMenuItem_Click);
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
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.tabControl);
        this.Controls.Add(this.menuStrip);
        this.MainMenuStrip = this.menuStrip;
        this.Name = "Form1";
        this.Text = "eLibrary XML Editor";
        
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
        this.tabControl.ResumeLayout(false);
        this.tabJournal.ResumeLayout(false);
        this.tabJournal.PerformLayout();
        this.tabIssue.ResumeLayout(false);
        this.tabIssue.PerformLayout();
        this.tabArticles.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private TabControl tabControl;
    private TabPage tabJournal;
    private TabPage tabIssue;
    private TabPage tabArticles;
    private Label lblTitleId;
    private TextBox txtTitleId;
    private Label lblIssn;
    private TextBox txtIssn;
    private Label lblEissn;
    private TextBox txtEissn;
    private Label lblJournalTitle;
    private TextBox txtJournalTitle;
    private Label lblVolume;
    private TextBox txtVolume;
    private Label lblNumber;
    private TextBox txtNumber;
    private Label lblVolumeNumberNote;
    private Label lblPages;
    private TextBox txtPages;
    private Label lblDateUni;
    private TextBox txtDateUni;
    private Label lblIssueType;
    private ComboBox cmbIssueType;
    private Button btnAddArticle;
    private ListBox lstArticles;
    private Button btnRemoveArticle;
    private Button btnEditArticle;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem saveXmlMenuItem;
    private ToolStripMenuItem loadXmlMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem saveJsonMenuItem;
    private ToolStripMenuItem loadJsonMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitMenuItem;
    private ToolStripMenuItem toolsMenu;
    private ToolStripMenuItem manualParserMenuItem;
    private ToolStripMenuItem archiveBuilderMenuItem;
    private ToolStripMenuItem exportMenu;
    private ToolStripMenuItem exportJatsMenuItem;
    private ToolStripMenuItem exportJournal3MenuItem;
    private ToolStripMenuItem helpMenu;
    private ToolStripMenuItem aboutMenuItem;
}
