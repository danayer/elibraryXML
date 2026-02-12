namespace elibraryXMLApp;

partial class ManualParserForm
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer splitContainer;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView;
    private Panel pnlRight;
    private Button btnLoadDocument;
    private Label lblInstructions;
    private TabControl tabControl;
    private TabPage tabBasic;
    private TabPage tabContent;
    private TabPage tabCodes;
    private TabPage tabAuthors;
    private TabPage tabDates;
    private TabPage tabAdditional;
    
    // Basic Info Tab
    private TextBox txtTitle;
    private TextBox txtTitleEng;
    private TextBox txtAuthors;
    private TextBox txtDoi;
    private TextBox txtPages;
    private TextBox txtYear;
    private TextBox txtEmail;
    private Label lblTitle;
    private Label lblTitleEng;
    private Label lblAuthors;
    private Label lblDoi;
    private Label lblPages;
    private Label lblYear;
    private Label lblEmail;
    
    // Content Tab
    private TextBox txtKeywords;
    private TextBox txtKeywordsEng;
    private TextBox txtAbstract;
    private TextBox txtAbstractEng;
    private TextBox txtTextContent;
    private TextBox txtLangPubl;
    private Label lblKeywords;
    private Label lblKeywordsEng;
    private Label lblAbstract;
    private Label lblAbstractEng;
    private Label lblTextContent;
    private Label lblLangPubl;
    
    // Codes Tab
    private TextBox txtEdn;
    private TextBox txtUdk;
    private TextBox txtBbk;
    private TextBox txtVak;
    private TextBox txtJel;
    private TextBox txtMsc;
    private TextBox txtPacs;
    private TextBox txtArtType;
    private Label lblEdn;
    private Label lblUdk;
    private Label lblBbk;
    private Label lblVak;
    private Label lblJel;
    private Label lblMsc;
    private Label lblPacs;
    private Label lblArtType;
    
    // Author Details Tab
    private TextBox txtOrcid;
    private TextBox txtSpin;
    private TextBox txtScopusId;
    private TextBox txtResearcherId;
    private TextBox txtOrgName;
    private Label lblOrcid;
    private Label lblSpin;
    private Label lblScopusId;
    private Label lblResearcherId;
    private Label lblOrgName;
    
    // Dates Tab
    private TextBox txtDateReceived;
    private TextBox txtDateAccepted;
    private TextBox txtDatePublication;
    private Label lblDateReceived;
    private Label lblDateAccepted;
    private Label lblDatePublication;
    
    // Additional Tab
    private TextBox txtFundings;
    private TextBox txtRubrics;
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
    private TextBox txtReferences;
    private Label lblFundings;
    private Label lblRubrics;
    private Label lblReferences;
    
    private Panel pnlBottom;
    private Button btnAddArticle;
    private Button btnUndo;
    private Button btnRedo;
    private Button btnCancel;
    private Button btnClearFields;
    private Button btnDeleteArticle;
    private Button btnDone;
    private ListBox lstArticles;
    private Label lblArticlesList;

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
        this.splitContainer = new SplitContainer();
        this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
        this.btnLoadDocument = new Button();
        this.lblInstructions = new Label();
        this.pnlRight = new Panel();
        this.tabControl = new TabControl();
        this.tabBasic = new TabPage();
        this.tabContent = new TabPage();
        this.tabCodes = new TabPage();
        this.tabAuthors = new TabPage();
        this.tabDates = new TabPage();
        this.tabAdditional = new TabPage();
        this.pnlBottom = new Panel();
        this.btnAddArticle = new Button();
        this.btnUndo = new Button();
        this.btnRedo = new Button();
        this.btnCancel = new Button();
        this.btnClearFields = new Button();
        this.btnDeleteArticle = new Button();
        this.btnDone = new Button();
        this.lstArticles = new ListBox();
        this.lblArticlesList = new Label();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
        this.pnlRight.SuspendLayout();
        this.tabControl.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();

        // 
        // splitContainer
        // 
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Location = new Point(0, 0);
        this.splitContainer.Name = "splitContainer";
        this.splitContainer.Panel1.Controls.Add(this.webView);
        this.splitContainer.Panel1.Controls.Add(this.btnLoadDocument);
        this.splitContainer.Panel1.Controls.Add(this.lblInstructions);
        this.splitContainer.Panel2.Controls.Add(this.pnlRight);
        this.splitContainer.Size = new Size(1400, 800);
        this.splitContainer.SplitterDistance = 700;
        this.splitContainer.TabIndex = 0;

        // 
        // webView
        // 
        this.webView.AllowExternalDrop = true;
        this.webView.CreationProperties = null;
        this.webView.DefaultBackgroundColor = Color.White;
        this.webView.Dock = DockStyle.Fill;
        this.webView.Location = new Point(0, 80);
        this.webView.Name = "webView";
        this.webView.Size = new Size(700, 720);
        this.webView.TabIndex = 0;
        this.webView.ZoomFactor = 1D;

        // 
        // btnLoadDocument
        // 
        this.btnLoadDocument.Dock = DockStyle.Top;
        this.btnLoadDocument.Location = new Point(0, 40);
        this.btnLoadDocument.Name = "btnLoadDocument";
        this.btnLoadDocument.Size = new Size(700, 40);
        this.btnLoadDocument.TabIndex = 1;
        this.btnLoadDocument.Text = "📂 Загрузить HTML документ / Load HTML Document";
        this.btnLoadDocument.UseVisualStyleBackColor = true;
        this.btnLoadDocument.Click += new EventHandler(this.btnLoadDocument_Click);

        // 
        // lblInstructions
        // 
        this.lblInstructions.BackColor = Color.LightYellow;
        this.lblInstructions.Dock = DockStyle.Top;
        this.lblInstructions.Font = new Font("Segoe UI", 9F);
        this.lblInstructions.Location = new Point(0, 0);
        this.lblInstructions.Name = "lblInstructions";
        this.lblInstructions.Padding = new Padding(10);
        this.lblInstructions.Size = new Size(700, 40);
        this.lblInstructions.TabIndex = 2;
        this.lblInstructions.Text = "💡 Инструкция: Загрузите HTML документ, выделите текст мышью, кликните на нужное поле справа";

        // 
        // pnlRight
        // 
        this.pnlRight.Controls.Add(this.tabControl);
        this.pnlRight.Controls.Add(this.lblArticlesList);
        this.pnlRight.Controls.Add(this.lstArticles);
        this.pnlRight.Controls.Add(this.pnlBottom);
        this.pnlRight.Dock = DockStyle.Fill;
        this.pnlRight.Location = new Point(0, 0);
        this.pnlRight.Name = "pnlRight";
        this.pnlRight.Size = new Size(696, 800);
        this.pnlRight.TabIndex = 0;

        // 
        // lblArticlesList
        // 
        this.lblArticlesList.Location = new Point(10, 5);
        this.lblArticlesList.Name = "lblArticlesList";
        this.lblArticlesList.Size = new Size(300, 20);
        this.lblArticlesList.TabIndex = 0;
        this.lblArticlesList.Text = "Добавленные статьи / Added Articles:";

        // 
        // lstArticles
        // 
        this.lstArticles.Location = new Point(10, 30);
        this.lstArticles.Name = "lstArticles";
        this.lstArticles.Size = new Size(676, 100);
        this.lstArticles.TabIndex = 1;
        this.lstArticles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.lstArticles.DoubleClick += lstArticles_DoubleClick;

        // 
        // tabControl
        // 
        this.tabControl.Controls.Add(this.tabBasic);
        this.tabControl.Controls.Add(this.tabContent);
        this.tabControl.Controls.Add(this.tabCodes);
        this.tabControl.Controls.Add(this.tabAuthors);
        this.tabControl.Controls.Add(this.tabDates);
        this.tabControl.Controls.Add(this.tabAdditional);
        this.tabControl.Location = new Point(0, 140);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new Size(696, 600);
        this.tabControl.TabIndex = 2;
        this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        // 
        // tabBasic
        // 
        this.tabBasic.AutoScroll = true;
        this.tabBasic.Location = new Point(4, 24);
        this.tabBasic.Name = "tabBasic";
        this.tabBasic.Padding = new Padding(10);
        this.tabBasic.Size = new Size(688, 712);
        this.tabBasic.TabIndex = 0;
        this.tabBasic.Text = "Основное / Basic";
        this.tabBasic.UseVisualStyleBackColor = true;
        InitializeBasicTab();

        // 
        // tabContent
        // 
        this.tabContent.AutoScroll = true;
        this.tabContent.Location = new Point(4, 24);
        this.tabContent.Name = "tabContent";
        this.tabContent.Padding = new Padding(10);
        this.tabContent.Size = new Size(688, 712);
        this.tabContent.TabIndex = 1;
        this.tabContent.Text = "Содержание / Content";
        this.tabContent.UseVisualStyleBackColor = true;
        InitializeContentTab();

        // 
        // tabCodes
        // 
        this.tabCodes.AutoScroll = true;
        this.tabCodes.Location = new Point(4, 24);
        this.tabCodes.Name = "tabCodes";
        this.tabCodes.Padding = new Padding(10);
        this.tabCodes.Size = new Size(688, 712);
        this.tabCodes.TabIndex = 2;
        this.tabCodes.Text = "Коды / Codes";
        this.tabCodes.UseVisualStyleBackColor = true;
        InitializeCodesTab();

        // 
        // tabAuthors
        // 
        this.tabAuthors.AutoScroll = true;
        this.tabAuthors.Location = new Point(4, 24);
        this.tabAuthors.Name = "tabAuthors";
        this.tabAuthors.Padding = new Padding(10);
        this.tabAuthors.Size = new Size(688, 712);
        this.tabAuthors.TabIndex = 3;
        this.tabAuthors.Text = "Авторы / Authors";
        this.tabAuthors.UseVisualStyleBackColor = true;
        InitializeAuthorsTab();

        // 
        // tabDates
        // 
        this.tabDates.AutoScroll = true;
        this.tabDates.Location = new Point(4, 24);
        this.tabDates.Name = "tabDates";
        this.tabDates.Padding = new Padding(10);
        this.tabDates.Size = new Size(688, 712);
        this.tabDates.TabIndex = 4;
        this.tabDates.Text = "Даты / Dates";
        this.tabDates.UseVisualStyleBackColor = true;
        InitializeDatesTab();

        // 
        // tabAdditional
        // 
        this.tabAdditional.AutoScroll = true;
        this.tabAdditional.Location = new Point(4, 24);
        this.tabAdditional.Name = "tabAdditional";
        this.tabAdditional.Padding = new Padding(10);
        this.tabAdditional.Size = new Size(688, 712);
        this.tabAdditional.TabIndex = 5;
        this.tabAdditional.Text = "Дополнительно / Additional";
        this.tabAdditional.UseVisualStyleBackColor = true;
        InitializeAdditionalTab();

        // 
        // pnlBottom
        // 
        this.pnlBottom.Controls.Add(this.btnAddArticle);
        this.pnlBottom.Controls.Add(this.btnClearFields);
        this.pnlBottom.Controls.Add(this.btnUndo);
        this.pnlBottom.Controls.Add(this.btnRedo);
        this.pnlBottom.Controls.Add(this.btnDeleteArticle);
        this.pnlBottom.Controls.Add(this.btnDone);
        this.pnlBottom.Controls.Add(this.btnCancel);
        this.pnlBottom.Dock = DockStyle.Bottom;
        this.pnlBottom.Location = new Point(0, 740);
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new Size(696, 60);
        this.pnlBottom.TabIndex = 1;

        // 
        // btnAddArticle
        // 
        this.btnAddArticle.Location = new Point(20, 15);
        this.btnAddArticle.Name = "btnAddArticle";
        this.btnAddArticle.Size = new Size(140, 35);
        this.btnAddArticle.TabIndex = 0;
        this.btnAddArticle.Text = "➕ Добавить статью\nAdd Article";
        this.btnAddArticle.UseVisualStyleBackColor = true;
        this.btnAddArticle.Click += new EventHandler(this.btnAddArticle_Click);

        // 
        // btnClearFields
        // 
        this.btnClearFields.Location = new Point(180, 15);
        this.btnClearFields.Name = "btnClearFields";
        this.btnClearFields.Size = new Size(120, 35);
        this.btnClearFields.TabIndex = 1;
        this.btnClearFields.Text = "🗑️ Очистить\nClear Fields";
        this.btnClearFields.UseVisualStyleBackColor = true;
        this.btnClearFields.Click += new EventHandler(this.btnClearFields_Click);

        // 
        // btnUndo
        // 
        this.btnUndo.Location = new Point(320, 15);
        this.btnUndo.Name = "btnUndo";
        this.btnUndo.Size = new Size(70, 35);
        this.btnUndo.TabIndex = 2;
        this.btnUndo.Text = "↶ Undo";
        this.btnUndo.UseVisualStyleBackColor = true;
        this.btnUndo.Click += new EventHandler(this.btnUndo_Click);

        // 
        // btnRedo
        // 
        this.btnRedo.Location = new Point(410, 15);
        this.btnRedo.Name = "btnRedo";
        this.btnRedo.Size = new Size(70, 35);
        this.btnRedo.TabIndex = 3;
        this.btnRedo.Text = "↷ Redo";
        this.btnRedo.UseVisualStyleBackColor = true;
        this.btnRedo.Click += new EventHandler(this.btnRedo_Click);

        // 
        // btnDeleteArticle
        // 
        this.btnDeleteArticle.Location = new Point(500, 15);
        this.btnDeleteArticle.Name = "btnDeleteArticle";
        this.btnDeleteArticle.Size = new Size(80, 35);
        this.btnDeleteArticle.TabIndex = 4;
        this.btnDeleteArticle.Text = "❌ Удалить\nDelete";
        this.btnDeleteArticle.UseVisualStyleBackColor = true;
        this.btnDeleteArticle.Click += new EventHandler(this.btnDeleteArticle_Click);
        this.btnDeleteArticle.Enabled = false;

        // 
        // btnDone
        // 
        this.btnDone.Location = new Point(600, 15);
        this.btnDone.Name = "btnDone";
        this.btnDone.Size = new Size(80, 35);
        this.btnDone.TabIndex = 5;
        this.btnDone.Text = "✓ Готово\nDone";
        this.btnDone.UseVisualStyleBackColor = true;
        this.btnDone.Click += new EventHandler(this.btnDone_Click);
        this.btnDone.Enabled = false;

        // 
        // btnCancel
        // 
        this.btnCancel.Location = new Point(700, 15);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new Size(80, 35);
        this.btnCancel.TabIndex = 6;
        this.btnCancel.Text = "Отмена\nCancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

        // 
        // ManualParserForm
        // 
        this.ClientSize = new Size(1400, 800);
        this.Controls.Add(this.splitContainer);
        this.Name = "ManualParserForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Ручной парсер / Manual Parser";
        this.Load += new EventHandler(this.ManualParserForm_Load);
        
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
        this.pnlRight.ResumeLayout(false);
        this.tabControl.ResumeLayout(false);
        this.pnlBottom.ResumeLayout(false);
        
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
    }

    private void InitializeBasicTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // Title (Russian)
        this.lblTitle = new Label();
        this.txtTitle = new TextBox();
        this.lblTitle.Location = new Point(10, yPos);
        this.lblTitle.Size = new Size(labelWidth, 20);
        this.lblTitle.Text = "Название (RUS):";
        this.txtTitle.Location = new Point(200, yPos);
        this.txtTitle.Size = new Size(textBoxWidth, 23);
        this.txtTitle.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblTitle);
        this.tabBasic.Controls.Add(this.txtTitle);
        yPos += spacing;

        // Title (English)
        this.lblTitleEng = new Label();
        this.txtTitleEng = new TextBox();
        this.lblTitleEng.Location = new Point(10, yPos);
        this.lblTitleEng.Size = new Size(labelWidth, 20);
        this.lblTitleEng.Text = "Title (ENG):";
        this.txtTitleEng.Location = new Point(200, yPos);
        this.txtTitleEng.Size = new Size(textBoxWidth, 23);
        this.txtTitleEng.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblTitleEng);
        this.tabBasic.Controls.Add(this.txtTitleEng);
        yPos += spacing;

        // Authors
        this.lblAuthors = new Label();
        this.txtAuthors = new TextBox();
        this.lblAuthors.Location = new Point(10, yPos);
        this.lblAuthors.Size = new Size(labelWidth, 20);
        this.lblAuthors.Text = "Авторы / Authors:";
        this.txtAuthors.Location = new Point(200, yPos);
        this.txtAuthors.Multiline = true;
        this.txtAuthors.Size = new Size(textBoxWidth, 60);
        this.txtAuthors.ScrollBars = ScrollBars.Vertical;
        this.txtAuthors.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblAuthors);
        this.tabBasic.Controls.Add(this.txtAuthors);
        yPos += 70;

        // DOI
        this.lblDoi = new Label();
        this.txtDoi = new TextBox();
        this.lblDoi.Location = new Point(10, yPos);
        this.lblDoi.Size = new Size(labelWidth, 20);
        this.lblDoi.Text = "DOI:";
        this.txtDoi.Location = new Point(200, yPos);
        this.txtDoi.Size = new Size(textBoxWidth, 23);
        this.txtDoi.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblDoi);
        this.tabBasic.Controls.Add(this.txtDoi);
        yPos += spacing;

        // Email
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.lblEmail.Location = new Point(10, yPos);
        this.lblEmail.Size = new Size(labelWidth, 20);
        this.lblEmail.Text = "Email:";
        this.txtEmail.Location = new Point(200, yPos);
        this.txtEmail.Size = new Size(textBoxWidth, 23);
        this.txtEmail.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblEmail);
        this.tabBasic.Controls.Add(this.txtEmail);
        yPos += spacing;

        // Pages
        this.lblPages = new Label();
        this.txtPages = new TextBox();
        this.lblPages.Location = new Point(10, yPos);
        this.lblPages.Size = new Size(labelWidth, 20);
        this.lblPages.Text = "Страницы / Pages:";
        this.txtPages.Location = new Point(200, yPos);
        this.txtPages.Size = new Size(textBoxWidth, 23);
        this.txtPages.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblPages);
        this.tabBasic.Controls.Add(this.txtPages);
        yPos += spacing;

        // Year
        this.lblYear = new Label();
        this.txtYear = new TextBox();
        this.lblYear.Location = new Point(10, yPos);
        this.lblYear.Size = new Size(labelWidth, 20);
        this.lblYear.Text = "Год / Year:";
        this.txtYear.Location = new Point(200, yPos);
        this.txtYear.Size = new Size(textBoxWidth, 23);
        this.txtYear.Click += new EventHandler(this.txtField_Click);
        this.tabBasic.Controls.Add(this.lblYear);
        this.tabBasic.Controls.Add(this.txtYear);
    }

    private void InitializeContentTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // Keywords (Russian)
        this.lblKeywords = new Label();
        this.txtKeywords = new TextBox();
        this.lblKeywords.Location = new Point(10, yPos);
        this.lblKeywords.Size = new Size(labelWidth, 20);
        this.lblKeywords.Text = "Ключевые слова (RUS):";
        this.txtKeywords.Location = new Point(200, yPos);
        this.txtKeywords.Multiline = true;
        this.txtKeywords.Size = new Size(textBoxWidth, 60);
        this.txtKeywords.ScrollBars = ScrollBars.Vertical;
        this.txtKeywords.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblKeywords);
        this.tabContent.Controls.Add(this.txtKeywords);
        yPos += 70;

        // Keywords (English)
        this.lblKeywordsEng = new Label();
        this.txtKeywordsEng = new TextBox();
        this.lblKeywordsEng.Location = new Point(10, yPos);
        this.lblKeywordsEng.Size = new Size(labelWidth, 20);
        this.lblKeywordsEng.Text = "Keywords (ENG):";
        this.txtKeywordsEng.Location = new Point(200, yPos);
        this.txtKeywordsEng.Multiline = true;
        this.txtKeywordsEng.Size = new Size(textBoxWidth, 60);
        this.txtKeywordsEng.ScrollBars = ScrollBars.Vertical;
        this.txtKeywordsEng.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblKeywordsEng);
        this.tabContent.Controls.Add(this.txtKeywordsEng);
        yPos += 70;

        // Abstract (Russian)
        this.lblAbstract = new Label();
        this.txtAbstract = new TextBox();
        this.lblAbstract.Location = new Point(10, yPos);
        this.lblAbstract.Size = new Size(labelWidth, 20);
        this.lblAbstract.Text = "Аннотация (RUS):";
        this.txtAbstract.Location = new Point(200, yPos);
        this.txtAbstract.Multiline = true;
        this.txtAbstract.Size = new Size(textBoxWidth, 80);
        this.txtAbstract.ScrollBars = ScrollBars.Vertical;
        this.txtAbstract.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblAbstract);
        this.tabContent.Controls.Add(this.txtAbstract);
        yPos += 90;

        // Abstract (English)
        this.lblAbstractEng = new Label();
        this.txtAbstractEng = new TextBox();
        this.lblAbstractEng.Location = new Point(10, yPos);
        this.lblAbstractEng.Size = new Size(labelWidth, 20);
        this.lblAbstractEng.Text = "Abstract (ENG):";
        this.txtAbstractEng.Location = new Point(200, yPos);
        this.txtAbstractEng.Multiline = true;
        this.txtAbstractEng.Size = new Size(textBoxWidth, 80);
        this.txtAbstractEng.ScrollBars = ScrollBars.Vertical;
        this.txtAbstractEng.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblAbstractEng);
        this.tabContent.Controls.Add(this.txtAbstractEng);
        yPos += 90;

        // Text Content
        this.lblTextContent = new Label();
        this.txtTextContent = new TextBox();
        this.lblTextContent.Location = new Point(10, yPos);
        this.lblTextContent.Size = new Size(labelWidth, 20);
        this.lblTextContent.Text = "Текст / Text:";
        this.txtTextContent.Location = new Point(200, yPos);
        this.txtTextContent.Multiline = true;
        this.txtTextContent.Size = new Size(textBoxWidth, 100);
        this.txtTextContent.ScrollBars = ScrollBars.Vertical;
        this.txtTextContent.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblTextContent);
        this.tabContent.Controls.Add(this.txtTextContent);
        yPos += 110;

        // Language Publication
        this.lblLangPubl = new Label();
        this.txtLangPubl = new TextBox();
        this.lblLangPubl.Location = new Point(10, yPos);
        this.lblLangPubl.Size = new Size(labelWidth, 20);
        this.lblLangPubl.Text = "Язык публикации / Lang:";
        this.txtLangPubl.Location = new Point(200, yPos);
        this.txtLangPubl.Size = new Size(textBoxWidth, 23);
        this.txtLangPubl.Click += new EventHandler(this.txtField_Click);
        this.tabContent.Controls.Add(this.lblLangPubl);
        this.tabContent.Controls.Add(this.txtLangPubl);
    }

    private void InitializeCodesTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // Article Type
        this.lblArtType = new Label();
        this.txtArtType = new TextBox();
        this.lblArtType.Location = new Point(10, yPos);
        this.lblArtType.Size = new Size(labelWidth, 20);
        this.lblArtType.Text = "Тип статьи / Art Type:";
        this.txtArtType.Location = new Point(200, yPos);
        this.txtArtType.Size = new Size(textBoxWidth, 23);
        this.txtArtType.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblArtType);
        this.tabCodes.Controls.Add(this.txtArtType);
        yPos += spacing;

        // EDN
        this.lblEdn = new Label();
        this.txtEdn = new TextBox();
        this.lblEdn.Location = new Point(10, yPos);
        this.lblEdn.Size = new Size(labelWidth, 20);
        this.lblEdn.Text = "EDN:";
        this.txtEdn.Location = new Point(200, yPos);
        this.txtEdn.Size = new Size(textBoxWidth, 23);
        this.txtEdn.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblEdn);
        this.tabCodes.Controls.Add(this.txtEdn);
        yPos += spacing;

        // UDK
        this.lblUdk = new Label();
        this.txtUdk = new TextBox();
        this.lblUdk.Location = new Point(10, yPos);
        this.lblUdk.Size = new Size(labelWidth, 20);
        this.lblUdk.Text = "УДК / UDK:";
        this.txtUdk.Location = new Point(200, yPos);
        this.txtUdk.Size = new Size(textBoxWidth, 23);
        this.txtUdk.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblUdk);
        this.tabCodes.Controls.Add(this.txtUdk);
        yPos += spacing;

        // BBK
        this.lblBbk = new Label();
        this.txtBbk = new TextBox();
        this.lblBbk.Location = new Point(10, yPos);
        this.lblBbk.Size = new Size(labelWidth, 20);
        this.lblBbk.Text = "ББК / BBK:";
        this.txtBbk.Location = new Point(200, yPos);
        this.txtBbk.Size = new Size(textBoxWidth, 23);
        this.txtBbk.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblBbk);
        this.tabCodes.Controls.Add(this.txtBbk);
        yPos += spacing;

        // VAK
        this.lblVak = new Label();
        this.txtVak = new TextBox();
        this.lblVak.Location = new Point(10, yPos);
        this.lblVak.Size = new Size(labelWidth, 20);
        this.lblVak.Text = "ВАК / VAK:";
        this.txtVak.Location = new Point(200, yPos);
        this.txtVak.Size = new Size(textBoxWidth, 23);
        this.txtVak.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblVak);
        this.tabCodes.Controls.Add(this.txtVak);
        yPos += spacing;

        // JEL
        this.lblJel = new Label();
        this.txtJel = new TextBox();
        this.lblJel.Location = new Point(10, yPos);
        this.lblJel.Size = new Size(labelWidth, 20);
        this.lblJel.Text = "JEL:";
        this.txtJel.Location = new Point(200, yPos);
        this.txtJel.Size = new Size(textBoxWidth, 23);
        this.txtJel.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblJel);
        this.tabCodes.Controls.Add(this.txtJel);
        yPos += spacing;

        // MSC
        this.lblMsc = new Label();
        this.txtMsc = new TextBox();
        this.lblMsc.Location = new Point(10, yPos);
        this.lblMsc.Size = new Size(labelWidth, 20);
        this.lblMsc.Text = "MSC:";
        this.txtMsc.Location = new Point(200, yPos);
        this.txtMsc.Size = new Size(textBoxWidth, 23);
        this.txtMsc.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblMsc);
        this.tabCodes.Controls.Add(this.txtMsc);
        yPos += spacing;

        // PACS
        this.lblPacs = new Label();
        this.txtPacs = new TextBox();
        this.lblPacs.Location = new Point(10, yPos);
        this.lblPacs.Size = new Size(labelWidth, 20);
        this.lblPacs.Text = "PACS:";
        this.txtPacs.Location = new Point(200, yPos);
        this.txtPacs.Size = new Size(textBoxWidth, 23);
        this.txtPacs.Click += new EventHandler(this.txtField_Click);
        this.tabCodes.Controls.Add(this.lblPacs);
        this.tabCodes.Controls.Add(this.txtPacs);
    }

    private void InitializeAuthorsTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // ORCID
        this.lblOrcid = new Label();
        this.txtOrcid = new TextBox();
        this.lblOrcid.Location = new Point(10, yPos);
        this.lblOrcid.Size = new Size(labelWidth, 20);
        this.lblOrcid.Text = "ORCID:";
        this.txtOrcid.Location = new Point(200, yPos);
        this.txtOrcid.Size = new Size(textBoxWidth, 23);
        this.txtOrcid.Click += new EventHandler(this.txtField_Click);
        this.tabAuthors.Controls.Add(this.lblOrcid);
        this.tabAuthors.Controls.Add(this.txtOrcid);
        yPos += spacing;

        // SPIN
        this.lblSpin = new Label();
        this.txtSpin = new TextBox();
        this.lblSpin.Location = new Point(10, yPos);
        this.lblSpin.Size = new Size(labelWidth, 20);
        this.lblSpin.Text = "SPIN:";
        this.txtSpin.Location = new Point(200, yPos);
        this.txtSpin.Size = new Size(textBoxWidth, 23);
        this.txtSpin.Click += new EventHandler(this.txtField_Click);
        this.tabAuthors.Controls.Add(this.lblSpin);
        this.tabAuthors.Controls.Add(this.txtSpin);
        yPos += spacing;

        // ScopusID
        this.lblScopusId = new Label();
        this.txtScopusId = new TextBox();
        this.lblScopusId.Location = new Point(10, yPos);
        this.lblScopusId.Size = new Size(labelWidth, 20);
        this.lblScopusId.Text = "Scopus ID:";
        this.txtScopusId.Location = new Point(200, yPos);
        this.txtScopusId.Size = new Size(textBoxWidth, 23);
        this.txtScopusId.Click += new EventHandler(this.txtField_Click);
        this.tabAuthors.Controls.Add(this.lblScopusId);
        this.tabAuthors.Controls.Add(this.txtScopusId);
        yPos += spacing;

        // ResearcherID
        this.lblResearcherId = new Label();
        this.txtResearcherId = new TextBox();
        this.lblResearcherId.Location = new Point(10, yPos);
        this.lblResearcherId.Size = new Size(labelWidth, 20);
        this.lblResearcherId.Text = "Researcher ID:";
        this.txtResearcherId.Location = new Point(200, yPos);
        this.txtResearcherId.Size = new Size(textBoxWidth, 23);
        this.txtResearcherId.Click += new EventHandler(this.txtField_Click);
        this.tabAuthors.Controls.Add(this.lblResearcherId);
        this.tabAuthors.Controls.Add(this.txtResearcherId);
        yPos += spacing;

        // Organization Name
        this.lblOrgName = new Label();
        this.txtOrgName = new TextBox();
        this.lblOrgName.Location = new Point(10, yPos);
        this.lblOrgName.Size = new Size(labelWidth, 20);
        this.lblOrgName.Text = "Организация / Org:";
        this.txtOrgName.Location = new Point(200, yPos);
        this.txtOrgName.Multiline = true;
        this.txtOrgName.Size = new Size(textBoxWidth, 60);
        this.txtOrgName.ScrollBars = ScrollBars.Vertical;
        this.txtOrgName.Click += new EventHandler(this.txtField_Click);
        this.tabAuthors.Controls.Add(this.lblOrgName);
        this.tabAuthors.Controls.Add(this.txtOrgName);
    }

    private void InitializeDatesTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // Date Received
        this.lblDateReceived = new Label();
        this.txtDateReceived = new TextBox();
        this.lblDateReceived.Location = new Point(10, yPos);
        this.lblDateReceived.Size = new Size(labelWidth, 20);
        this.lblDateReceived.Text = "Дата получения / Received:";
        this.txtDateReceived.Location = new Point(200, yPos);
        this.txtDateReceived.Size = new Size(textBoxWidth, 23);
        this.txtDateReceived.Click += new EventHandler(this.txtField_Click);
        this.tabDates.Controls.Add(this.lblDateReceived);
        this.tabDates.Controls.Add(this.txtDateReceived);
        yPos += spacing;

        // Date Accepted
        this.lblDateAccepted = new Label();
        this.txtDateAccepted = new TextBox();
        this.lblDateAccepted.Location = new Point(10, yPos);
        this.lblDateAccepted.Size = new Size(labelWidth, 20);
        this.lblDateAccepted.Text = "Дата принятия / Accepted:";
        this.txtDateAccepted.Location = new Point(200, yPos);
        this.txtDateAccepted.Size = new Size(textBoxWidth, 23);
        this.txtDateAccepted.Click += new EventHandler(this.txtField_Click);
        this.tabDates.Controls.Add(this.lblDateAccepted);
        this.tabDates.Controls.Add(this.txtDateAccepted);
        yPos += spacing;

        // Date Publication
        this.lblDatePublication = new Label();
        this.txtDatePublication = new TextBox();
        this.lblDatePublication.Location = new Point(10, yPos);
        this.lblDatePublication.Size = new Size(labelWidth, 20);
        this.lblDatePublication.Text = "Дата публикации / Publication:";
        this.txtDatePublication.Location = new Point(200, yPos);
        this.txtDatePublication.Size = new Size(textBoxWidth, 23);
        this.txtDatePublication.Click += new EventHandler(this.txtField_Click);
        this.tabDates.Controls.Add(this.lblDatePublication);
        this.tabDates.Controls.Add(this.txtDatePublication);
    }

    private void InitializeAdditionalTab()
    {
        int yPos = 20;
        int labelWidth = 180;
        int textBoxWidth = 450;
        int spacing = 35;

        // Funding
        this.lblFundings = new Label();
        this.txtFundings = new TextBox();
        this.lblFundings.Location = new Point(10, yPos);
        this.lblFundings.Size = new Size(labelWidth, 20);
        this.lblFundings.Text = "Финансирование / Funding:";
        this.txtFundings.Location = new Point(200, yPos);
        this.txtFundings.Multiline = true;
        this.txtFundings.Size = new Size(textBoxWidth, 60);
        this.txtFundings.ScrollBars = ScrollBars.Vertical;
        this.txtFundings.Click += new EventHandler(this.txtField_Click);
        this.tabAdditional.Controls.Add(this.lblFundings);
        this.tabAdditional.Controls.Add(this.txtFundings);
        yPos += 70;

        // Rubrics
        this.lblRubrics = new Label();
        this.txtRubrics = new TextBox();
        this.lblRubrics.Location = new Point(10, yPos);
        this.lblRubrics.Size = new Size(labelWidth, 20);
        this.lblRubrics.Text = "Рубрики / Rubrics:";
        this.txtRubrics.Location = new Point(200, yPos);
        this.txtRubrics.Multiline = true;
        this.txtRubrics.Size = new Size(textBoxWidth, 60);
        this.txtRubrics.ScrollBars = ScrollBars.Vertical;
        this.txtRubrics.Click += new EventHandler(this.txtField_Click);
        this.tabAdditional.Controls.Add(this.lblRubrics);
        this.tabAdditional.Controls.Add(this.txtRubrics);
        yPos += 70;

        // Files/URLs
        this.lblFiles = new Label();
        this.lblFiles.Location = new Point(10, yPos);
        this.lblFiles.Size = new Size(labelWidth, 20);
        this.lblFiles.Text = "Файлы/URL / Files/URLs:";
        this.tabAdditional.Controls.Add(this.lblFiles);
        yPos += 25;

        // TabControl for Files
        this.tabControlFiles = new TabControl();
        this.tabPageFile = new TabPage();
        this.tabPageUrl = new TabPage();
        this.tabPageArticleText = new TabPage();
        
        this.tabControlFiles.Controls.Add(this.tabPageFile);
        this.tabControlFiles.Controls.Add(this.tabPageUrl);
        this.tabControlFiles.Controls.Add(this.tabPageArticleText);
        this.tabControlFiles.Location = new Point(10, yPos);
        this.tabControlFiles.Name = "tabControlFiles";
        this.tabControlFiles.SelectedIndex = 0;
        this.tabControlFiles.Size = new Size(640, 180);
        this.tabControlFiles.TabIndex = 41;
        this.tabAdditional.Controls.Add(this.tabControlFiles);
        
        // tabPageFile
        this.tabPageFile.Name = "tabPageFile";
        this.tabPageFile.Padding = new Padding(3);
        this.tabPageFile.Size = new Size(632, 152);
        this.tabPageFile.TabIndex = 0;
        this.tabPageFile.Text = "Файл / File";
        this.tabPageFile.UseVisualStyleBackColor = true;
        
        this.lblFilePath = new Label();
        this.lblFilePath.AutoSize = true;
        this.lblFilePath.Location = new Point(10, 15);
        this.lblFilePath.Name = "lblFilePath";
        this.lblFilePath.Size = new Size(80, 15);
        this.lblFilePath.TabIndex = 0;
        this.lblFilePath.Text = "Путь к файлу:";
        this.tabPageFile.Controls.Add(this.lblFilePath);
        
        this.txtFilePath = new TextBox();
        this.txtFilePath.Location = new Point(10, 35);
        this.txtFilePath.Name = "txtFilePath";
        this.txtFilePath.Size = new Size(610, 23);
        this.txtFilePath.TabIndex = 1;
        this.txtFilePath.PlaceholderText = "article.pdf";
        this.tabPageFile.Controls.Add(this.txtFilePath);
        
        this.lblFileType = new Label();
        this.lblFileType.AutoSize = true;
        this.lblFileType.Location = new Point(10, 65);
        this.lblFileType.Name = "lblFileType";
        this.lblFileType.Size = new Size(90, 15);
        this.lblFileType.TabIndex = 2;
        this.lblFileType.Text = "Тип документа:";
        this.tabPageFile.Controls.Add(this.lblFileType);
        
        this.cmbFileType = new ComboBox();
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
        this.cmbFileType.Size = new Size(470, 23);
        this.cmbFileType.TabIndex = 3;
        this.cmbFileType.SelectedIndex = 0;
        this.tabPageFile.Controls.Add(this.cmbFileType);
        
        this.lblFileLang = new Label();
        this.lblFileLang.AutoSize = true;
        this.lblFileLang.Location = new Point(490, 65);
        this.lblFileLang.Name = "lblFileLang";
        this.lblFileLang.Size = new Size(40, 15);
        this.lblFileLang.TabIndex = 4;
        this.lblFileLang.Text = "Язык:";
        this.tabPageFile.Controls.Add(this.lblFileLang);
        
        this.cmbFileLang = new ComboBox();
        this.cmbFileLang.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbFileLang.FormattingEnabled = true;
        this.cmbFileLang.Items.AddRange(new object[] {
            "(не указан)",
            "RUS",
            "ENG"});
        this.cmbFileLang.Location = new Point(490, 85);
        this.cmbFileLang.Name = "cmbFileLang";
        this.cmbFileLang.Size = new Size(130, 23);
        this.cmbFileLang.TabIndex = 5;
        this.cmbFileLang.SelectedIndex = 0;
        this.tabPageFile.Controls.Add(this.cmbFileLang);
        
        this.btnAddFile = new Button();
        this.btnAddFile.Location = new Point(520, 115);
        this.btnAddFile.Name = "btnAddFile";
        this.btnAddFile.Size = new Size(100, 30);
        this.btnAddFile.TabIndex = 6;
        this.btnAddFile.Text = "Добавить";
        this.btnAddFile.UseVisualStyleBackColor = true;
        this.btnAddFile.Click += new EventHandler(this.btnAddFile_Click);
        this.tabPageFile.Controls.Add(this.btnAddFile);
        
        // tabPageUrl
        this.tabPageUrl.Name = "tabPageUrl";
        this.tabPageUrl.Padding = new Padding(3);
        this.tabPageUrl.Size = new Size(632, 152);
        this.tabPageUrl.TabIndex = 1;
        this.tabPageUrl.Text = "URL";
        this.tabPageUrl.UseVisualStyleBackColor = true;
        
        this.lblUrlPath = new Label();
        this.lblUrlPath.AutoSize = true;
        this.lblUrlPath.Location = new Point(10, 15);
        this.lblUrlPath.Name = "lblUrlPath";
        this.lblUrlPath.Size = new Size(65, 15);
        this.lblUrlPath.TabIndex = 0;
        this.lblUrlPath.Text = "URL адрес:";
        this.tabPageUrl.Controls.Add(this.lblUrlPath);
        
        this.txtUrlPath = new TextBox();
        this.txtUrlPath.Location = new Point(10, 35);
        this.txtUrlPath.Name = "txtUrlPath";
        this.txtUrlPath.Size = new Size(610, 23);
        this.txtUrlPath.TabIndex = 1;
        this.txtUrlPath.PlaceholderText = "https://example.com/article.pdf";
        this.tabPageUrl.Controls.Add(this.txtUrlPath);
        
        this.lblUrlType = new Label();
        this.lblUrlType.AutoSize = true;
        this.lblUrlType.Location = new Point(10, 65);
        this.lblUrlType.Name = "lblUrlType";
        this.lblUrlType.Size = new Size(90, 15);
        this.lblUrlType.TabIndex = 2;
        this.lblUrlType.Text = "Тип документа:";
        this.tabPageUrl.Controls.Add(this.lblUrlType);
        
        this.cmbUrlType = new ComboBox();
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
        this.cmbUrlType.Size = new Size(470, 23);
        this.cmbUrlType.TabIndex = 3;
        this.cmbUrlType.SelectedIndex = 0;
        this.tabPageUrl.Controls.Add(this.cmbUrlType);
        
        this.lblUrlLang = new Label();
        this.lblUrlLang.AutoSize = true;
        this.lblUrlLang.Location = new Point(490, 65);
        this.lblUrlLang.Name = "lblUrlLang";
        this.lblUrlLang.Size = new Size(40, 15);
        this.lblUrlLang.TabIndex = 4;
        this.lblUrlLang.Text = "Язык:";
        this.tabPageUrl.Controls.Add(this.lblUrlLang);
        
        this.cmbUrlLang = new ComboBox();
        this.cmbUrlLang.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbUrlLang.FormattingEnabled = true;
        this.cmbUrlLang.Items.AddRange(new object[] {
            "(не указан)",
            "RUS",
            "ENG"});
        this.cmbUrlLang.Location = new Point(490, 85);
        this.cmbUrlLang.Name = "cmbUrlLang";
        this.cmbUrlLang.Size = new Size(130, 23);
        this.cmbUrlLang.TabIndex = 5;
        this.cmbUrlLang.SelectedIndex = 0;
        this.tabPageUrl.Controls.Add(this.cmbUrlLang);
        
        this.btnAddUrl = new Button();
        this.btnAddUrl.Location = new Point(520, 115);
        this.btnAddUrl.Name = "btnAddUrl";
        this.btnAddUrl.Size = new Size(100, 30);
        this.btnAddUrl.TabIndex = 6;
        this.btnAddUrl.Text = "Добавить";
        this.btnAddUrl.UseVisualStyleBackColor = true;
        this.btnAddUrl.Click += new EventHandler(this.btnAddUrl_Click);
        this.tabPageUrl.Controls.Add(this.btnAddUrl);
        
        // tabPageArticleText
        this.tabPageArticleText.Name = "tabPageArticleText";
        this.tabPageArticleText.Padding = new Padding(3);
        this.tabPageArticleText.Size = new Size(632, 152);
        this.tabPageArticleText.TabIndex = 2;
        this.tabPageArticleText.Text = "Текст статьи / Article Text";
        this.tabPageArticleText.UseVisualStyleBackColor = true;
        
        this.lblArticleTextContent = new Label();
        this.lblArticleTextContent.AutoSize = true;
        this.lblArticleTextContent.Location = new Point(10, 15);
        this.lblArticleTextContent.Name = "lblArticleTextContent";
        this.lblArticleTextContent.Size = new Size(85, 15);
        this.lblArticleTextContent.TabIndex = 0;
        this.lblArticleTextContent.Text = "Текст статьи:";
        this.tabPageArticleText.Controls.Add(this.lblArticleTextContent);
        
        this.txtArticleTextContent = new TextBox();
        this.txtArticleTextContent.Location = new Point(10, 35);
        this.txtArticleTextContent.Multiline = true;
        this.txtArticleTextContent.Name = "txtArticleTextContent";
        this.txtArticleTextContent.ScrollBars = ScrollBars.Vertical;
        this.txtArticleTextContent.Size = new Size(610, 70);
        this.txtArticleTextContent.TabIndex = 1;
        this.tabPageArticleText.Controls.Add(this.txtArticleTextContent);
        
        this.lblArticleTextLang = new Label();
        this.lblArticleTextLang.AutoSize = true;
        this.lblArticleTextLang.Location = new Point(10, 110);
        this.lblArticleTextLang.Name = "lblArticleTextLang";
        this.lblArticleTextLang.Size = new Size(40, 15);
        this.lblArticleTextLang.TabIndex = 2;
        this.lblArticleTextLang.Text = "Язык:";
        this.tabPageArticleText.Controls.Add(this.lblArticleTextLang);
        
        this.cmbArticleTextLang = new ComboBox();
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
        this.tabPageArticleText.Controls.Add(this.cmbArticleTextLang);
        
        this.btnSetArticleText = new Button();
        this.btnSetArticleText.Location = new Point(520, 110);
        this.btnSetArticleText.Name = "btnSetArticleText";
        this.btnSetArticleText.Size = new Size(100, 30);
        this.btnSetArticleText.TabIndex = 4;
        this.btnSetArticleText.Text = "Установить";
        this.btnSetArticleText.UseVisualStyleBackColor = true;
        this.btnSetArticleText.Click += new EventHandler(this.btnSetArticleText_Click);
        this.tabPageArticleText.Controls.Add(this.btnSetArticleText);
        
        yPos += 185;
        
        // ListBox for Files/URLs
        this.lstFilesUrls = new ListBox();
        this.lstFilesUrls.FormattingEnabled = true;
        this.lstFilesUrls.ItemHeight = 15;
        this.lstFilesUrls.Location = new Point(10, yPos);
        this.lstFilesUrls.Name = "lstFilesUrls";
        this.lstFilesUrls.Size = new Size(520, 94);
        this.lstFilesUrls.TabIndex = 42;
        this.tabAdditional.Controls.Add(this.lstFilesUrls);
        
        this.btnEditFileUrl = new Button();
        this.btnEditFileUrl.Location = new Point(540, yPos);
        this.btnEditFileUrl.Name = "btnEditFileUrl";
        this.btnEditFileUrl.Size = new Size(110, 30);
        this.btnEditFileUrl.TabIndex = 43;
        this.btnEditFileUrl.Text = "Редактировать";
        this.btnEditFileUrl.UseVisualStyleBackColor = true;
        this.btnEditFileUrl.Click += new EventHandler(this.btnEditFileUrl_Click);
        this.tabAdditional.Controls.Add(this.btnEditFileUrl);
        
        this.btnRemoveFileUrl = new Button();
        this.btnRemoveFileUrl.Location = new Point(540, yPos + 36);
        this.btnRemoveFileUrl.Name = "btnRemoveFileUrl";
        this.btnRemoveFileUrl.Size = new Size(110, 30);
        this.btnRemoveFileUrl.TabIndex = 44;
        this.btnRemoveFileUrl.Text = "Удалить";
        this.btnRemoveFileUrl.UseVisualStyleBackColor = true;
        this.btnRemoveFileUrl.Click += new EventHandler(this.btnRemoveFileUrl_Click);
        this.tabAdditional.Controls.Add(this.btnRemoveFileUrl);
        
        yPos += 110;

        // References
        this.lblReferences = new Label();
        this.txtReferences = new TextBox();
        this.lblReferences.Location = new Point(10, yPos);
        this.lblReferences.Size = new Size(labelWidth, 20);
        this.lblReferences.Text = "Ссылки / References:";
        this.txtReferences.Location = new Point(200, yPos);
        this.txtReferences.Multiline = true;
        this.txtReferences.Size = new Size(textBoxWidth, 80);
        this.txtReferences.ScrollBars = ScrollBars.Vertical;
        this.txtReferences.Click += new EventHandler(this.txtField_Click);
        this.tabAdditional.Controls.Add(this.lblReferences);
        this.tabAdditional.Controls.Add(this.txtReferences);
    }
}
