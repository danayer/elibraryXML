namespace elibraryXMLApp;

partial class ArticleForm
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

    private void InitializeComponent()
    {
        this.lblPages = new Label();
        this.txtPages = new TextBox();
        this.lblArticleType = new Label();
        this.cmbArticleType = new ComboBox();
        this.lblTitleRus = new Label();
        this.txtTitleRus = new TextBox();
        this.lblTitleEng = new Label();
        this.txtTitleEng = new TextBox();
        this.lblTitleNote = new Label();
        this.lblAbstractRus = new Label();
        this.txtAbstractRus = new TextBox();
        this.lblAbstractEng = new Label();
        this.txtAbstractEng = new TextBox();
        this.lblDoi = new Label();
        this.txtDoi = new TextBox();
        this.lblEdn = new Label();
        this.txtEdn = new TextBox();
        this.lblDateReceived = new Label();
        this.txtDateReceived = new TextBox();
        this.lblDateAccepted = new Label();
        this.txtDateAccepted = new TextBox();
        this.lblDatePublication = new Label();
        this.txtDatePublication = new TextBox();
        this.lblFunding = new Label();
        this.txtFunding = new TextBox();
        this.lblKeywordsRus = new Label();
        this.txtKeywordsRus = new TextBox();
        this.lblKeywordsEng = new Label();
        this.txtKeywordsEng = new TextBox();
        this.lblBbk = new Label();
        this.txtBbk = new TextBox();
        this.lblVak = new Label();
        this.txtVak = new TextBox();
        this.lblJel = new Label();
        this.txtJel = new TextBox();
        this.lblMsc = new Label();
        this.txtMsc = new TextBox();
        this.lblPacs = new Label();
        this.txtPacs = new TextBox();
        this.lblFiles = new Label();
        this.tabControlFiles = new TabControl();
        this.tabPageFile = new TabPage();
        this.txtFilePath = new TextBox();
        this.lblFilePath = new Label();
        this.cmbFileType = new ComboBox();
        this.lblFileType = new Label();
        this.cmbFileLang = new ComboBox();
        this.lblFileLang = new Label();
        this.btnAddFile = new Button();
        this.tabPageUrl = new TabPage();
        this.txtUrlPath = new TextBox();
        this.lblUrlPath = new Label();
        this.cmbUrlType = new ComboBox();
        this.lblUrlType = new Label();
        this.cmbUrlLang = new ComboBox();
        this.lblUrlLang = new Label();
        this.btnAddUrl = new Button();
        this.tabPageArticleText = new TabPage();
        this.txtArticleTextContent = new TextBox();
        this.lblArticleTextContent = new Label();
        this.cmbArticleTextLang = new ComboBox();
        this.lblArticleTextLang = new Label();
        this.btnSetArticleText = new Button();
        this.lstFilesUrls = new ListBox();
        this.btnEditFileUrl = new Button();
        this.btnRemoveFileUrl = new Button();
        this.grpAuthors = new GroupBox();
        this.lstAuthors = new ListBox();
        this.btnAddAuthor = new Button();
        this.btnEditAuthor = new Button();
        this.btnRemoveAuthor = new Button();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.grpAuthors.SuspendLayout();
        this.tabControlFiles.SuspendLayout();
        this.tabPageFile.SuspendLayout();
        this.tabPageUrl.SuspendLayout();
        this.tabPageArticleText.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblPages
        // 
        this.lblPages.AutoSize = true;
        this.lblPages.Location = new Point(20, 20);
        this.lblPages.Name = "lblPages";
        this.lblPages.Size = new Size(71, 15);
        this.lblPages.TabIndex = 0;
        this.lblPages.Text = "Страницы: *";
        // 
        // txtPages
        // 
        this.txtPages.Location = new Point(150, 17);
        this.txtPages.Name = "txtPages";
        this.txtPages.Size = new Size(200, 23);
        this.txtPages.TabIndex = 1;
        // 
        // lblArticleType
        // 
        this.lblArticleType.AutoSize = true;
        this.lblArticleType.Location = new Point(20, 60);
        this.lblArticleType.Name = "lblArticleType";
        this.lblArticleType.Size = new Size(76, 15);
        this.lblArticleType.TabIndex = 2;
        this.lblArticleType.Text = "Тип статьи: *";
        // 
        // cmbArticleType
        // 
        this.cmbArticleType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbArticleType.FormattingEnabled = true;
        this.cmbArticleType.Items.AddRange(new object[] {
            "RAR - Научная статья",
            "ABS - Аннотация",
            "BRV - Рецензия",
            "CNF - Материалы конференции",
            "COR - Переписка",
            "EDI - Редакторская заметка",
            "MIS - Разное",
            "PER - Персоналия",
            "REP - Научный отчёт",
            "REV - Обзорная статья",
            "RPR - Репринт",
            "SCO - Краткое сообщение",
            "UNK - Не определён"});
        this.cmbArticleType.Location = new Point(150, 57);
        this.cmbArticleType.Name = "cmbArticleType";
        this.cmbArticleType.Size = new Size(300, 23);
        this.cmbArticleType.TabIndex = 3;
        // 
        // lblTitleRus
        // 
        this.lblTitleRus.AutoSize = true;
        this.lblTitleRus.Location = new Point(20, 100);
        this.lblTitleRus.Name = "lblTitleRus";
        this.lblTitleRus.Size = new Size(105, 15);
        this.lblTitleRus.TabIndex = 4;
        this.lblTitleRus.Text = "Название (РУС): *";
        // 
        // txtTitleRus
        // 
        this.txtTitleRus.Location = new Point(150, 97);
        this.txtTitleRus.Multiline = true;
        this.txtTitleRus.Name = "txtTitleRus";
        this.txtTitleRus.Size = new Size(450, 60);
        this.txtTitleRus.TabIndex = 5;
        // 
        // lblTitleEng
        // 
        this.lblTitleEng.AutoSize = true;
        this.lblTitleEng.Location = new Point(20, 170);
        this.lblTitleEng.Name = "lblTitleEng";
        this.lblTitleEng.Size = new Size(106, 15);
        this.lblTitleEng.TabIndex = 6;
        this.lblTitleEng.Text = "Название (ENG): *";
        // 
        // txtTitleEng
        // 
        this.txtTitleEng.Location = new Point(150, 167);
        this.txtTitleEng.Multiline = true;
        this.txtTitleEng.Name = "txtTitleEng";
        this.txtTitleEng.Size = new Size(450, 60);
        this.txtTitleEng.TabIndex = 7;
        // 
        // lblTitleNote
        // 
        this.lblTitleNote.AutoSize = true;
        this.lblTitleNote.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
        this.lblTitleNote.ForeColor = SystemColors.GrayText;
        this.lblTitleNote.Location = new Point(150, 230);
        this.lblTitleNote.Name = "lblTitleNote";
        this.lblTitleNote.Size = new Size(250, 13);
        this.lblTitleNote.TabIndex = 43;
        this.lblTitleNote.Text = "* Обязательно хотя бы одно название";
        // 
        // lblAbstractRus
        // 
        this.lblAbstractRus.AutoSize = true;
        this.lblAbstractRus.Location = new Point(20, 250);
        this.lblAbstractRus.Name = "lblAbstractRus";
        this.lblAbstractRus.Size = new Size(103, 15);
        this.lblAbstractRus.TabIndex = 8;
        this.lblAbstractRus.Text = "Аннотация (РУС):";
        // 
        // txtAbstractRus
        // 
        this.txtAbstractRus.Location = new Point(150, 247);
        this.txtAbstractRus.Multiline = true;
        this.txtAbstractRus.Name = "txtAbstractRus";
        this.txtAbstractRus.ScrollBars = ScrollBars.Vertical;
        this.txtAbstractRus.Size = new Size(450, 80);
        this.txtAbstractRus.TabIndex = 9;
        // 
        // lblAbstractEng
        // 
        this.lblAbstractEng.AutoSize = true;
        this.lblAbstractEng.Location = new Point(20, 330);
        this.lblAbstractEng.Name = "lblAbstractEng";
        this.lblAbstractEng.Size = new Size(104, 15);
        this.lblAbstractEng.TabIndex = 10;
        this.lblAbstractEng.Text = "Аннотация (ENG):";
        // 
        // txtAbstractEng
        // 
        this.txtAbstractEng.Location = new Point(150, 327);
        this.txtAbstractEng.Multiline = true;
        this.txtAbstractEng.Name = "txtAbstractEng";
        this.txtAbstractEng.ScrollBars = ScrollBars.Vertical;
        this.txtAbstractEng.Size = new Size(450, 80);
        this.txtAbstractEng.TabIndex = 11;
        // 
        // lblDoi
        // 
        this.lblDoi.AutoSize = true;
        this.lblDoi.Location = new Point(20, 420);
        this.lblDoi.Name = "lblDoi";
        this.lblDoi.Size = new Size(32, 15);
        this.lblDoi.TabIndex = 12;
        this.lblDoi.Text = "DOI:";
        // 
        // txtDoi
        // 
        this.txtDoi.Location = new Point(150, 417);
        this.txtDoi.Name = "txtDoi";
        this.txtDoi.Size = new Size(450, 23);
        this.txtDoi.TabIndex = 13;
        // 
        // lblEdn
        // 
        this.lblEdn.AutoSize = true;
        this.lblEdn.Location = new Point(20, 450);
        this.lblEdn.Name = "lblEdn";
        this.lblEdn.Size = new Size(35, 15);
        this.lblEdn.TabIndex = 14;
        this.lblEdn.Text = "EDN:";
        // 
        // txtEdn
        // 
        this.txtEdn.Location = new Point(150, 447);
        this.txtEdn.Name = "txtEdn";
        this.txtEdn.Size = new Size(450, 23);
        this.txtEdn.TabIndex = 15;
        // 
        // lblDateReceived
        // 
        this.lblDateReceived.AutoSize = true;
        this.lblDateReceived.Location = new Point(20, 590);
        this.lblDateReceived.Name = "lblDateReceived";
        this.lblDateReceived.Size = new Size(100, 15);
        this.lblDateReceived.TabIndex = 18;
        this.lblDateReceived.Text = "Дата получения:";
        // 
        // txtDateReceived
        // 
        this.txtDateReceived.Location = new Point(150, 587);
        this.txtDateReceived.Name = "txtDateReceived";
        this.txtDateReceived.Size = new Size(150, 23);
        this.txtDateReceived.TabIndex = 19;
        this.txtDateReceived.PlaceholderText = "дд.мм.гггг";
        // 
        // lblDateAccepted
        // 
        this.lblDateAccepted.AutoSize = true;
        this.lblDateAccepted.Location = new Point(320, 590);
        this.lblDateAccepted.Name = "lblDateAccepted";
        this.lblDateAccepted.Size = new Size(90, 15);
        this.lblDateAccepted.TabIndex = 20;
        this.lblDateAccepted.Text = "Дата принятия:";
        // 
        // txtDateAccepted
        // 
        this.txtDateAccepted.Location = new Point(420, 587);
        this.txtDateAccepted.Name = "txtDateAccepted";
        this.txtDateAccepted.Size = new Size(150, 23);
        this.txtDateAccepted.TabIndex = 21;
        this.txtDateAccepted.PlaceholderText = "дд.мм.гггг";
        // 
        // lblDatePublication
        // 
        this.lblDatePublication.AutoSize = true;
        this.lblDatePublication.Location = new Point(20, 620);
        this.lblDatePublication.Name = "lblDatePublication";
        this.lblDatePublication.Size = new Size(100, 15);
        this.lblDatePublication.TabIndex = 22;
        this.lblDatePublication.Text = "Дата публикации:";
        // 
        // txtDatePublication
        // 
        this.txtDatePublication.Location = new Point(150, 617);
        this.txtDatePublication.Name = "txtDatePublication";
        this.txtDatePublication.Size = new Size(150, 23);
        this.txtDatePublication.TabIndex = 23;
        this.txtDatePublication.PlaceholderText = "дд.мм.гггг";
        // 
        // lblFunding
        // 
        this.lblFunding.AutoSize = true;
        this.lblFunding.Location = new Point(20, 650);
        this.lblFunding.Name = "lblFunding";
        this.lblFunding.Size = new Size(100, 15);
        this.lblFunding.TabIndex = 24;
        this.lblFunding.Text = "Финансирование:";
        // 
        // txtFunding
        // 
        this.txtFunding.Location = new Point(150, 647);
        this.txtFunding.Multiline = true;
        this.txtFunding.Name = "txtFunding";
        this.txtFunding.Size = new Size(420, 60);
        this.txtFunding.TabIndex = 25;
        // 
        // lblKeywordsRus
        // 
        this.lblKeywordsRus.AutoSize = true;
        this.lblKeywordsRus.Location = new Point(20, 720);
        this.lblKeywordsRus.Name = "lblKeywordsRus";
        this.lblKeywordsRus.Size = new Size(120, 15);
        this.lblKeywordsRus.TabIndex = 26;
        this.lblKeywordsRus.Text = "Ключевые слова (RUS):";
        // 
        // txtKeywordsRus
        // 
        this.txtKeywordsRus.Location = new Point(150, 717);
        this.txtKeywordsRus.Multiline = true;
        this.txtKeywordsRus.Name = "txtKeywordsRus";
        this.txtKeywordsRus.Size = new Size(420, 60);
        this.txtKeywordsRus.TabIndex = 27;
        this.txtKeywordsRus.PlaceholderText = "Введите ключевые слова через запятую";
        // 
        // lblKeywordsEng
        // 
        this.lblKeywordsEng.AutoSize = true;
        this.lblKeywordsEng.Location = new Point(20, 790);
        this.lblKeywordsEng.Name = "lblKeywordsEng";
        this.lblKeywordsEng.Size = new Size(120, 15);
        this.lblKeywordsEng.TabIndex = 28;
        this.lblKeywordsEng.Text = "Keywords (ENG):";
        // 
        // txtKeywordsEng
        // 
        this.txtKeywordsEng.Location = new Point(150, 787);
        this.txtKeywordsEng.Multiline = true;
        this.txtKeywordsEng.Name = "txtKeywordsEng";
        this.txtKeywordsEng.Size = new Size(420, 60);
        this.txtKeywordsEng.TabIndex = 29;
        this.txtKeywordsEng.PlaceholderText = "Enter keywords separated by comma";
        // 
        // lblBbk
        // 
        this.lblBbk.AutoSize = true;
        this.lblBbk.Location = new Point(20, 860);
        this.lblBbk.Name = "lblBbk";
        this.lblBbk.Size = new Size(35, 15);
        this.lblBbk.TabIndex = 30;
        this.lblBbk.Text = "ББК:";
        // 
        // txtBbk
        // 
        this.txtBbk.Location = new Point(150, 857);
        this.txtBbk.Name = "txtBbk";
        this.txtBbk.Size = new Size(150, 23);
        this.txtBbk.TabIndex = 31;
        // 
        // lblVak
        // 
        this.lblVak.AutoSize = true;
        this.lblVak.Location = new Point(320, 860);
        this.lblVak.Name = "lblVak";
        this.lblVak.Size = new Size(35, 15);
        this.lblVak.TabIndex = 32;
        this.lblVak.Text = "ВАК:";
        // 
        // txtVak
        // 
        this.txtVak.Location = new Point(420, 857);
        this.txtVak.Name = "txtVak";
        this.txtVak.Size = new Size(150, 23);
        this.txtVak.TabIndex = 33;
        // 
        // lblJel
        // 
        this.lblJel.AutoSize = true;
        this.lblJel.Location = new Point(20, 890);
        this.lblJel.Name = "lblJel";
        this.lblJel.Size = new Size(30, 15);
        this.lblJel.TabIndex = 34;
        this.lblJel.Text = "JEL:";
        // 
        // txtJel
        // 
        this.txtJel.Location = new Point(150, 887);
        this.txtJel.Name = "txtJel";
        this.txtJel.Size = new Size(150, 23);
        this.txtJel.TabIndex = 35;
        // 
        // lblMsc
        // 
        this.lblMsc.AutoSize = true;
        this.lblMsc.Location = new Point(320, 890);
        this.lblMsc.Name = "lblMsc";
        this.lblMsc.Size = new Size(37, 15);
        this.lblMsc.TabIndex = 36;
        this.lblMsc.Text = "MSC:";
        // 
        // txtMsc
        // 
        this.txtMsc.Location = new Point(420, 887);
        this.txtMsc.Name = "txtMsc";
        this.txtMsc.Size = new Size(150, 23);
        this.txtMsc.TabIndex = 37;
        // 
        // lblPacs
        // 
        this.lblPacs.AutoSize = true;
        this.lblPacs.Location = new Point(20, 920);
        this.lblPacs.Name = "lblPacs";
        this.lblPacs.Size = new Size(40, 15);
        this.lblPacs.TabIndex = 38;
        this.lblPacs.Text = "PACS:";
        // 
        // txtPacs
        // 
        this.txtPacs.Location = new Point(150, 917);
        this.txtPacs.Name = "txtPacs";
        this.txtPacs.Size = new Size(150, 23);
        this.txtPacs.TabIndex = 39;
        // 
        // lblFiles
        // 
        this.lblFiles.AutoSize = true;
        this.lblFiles.Location = new Point(20, 950);
        this.lblFiles.Name = "lblFiles";
        this.lblFiles.Size = new Size(120, 15);
        this.lblFiles.TabIndex = 40;
        this.lblFiles.Text = "Файлы/URL/Текст:";
        // 
        // tabControlFiles
        // 
        this.tabControlFiles.Controls.Add(this.tabPageFile);
        this.tabControlFiles.Controls.Add(this.tabPageUrl);
        this.tabControlFiles.Controls.Add(this.tabPageArticleText);
        this.tabControlFiles.Location = new Point(150, 950);
        this.tabControlFiles.Name = "tabControlFiles";
        this.tabControlFiles.SelectedIndex = 0;
        this.tabControlFiles.Size = new Size(450, 180);
        this.tabControlFiles.TabIndex = 41;
        // 
        // tabPageFile
        // 
        this.tabPageFile.Controls.Add(this.btnAddFile);
        this.tabPageFile.Controls.Add(this.cmbFileLang);
        this.tabPageFile.Controls.Add(this.lblFileLang);
        this.tabPageFile.Controls.Add(this.cmbFileType);
        this.tabPageFile.Controls.Add(this.lblFileType);
        this.tabPageFile.Controls.Add(this.txtFilePath);
        this.tabPageFile.Controls.Add(this.lblFilePath);
        this.tabPageFile.Location = new Point(4, 24);
        this.tabPageFile.Name = "tabPageFile";
        this.tabPageFile.Padding = new Padding(3);
        this.tabPageFile.Size = new Size(442, 152);
        this.tabPageFile.TabIndex = 0;
        this.tabPageFile.Text = "Файл / File";
        this.tabPageFile.UseVisualStyleBackColor = true;
        // 
        // lblFilePath
        // 
        this.lblFilePath.AutoSize = true;
        this.lblFilePath.Location = new Point(10, 15);
        this.lblFilePath.Name = "lblFilePath";
        this.lblFilePath.Size = new Size(80, 15);
        this.lblFilePath.TabIndex = 0;
        this.lblFilePath.Text = "Путь к файлу:";
        // 
        // txtFilePath
        // 
        this.txtFilePath.Location = new Point(10, 35);
        this.txtFilePath.Name = "txtFilePath";
        this.txtFilePath.Size = new Size(420, 23);
        this.txtFilePath.TabIndex = 1;
        this.txtFilePath.PlaceholderText = "article.pdf";
        // 
        // lblFileType
        // 
        this.lblFileType.AutoSize = true;
        this.lblFileType.Location = new Point(10, 65);
        this.lblFileType.Name = "lblFileType";
        this.lblFileType.Size = new Size(90, 15);
        this.lblFileType.TabIndex = 2;
        this.lblFileType.Text = "Тип документа:";
        // 
        // cmbFileType
        // 
        this.cmbFileType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbFileType.FormattingEnabled = true;
        this.cmbFileType.Items.AddRange(new object[] {
            "(не указан)",
            "fullText - Полный текст",
            "description - Описание",
            "preprint - Препринт",
            "versionAnotherLanguage - Версия на другом языке",
            "anotherEdition - Другое издание",
            "continuation - Продолжение",
            "beginning - Начало",
            "application - Приложение",
            "correction - Исправление",
            "addition - Дополнение",
            "review - Рецензия",
            "comment - Комментарий",
            "mediaFile - Медиафайл",
            "presentation - Презентация",
            "data - Данные",
            "additionalMaterials - Доп. материалы",
            "other - Другое"});
        this.cmbFileType.Location = new Point(10, 85);
        this.cmbFileType.Name = "cmbFileType";
        this.cmbFileType.Size = new Size(300, 23);
        this.cmbFileType.TabIndex = 3;
        this.cmbFileType.SelectedIndex = 0;
        // 
        // lblFileLang
        // 
        this.lblFileLang.AutoSize = true;
        this.lblFileLang.Location = new Point(320, 65);
        this.lblFileLang.Name = "lblFileLang";
        this.lblFileLang.Size = new Size(40, 15);
        this.lblFileLang.TabIndex = 4;
        this.lblFileLang.Text = "Язык:";
        // 
        // cmbFileLang
        // 
        this.cmbFileLang.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbFileLang.FormattingEnabled = true;
        this.cmbFileLang.Items.AddRange(new object[] {
            "(не указан)",
            "RUS",
            "ENG"});
        this.cmbFileLang.Location = new Point(320, 85);
        this.cmbFileLang.Name = "cmbFileLang";
        this.cmbFileLang.Size = new Size(110, 23);
        this.cmbFileLang.TabIndex = 5;
        this.cmbFileLang.SelectedIndex = 0;
        // 
        // btnAddFile
        // 
        this.btnAddFile.Location = new Point(330, 115);
        this.btnAddFile.Name = "btnAddFile";
        this.btnAddFile.Size = new Size(100, 30);
        this.btnAddFile.TabIndex = 6;
        this.btnAddFile.Text = "Добавить";
        this.btnAddFile.UseVisualStyleBackColor = true;
        this.btnAddFile.Click += new EventHandler(this.btnAddFile_Click);
        // 
        // tabPageUrl
        // 
        this.tabPageUrl.Controls.Add(this.btnAddUrl);
        this.tabPageUrl.Controls.Add(this.cmbUrlLang);
        this.tabPageUrl.Controls.Add(this.lblUrlLang);
        this.tabPageUrl.Controls.Add(this.cmbUrlType);
        this.tabPageUrl.Controls.Add(this.lblUrlType);
        this.tabPageUrl.Controls.Add(this.txtUrlPath);
        this.tabPageUrl.Controls.Add(this.lblUrlPath);
        this.tabPageUrl.Location = new Point(4, 24);
        this.tabPageUrl.Name = "tabPageUrl";
        this.tabPageUrl.Padding = new Padding(3);
        this.tabPageUrl.Size = new Size(442, 152);
        this.tabPageUrl.TabIndex = 1;
        this.tabPageUrl.Text = "URL";
        this.tabPageUrl.UseVisualStyleBackColor = true;
        // 
        // lblUrlPath
        // 
        this.lblUrlPath.AutoSize = true;
        this.lblUrlPath.Location = new Point(10, 15);
        this.lblUrlPath.Name = "lblUrlPath";
        this.lblUrlPath.Size = new Size(65, 15);
        this.lblUrlPath.TabIndex = 0;
        this.lblUrlPath.Text = "URL адрес:";
        // 
        // txtUrlPath
        // 
        this.txtUrlPath.Location = new Point(10, 35);
        this.txtUrlPath.Name = "txtUrlPath";
        this.txtUrlPath.Size = new Size(420, 23);
        this.txtUrlPath.TabIndex = 1;
        this.txtUrlPath.PlaceholderText = "https://example.com/article.pdf";
        // 
        // lblUrlType
        // 
        this.lblUrlType.AutoSize = true;
        this.lblUrlType.Location = new Point(10, 65);
        this.lblUrlType.Name = "lblUrlType";
        this.lblUrlType.Size = new Size(90, 15);
        this.lblUrlType.TabIndex = 2;
        this.lblUrlType.Text = "Тип документа:";
        // 
        // cmbUrlType
        // 
        this.cmbUrlType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbUrlType.FormattingEnabled = true;
        this.cmbUrlType.Items.AddRange(new object[] {
            "(не указан)",
            "fullText - Полный текст",
            "description - Описание",
            "preprint - Препринт",
            "versionAnotherLanguage - Версия на другом языке",
            "anotherEdition - Другое издание",
            "continuation - Продолжение",
            "beginning - Начало",
            "application - Приложение",
            "correction - Исправление",
            "addition - Дополнение",
            "review - Рецензия",
            "comment - Комментарий",
            "mediaFile - Медиафайл",
            "presentation - Презентация",
            "data - Данные",
            "additionalMaterials - Доп. материалы",
            "other - Другое"});
        this.cmbUrlType.Location = new Point(10, 85);
        this.cmbUrlType.Name = "cmbUrlType";
        this.cmbUrlType.Size = new Size(300, 23);
        this.cmbUrlType.TabIndex = 3;
        this.cmbUrlType.SelectedIndex = 0;
        // 
        // lblUrlLang
        // 
        this.lblUrlLang.AutoSize = true;
        this.lblUrlLang.Location = new Point(320, 65);
        this.lblUrlLang.Name = "lblUrlLang";
        this.lblUrlLang.Size = new Size(40, 15);
        this.lblUrlLang.TabIndex = 4;
        this.lblUrlLang.Text = "Язык:";
        // 
        // cmbUrlLang
        // 
        this.cmbUrlLang.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbUrlLang.FormattingEnabled = true;
        this.cmbUrlLang.Items.AddRange(new object[] {
            "(не указан)",
            "RUS",
            "ENG"});
        this.cmbUrlLang.Location = new Point(320, 85);
        this.cmbUrlLang.Name = "cmbUrlLang";
        this.cmbUrlLang.Size = new Size(110, 23);
        this.cmbUrlLang.TabIndex = 5;
        this.cmbUrlLang.SelectedIndex = 0;
        // 
        // btnAddUrl
        // 
        this.btnAddUrl.Location = new Point(330, 115);
        this.btnAddUrl.Name = "btnAddUrl";
        this.btnAddUrl.Size = new Size(100, 30);
        this.btnAddUrl.TabIndex = 6;
        this.btnAddUrl.Text = "Добавить";
        this.btnAddUrl.UseVisualStyleBackColor = true;
        this.btnAddUrl.Click += new EventHandler(this.btnAddUrl_Click);
        // 
        // tabPageArticleText
        // 
        this.tabPageArticleText.Controls.Add(this.btnSetArticleText);
        this.tabPageArticleText.Controls.Add(this.cmbArticleTextLang);
        this.tabPageArticleText.Controls.Add(this.lblArticleTextLang);
        this.tabPageArticleText.Controls.Add(this.txtArticleTextContent);
        this.tabPageArticleText.Controls.Add(this.lblArticleTextContent);
        this.tabPageArticleText.Location = new Point(4, 24);
        this.tabPageArticleText.Name = "tabPageArticleText";
        this.tabPageArticleText.Padding = new Padding(3);
        this.tabPageArticleText.Size = new Size(442, 152);
        this.tabPageArticleText.TabIndex = 2;
        this.tabPageArticleText.Text = "Текст статьи / Article Text";
        this.tabPageArticleText.UseVisualStyleBackColor = true;
        // 
        // lblArticleTextContent
        // 
        this.lblArticleTextContent.AutoSize = true;
        this.lblArticleTextContent.Location = new Point(10, 15);
        this.lblArticleTextContent.Name = "lblArticleTextContent";
        this.lblArticleTextContent.Size = new Size(85, 15);
        this.lblArticleTextContent.TabIndex = 0;
        this.lblArticleTextContent.Text = "Текст статьи:";
        // 
        // txtArticleTextContent
        // 
        this.txtArticleTextContent.Location = new Point(10, 35);
        this.txtArticleTextContent.Multiline = true;
        this.txtArticleTextContent.Name = "txtArticleTextContent";
        this.txtArticleTextContent.ScrollBars = ScrollBars.Vertical;
        this.txtArticleTextContent.Size = new Size(420, 70);
        this.txtArticleTextContent.TabIndex = 1;
        // 
        // lblArticleTextLang
        // 
        this.lblArticleTextLang.AutoSize = true;
        this.lblArticleTextLang.Location = new Point(10, 110);
        this.lblArticleTextLang.Name = "lblArticleTextLang";
        this.lblArticleTextLang.Size = new Size(40, 15);
        this.lblArticleTextLang.TabIndex = 2;
        this.lblArticleTextLang.Text = "Язык:";
        // 
        // cmbArticleTextLang
        // 
        this.cmbArticleTextLang.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbArticleTextLang.FormattingEnabled = true;
        this.cmbArticleTextLang.Items.AddRange(new object[] {
            "RUS",
            "ENG"});
        this.cmbArticleTextLang.Location = new Point(60, 110);
        this.cmbArticleTextLang.Name = "cmbArticleTextLang";
        this.cmbArticleTextLang.Size = new Size(110, 23);
        this.cmbArticleTextLang.TabIndex = 3;
        this.cmbArticleTextLang.SelectedIndex = 0;
        // 
        // btnSetArticleText
        // 
        this.btnSetArticleText.Location = new Point(330, 110);
        this.btnSetArticleText.Name = "btnSetArticleText";
        this.btnSetArticleText.Size = new Size(100, 30);
        this.btnSetArticleText.TabIndex = 4;
        this.btnSetArticleText.Text = "Установить";
        this.btnSetArticleText.UseVisualStyleBackColor = true;
        this.btnSetArticleText.Click += new EventHandler(this.btnSetArticleText_Click);
        // 
        // lstFilesUrls
        // 
        this.lstFilesUrls.FormattingEnabled = true;
        this.lstFilesUrls.ItemHeight = 15;
        this.lstFilesUrls.Location = new Point(150, 1140);
        this.lstFilesUrls.Name = "lstFilesUrls";
        this.lstFilesUrls.Size = new Size(345, 94);
        this.lstFilesUrls.TabIndex = 42;
        // 
        // btnEditFileUrl
        // 
        this.btnEditFileUrl.Location = new Point(505, 1140);
        this.btnEditFileUrl.Name = "btnEditFileUrl";
        this.btnEditFileUrl.Size = new Size(95, 30);
        this.btnEditFileUrl.TabIndex = 43;
        this.btnEditFileUrl.Text = "Редактировать";
        this.btnEditFileUrl.UseVisualStyleBackColor = true;
        this.btnEditFileUrl.Click += new EventHandler(this.btnEditFileUrl_Click);
        // 
        // btnRemoveFileUrl
        // 
        this.btnRemoveFileUrl.Location = new Point(505, 1176);
        this.btnRemoveFileUrl.Name = "btnRemoveFileUrl";
        this.btnRemoveFileUrl.Size = new Size(95, 30);
        this.btnRemoveFileUrl.TabIndex = 44;
        this.btnRemoveFileUrl.Text = "Удалить";
        this.btnRemoveFileUrl.UseVisualStyleBackColor = true;
        this.btnRemoveFileUrl.Click += new EventHandler(this.btnRemoveFileUrl_Click);
        // 
        // grpAuthors
        // 
        this.grpAuthors.Controls.Add(this.btnRemoveAuthor);
        this.grpAuthors.Controls.Add(this.btnEditAuthor);
        this.grpAuthors.Controls.Add(this.btnAddAuthor);
        this.grpAuthors.Controls.Add(this.lstAuthors);
        this.grpAuthors.Location = new Point(20, 1250);
        this.grpAuthors.Name = "grpAuthors";
        this.grpAuthors.Size = new Size(580, 150);
        this.grpAuthors.TabIndex = 45;
        this.grpAuthors.TabStop = false;
        this.grpAuthors.Text = "Авторы";
        // 
        // lstAuthors
        // 
        this.lstAuthors.FormattingEnabled = true;
        this.lstAuthors.ItemHeight = 15;
        this.lstAuthors.Location = new Point(10, 22);
        this.lstAuthors.Name = "lstAuthors";
        this.lstAuthors.Size = new Size(430, 109);
        this.lstAuthors.TabIndex = 0;
        // 
        // btnAddAuthor
        // 
        this.btnAddAuthor.Location = new Point(450, 22);
        this.btnAddAuthor.Name = "btnAddAuthor";
        this.btnAddAuthor.Size = new Size(120, 30);
        this.btnAddAuthor.TabIndex = 1;
        this.btnAddAuthor.Text = "Добавить";
        this.btnAddAuthor.UseVisualStyleBackColor = true;
        this.btnAddAuthor.Click += new EventHandler(this.btnAddAuthor_Click);
        // 
        // btnEditAuthor
        // 
        this.btnEditAuthor.Location = new Point(450, 58);
        this.btnEditAuthor.Name = "btnEditAuthor";
        this.btnEditAuthor.Size = new Size(120, 30);
        this.btnEditAuthor.TabIndex = 2;
        this.btnEditAuthor.Text = "Редактировать";
        this.btnEditAuthor.UseVisualStyleBackColor = true;
        this.btnEditAuthor.Click += new EventHandler(this.btnEditAuthor_Click);
        // 
        // btnRemoveAuthor
        // 
        this.btnRemoveAuthor.Location = new Point(450, 94);
        this.btnRemoveAuthor.Name = "btnRemoveAuthor";
        this.btnRemoveAuthor.Size = new Size(120, 30);
        this.btnRemoveAuthor.TabIndex = 3;
        this.btnRemoveAuthor.Text = "Удалить";
        this.btnRemoveAuthor.UseVisualStyleBackColor = true;
        this.btnRemoveAuthor.Click += new EventHandler(this.btnRemoveAuthor_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new Point(350, 1420);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new Size(120, 35);
        this.btnSave.TabIndex = 46;
        this.btnSave.Text = "Сохранить";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new Point(480, 1420);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new Size(120, 35);
        this.btnCancel.TabIndex = 47;
        this.btnCancel.Text = "Отмена";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
        // 
        // ArticleForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.AutoScroll = true;
        this.ClientSize = new Size(620, 700);
        this.MinimumSize = new Size(620, 500);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.grpAuthors);
        this.Controls.Add(this.btnRemoveFileUrl);
        this.Controls.Add(this.btnEditFileUrl);
        this.Controls.Add(this.lstFilesUrls);
        this.Controls.Add(this.tabControlFiles);
        this.Controls.Add(this.lblFiles);
        this.Controls.Add(this.txtPacs);
        this.Controls.Add(this.lblPacs);
        this.Controls.Add(this.txtMsc);
        this.Controls.Add(this.lblMsc);
        this.Controls.Add(this.txtJel);
        this.Controls.Add(this.lblJel);
        this.Controls.Add(this.txtVak);
        this.Controls.Add(this.lblVak);
        this.Controls.Add(this.txtBbk);
        this.Controls.Add(this.lblBbk);
        this.Controls.Add(this.txtKeywordsEng);
        this.Controls.Add(this.lblKeywordsEng);
        this.Controls.Add(this.txtKeywordsRus);
        this.Controls.Add(this.lblKeywordsRus);
        this.Controls.Add(this.txtFunding);
        this.Controls.Add(this.lblFunding);
        this.Controls.Add(this.txtDatePublication);
        this.Controls.Add(this.lblDatePublication);
        this.Controls.Add(this.txtDateAccepted);
        this.Controls.Add(this.lblDateAccepted);
        this.Controls.Add(this.txtDateReceived);
        this.Controls.Add(this.lblDateReceived);
        this.Controls.Add(this.txtEdn);
        this.Controls.Add(this.lblEdn);
        this.Controls.Add(this.txtDoi);
        this.Controls.Add(this.lblDoi);
        this.Controls.Add(this.txtAbstractEng);
        this.Controls.Add(this.lblAbstractEng);
        this.Controls.Add(this.txtAbstractRus);
        this.Controls.Add(this.lblAbstractRus);
        this.Controls.Add(this.lblTitleNote);
        this.Controls.Add(this.txtTitleEng);
        this.Controls.Add(this.lblTitleEng);
        this.Controls.Add(this.txtTitleRus);
        this.Controls.Add(this.lblTitleRus);
        this.Controls.Add(this.cmbArticleType);
        this.Controls.Add(this.lblArticleType);
        this.Controls.Add(this.txtPages);
        this.Controls.Add(this.lblPages);
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.MaximizeBox = true;
        this.MinimizeBox = false;
        this.Name = "ArticleForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Редактор статьи";
        this.grpAuthors.ResumeLayout(false);
        this.tabControlFiles.ResumeLayout(false);
        this.tabPageFile.ResumeLayout(false);
        this.tabPageFile.PerformLayout();
        this.tabPageUrl.ResumeLayout(false);
        this.tabPageUrl.PerformLayout();
        this.tabPageArticleText.ResumeLayout(false);
        this.tabPageArticleText.PerformLayout();
        
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
        
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Label lblPages;
    private TextBox txtPages;
    private Label lblArticleType;
    private ComboBox cmbArticleType;
    private Label lblTitleRus;
    private TextBox txtTitleRus;
    private Label lblTitleEng;
    private TextBox txtTitleEng;
    private Label lblTitleNote;
    private Label lblAbstractRus;
    private TextBox txtAbstractRus;
    private Label lblAbstractEng;
    private TextBox txtAbstractEng;
    private Label lblDoi;
    private TextBox txtDoi;
    private Label lblEdn;
    private TextBox txtEdn;
    private Label lblDateReceived;
    private TextBox txtDateReceived;
    private Label lblDateAccepted;
    private TextBox txtDateAccepted;
    private Label lblDatePublication;
    private TextBox txtDatePublication;
    private Label lblFunding;
    private TextBox txtFunding;
    private Label lblKeywordsRus;
    private TextBox txtKeywordsRus;
    private Label lblKeywordsEng;
    private TextBox txtKeywordsEng;
    private Label lblBbk;
    private TextBox txtBbk;
    private Label lblVak;
    private TextBox txtVak;
    private Label lblJel;
    private TextBox txtJel;
    private Label lblMsc;
    private TextBox txtMsc;
    private Label lblPacs;
    private TextBox txtPacs;
    private Label lblFiles;
    private TabControl tabControlFiles;
    private TabPage tabPageFile;
    private TextBox txtFilePath;
    private Label lblFilePath;
    private ComboBox cmbFileType;
    private Label lblFileType;
    private ComboBox cmbFileLang;
    private Label lblFileLang;
    private Button btnAddFile;
    private TabPage tabPageUrl;
    private TextBox txtUrlPath;
    private Label lblUrlPath;
    private ComboBox cmbUrlType;
    private Label lblUrlType;
    private ComboBox cmbUrlLang;
    private Label lblUrlLang;
    private Button btnAddUrl;
    private TabPage tabPageArticleText;
    private TextBox txtArticleTextContent;
    private Label lblArticleTextContent;
    private ComboBox cmbArticleTextLang;
    private Label lblArticleTextLang;
    private Button btnSetArticleText;
    private ListBox lstFilesUrls;
    private Button btnEditFileUrl;
    private Button btnRemoveFileUrl;
    private GroupBox grpAuthors;
    private ListBox lstAuthors;
    private Button btnAddAuthor;
    private Button btnEditAuthor;
    private Button btnRemoveAuthor;
    private Button btnSave;
    private Button btnCancel;
}
