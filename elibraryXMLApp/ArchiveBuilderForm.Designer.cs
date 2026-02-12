namespace elibraryXMLApp;

partial class ArchiveBuilderForm
{
    private System.ComponentModel.IContainer components = null;
    
    private GroupBox grpCover;
    private TextBox txtCoverPath;
    private Button btnBrowseCover;
    private Label lblCoverInfo;
    
    private GroupBox grpCoverRussian;
    private TextBox txtCoverRussianPath;
    private Button btnBrowseCoverRussian;
    private Label lblCoverRussianInfo;
    
    private GroupBox grpCoverEnglish;
    private TextBox txtCoverEnglishPath;
    private Button btnBrowseCoverEnglish;
    private Label lblCoverEnglishInfo;
    
    private GroupBox grpArticles;
    private ListBox lstArticles;
    private Button btnBrowseArticles;
    private Button btnClearArticles;
    private Label lblArticleCount;
    private Label lblArticlesInfo;
    
    private GroupBox grpCombined;
    private TextBox txtCombinedPath;
    private Button btnBrowseCombined;
    private Label lblCombinedInfo;
    
    private GroupBox grpXml;
    private TextBox txtXmlPath;
    private Button btnBrowseXml;
    private Label lblXmlInfo;
    
    private GroupBox grpOutput;
    private TextBox txtOutputPath;
    private Button btnBrowseOutput;
    private Label lblOutputInfo;
    
    private GroupBox grpLog;
    private TextBox txtLog;
    
    private Panel pnlButtons;
    private Button btnBuildArchive;

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
        this.grpCover = new GroupBox();
        this.txtCoverPath = new TextBox();
        this.btnBrowseCover = new Button();
        this.lblCoverInfo = new Label();
        
        this.grpCoverRussian = new GroupBox();
        this.txtCoverRussianPath = new TextBox();
        this.btnBrowseCoverRussian = new Button();
        this.lblCoverRussianInfo = new Label();
        
        this.grpCoverEnglish = new GroupBox();
        this.txtCoverEnglishPath = new TextBox();
        this.btnBrowseCoverEnglish = new Button();
        this.lblCoverEnglishInfo = new Label();
        
        this.grpArticles = new GroupBox();
        this.lstArticles = new ListBox();
        this.btnBrowseArticles = new Button();
        this.btnClearArticles = new Button();
        this.lblArticleCount = new Label();
        this.lblArticlesInfo = new Label();
        
        this.grpCombined = new GroupBox();
        this.txtCombinedPath = new TextBox();
        this.btnBrowseCombined = new Button();
        this.lblCombinedInfo = new Label();
        
        this.grpXml = new GroupBox();
        this.txtXmlPath = new TextBox();
        this.btnBrowseXml = new Button();
        this.lblXmlInfo = new Label();
        
        this.grpOutput = new GroupBox();
        this.txtOutputPath = new TextBox();
        this.btnBrowseOutput = new Button();
        this.lblOutputInfo = new Label();
        
        this.grpLog = new GroupBox();
        this.txtLog = new TextBox();
        
        this.pnlButtons = new Panel();
        this.btnBuildArchive = new Button();
        
        this.grpCover.SuspendLayout();
        this.grpCoverRussian.SuspendLayout();
        this.grpCoverEnglish.SuspendLayout();
        this.grpArticles.SuspendLayout();
        this.grpCombined.SuspendLayout();
        this.grpXml.SuspendLayout();
        this.grpOutput.SuspendLayout();
        this.grpLog.SuspendLayout();
        this.pnlButtons.SuspendLayout();
        this.SuspendLayout();

        // 
        // grpCover (Legacy - Optional)
        // 
        this.grpCover.Controls.Add(this.lblCoverInfo);
        this.grpCover.Controls.Add(this.txtCoverPath);
        this.grpCover.Controls.Add(this.btnBrowseCover);
        this.grpCover.Location = new Point(12, 12);
        this.grpCover.Name = "grpCover";
        this.grpCover.Size = new Size(760, 100);
        this.grpCover.TabIndex = 0;
        this.grpCover.TabStop = false;
        this.grpCover.Text = "1. Обложка выпуска (Legacy) / Cover Image (Legacy)";
        this.grpCover.Visible = false; // Hidden by default, using new separate covers

        // 
        // lblCoverInfo
        // 
        this.lblCoverInfo.AutoSize = true;
        this.lblCoverInfo.ForeColor = Color.Gray;
        this.lblCoverInfo.Location = new Point(10, 25);
        this.lblCoverInfo.Name = "lblCoverInfo";
        this.lblCoverInfo.Size = new Size(400, 15);
        this.lblCoverInfo.TabIndex = 0;
        this.lblCoverInfo.Text = "Формат: JPEG, разрешение: 300 DPI, высота: 900 пикселей";

        // 
        // txtCoverPath
        // 
        this.txtCoverPath.Location = new Point(10, 50);
        this.txtCoverPath.Name = "txtCoverPath";
        this.txtCoverPath.ReadOnly = true;
        this.txtCoverPath.Size = new Size(630, 23);
        this.txtCoverPath.TabIndex = 1;

        // 
        // btnBrowseCover
        // 
        this.btnBrowseCover.Location = new Point(650, 49);
        this.btnBrowseCover.Name = "btnBrowseCover";
        this.btnBrowseCover.Size = new Size(100, 25);
        this.btnBrowseCover.TabIndex = 2;
        this.btnBrowseCover.Text = "Обзор...";
        this.btnBrowseCover.UseVisualStyleBackColor = true;
        this.btnBrowseCover.Click += new EventHandler(this.btnBrowseCover_Click);

        // 
        // grpCoverRussian
        // 
        this.grpCoverRussian.Controls.Add(this.lblCoverRussianInfo);
        this.grpCoverRussian.Controls.Add(this.txtCoverRussianPath);
        this.grpCoverRussian.Controls.Add(this.btnBrowseCoverRussian);
        this.grpCoverRussian.Location = new Point(12, 12);
        this.grpCoverRussian.Name = "grpCoverRussian";
        this.grpCoverRussian.Size = new Size(760, 100);
        this.grpCoverRussian.TabIndex = 0;
        this.grpCoverRussian.TabStop = false;
        this.grpCoverRussian.Text = "1. Обложка выпуска на русском / Cover Image (Russian)";

        // 
        // lblCoverRussianInfo
        // 
        this.lblCoverRussianInfo.AutoSize = true;
        this.lblCoverRussianInfo.ForeColor = Color.Gray;
        this.lblCoverRussianInfo.Location = new Point(10, 25);
        this.lblCoverRussianInfo.Name = "lblCoverRussianInfo";
        this.lblCoverRussianInfo.Size = new Size(400, 15);
        this.lblCoverRussianInfo.TabIndex = 0;
        this.lblCoverRussianInfo.Text = "Формат: JPEG, разрешение: 300 DPI, высота: 900 пикселей";

        // 
        // txtCoverRussianPath
        // 
        this.txtCoverRussianPath.Location = new Point(10, 50);
        this.txtCoverRussianPath.Name = "txtCoverRussianPath";
        this.txtCoverRussianPath.ReadOnly = true;
        this.txtCoverRussianPath.Size = new Size(630, 23);
        this.txtCoverRussianPath.TabIndex = 1;

        // 
        // btnBrowseCoverRussian
        // 
        this.btnBrowseCoverRussian.Location = new Point(650, 49);
        this.btnBrowseCoverRussian.Name = "btnBrowseCoverRussian";
        this.btnBrowseCoverRussian.Size = new Size(100, 25);
        this.btnBrowseCoverRussian.TabIndex = 2;
        this.btnBrowseCoverRussian.Text = "Обзор...";
        this.btnBrowseCoverRussian.UseVisualStyleBackColor = true;
        this.btnBrowseCoverRussian.Click += new EventHandler(this.btnBrowseCoverRussian_Click);

        // 
        // grpCoverEnglish
        // 
        this.grpCoverEnglish.Controls.Add(this.lblCoverEnglishInfo);
        this.grpCoverEnglish.Controls.Add(this.txtCoverEnglishPath);
        this.grpCoverEnglish.Controls.Add(this.btnBrowseCoverEnglish);
        this.grpCoverEnglish.Location = new Point(12, 118);
        this.grpCoverEnglish.Name = "grpCoverEnglish";
        this.grpCoverEnglish.Size = new Size(760, 100);
        this.grpCoverEnglish.TabIndex = 1;
        this.grpCoverEnglish.TabStop = false;
        this.grpCoverEnglish.Text = "2. Обложка выпуска на английском / Cover Image (English)";

        // 
        // lblCoverEnglishInfo
        // 
        this.lblCoverEnglishInfo.AutoSize = true;
        this.lblCoverEnglishInfo.ForeColor = Color.Gray;
        this.lblCoverEnglishInfo.Location = new Point(10, 25);
        this.lblCoverEnglishInfo.Name = "lblCoverEnglishInfo";
        this.lblCoverEnglishInfo.Size = new Size(400, 15);
        this.lblCoverEnglishInfo.TabIndex = 0;
        this.lblCoverEnglishInfo.Text = "Format: JPEG, resolution: 300 DPI, height: 900 pixels";

        // 
        // txtCoverEnglishPath
        // 
        this.txtCoverEnglishPath.Location = new Point(10, 50);
        this.txtCoverEnglishPath.Name = "txtCoverEnglishPath";
        this.txtCoverEnglishPath.ReadOnly = true;
        this.txtCoverEnglishPath.Size = new Size(630, 23);
        this.txtCoverEnglishPath.TabIndex = 1;

        // 
        // btnBrowseCoverEnglish
        // 
        this.btnBrowseCoverEnglish.Location = new Point(650, 49);
        this.btnBrowseCoverEnglish.Name = "btnBrowseCoverEnglish";
        this.btnBrowseCoverEnglish.Size = new Size(100, 25);
        this.btnBrowseCoverEnglish.TabIndex = 2;
        this.btnBrowseCoverEnglish.Text = "Browse...";
        this.btnBrowseCoverEnglish.UseVisualStyleBackColor = true;
        this.btnBrowseCoverEnglish.Click += new EventHandler(this.btnBrowseCoverEnglish_Click);

        // 
        // grpArticles
        // 
        this.grpArticles.Controls.Add(this.lblArticlesInfo);
        this.grpArticles.Controls.Add(this.lblArticleCount);
        this.grpArticles.Controls.Add(this.lstArticles);
        this.grpArticles.Controls.Add(this.btnBrowseArticles);
        this.grpArticles.Controls.Add(this.btnClearArticles);
        this.grpArticles.Location = new Point(12, 224);
        this.grpArticles.Name = "grpArticles";
        this.grpArticles.Size = new Size(760, 180);
        this.grpArticles.TabIndex = 2;
        this.grpArticles.TabStop = false;
        this.grpArticles.Text = "3. PDF файлы статей / Article PDFs";

        // 
        // lblArticlesInfo
        // 
        this.lblArticlesInfo.AutoSize = true;
        this.lblArticlesInfo.ForeColor = Color.Gray;
        this.lblArticlesInfo.Location = new Point(10, 25);
        this.lblArticlesInfo.Name = "lblArticlesInfo";
        this.lblArticlesInfo.Size = new Size(450, 15);
        this.lblArticlesInfo.TabIndex = 0;
        this.lblArticlesInfo.Text = "Отдельные PDF статей, оптимизированные для WEB, разрешение рисунков: 300 DPI";

        // 
        // lblArticleCount
        // 
        this.lblArticleCount.AutoSize = true;
        this.lblArticleCount.Location = new Point(10, 50);
        this.lblArticleCount.Name = "lblArticleCount";
        this.lblArticleCount.Size = new Size(60, 15);
        this.lblArticleCount.TabIndex = 1;
        this.lblArticleCount.Text = "Файлов: 0";

        // 
        // lstArticles
        // 
        this.lstArticles.FormattingEnabled = true;
        this.lstArticles.ItemHeight = 15;
        this.lstArticles.Location = new Point(10, 70);
        this.lstArticles.Name = "lstArticles";
        this.lstArticles.Size = new Size(630, 94);
        this.lstArticles.TabIndex = 2;

        // 
        // btnBrowseArticles
        // 
        this.btnBrowseArticles.Location = new Point(650, 70);
        this.btnBrowseArticles.Name = "btnBrowseArticles";
        this.btnBrowseArticles.Size = new Size(100, 40);
        this.btnBrowseArticles.TabIndex = 3;
        this.btnBrowseArticles.Text = "Добавить файлы...";
        this.btnBrowseArticles.UseVisualStyleBackColor = true;
        this.btnBrowseArticles.Click += new EventHandler(this.btnBrowseArticles_Click);

        // 
        // btnClearArticles
        // 
        this.btnClearArticles.Location = new Point(650, 116);
        this.btnClearArticles.Name = "btnClearArticles";
        this.btnClearArticles.Size = new Size(100, 25);
        this.btnClearArticles.TabIndex = 4;
        this.btnClearArticles.Text = "Очистить";
        this.btnClearArticles.UseVisualStyleBackColor = true;
        this.btnClearArticles.Click += new EventHandler(this.btnClearArticles_Click);

        // 
        // grpCombined
        // 
        this.grpCombined.Controls.Add(this.lblCombinedInfo);
        this.grpCombined.Controls.Add(this.txtCombinedPath);
        this.grpCombined.Controls.Add(this.btnBrowseCombined);
        this.grpCombined.Location = new Point(12, 410);
        this.grpCombined.Name = "grpCombined";
        this.grpCombined.Size = new Size(760, 100);
        this.grpCombined.TabIndex = 3;
        this.grpCombined.TabStop = false;
        this.grpCombined.Text = "4. Объединенный PDF выпуска / Combined Issue PDF";

        // 
        // lblCombinedInfo
        // 
        this.lblCombinedInfo.ForeColor = Color.Gray;
        this.lblCombinedInfo.Location = new Point(10, 25);
        this.lblCombinedInfo.Name = "lblCombinedInfo";
        this.lblCombinedInfo.Size = new Size(740, 15);
        this.lblCombinedInfo.TabIndex = 0;
        this.lblCombinedInfo.Text = "PDF всего выпуска (только лицевая обложка, без рекламы), оптимизирован для WEB";

        // 
        // txtCombinedPath
        // 
        this.txtCombinedPath.Location = new Point(10, 50);
        this.txtCombinedPath.Name = "txtCombinedPath";
        this.txtCombinedPath.ReadOnly = true;
        this.txtCombinedPath.Size = new Size(630, 23);
        this.txtCombinedPath.TabIndex = 1;

        // 
        // btnBrowseCombined
        // 
        this.btnBrowseCombined.Location = new Point(650, 49);
        this.btnBrowseCombined.Name = "btnBrowseCombined";
        this.btnBrowseCombined.Size = new Size(100, 25);
        this.btnBrowseCombined.TabIndex = 2;
        this.btnBrowseCombined.Text = "Обзор...";
        this.btnBrowseCombined.UseVisualStyleBackColor = true;
        this.btnBrowseCombined.Click += new EventHandler(this.btnBrowseCombined_Click);

        // 
        // grpXml
        // 
        this.grpXml.Controls.Add(this.lblXmlInfo);
        this.grpXml.Controls.Add(this.txtXmlPath);
        this.grpXml.Controls.Add(this.btnBrowseXml);
        this.grpXml.Location = new Point(12, 516);
        this.grpXml.Name = "grpXml";
        this.grpXml.Size = new Size(760, 100);
        this.grpXml.TabIndex = 4;
        this.grpXml.TabStop = false;
        this.grpXml.Text = "5. XML метаданные выпуска / Issue XML Metadata";

        // 
        // lblXmlInfo
        // 
        this.lblXmlInfo.ForeColor = Color.Gray;
        this.lblXmlInfo.Location = new Point(10, 25);
        this.lblXmlInfo.Name = "lblXmlInfo";
        this.lblXmlInfo.Size = new Size(740, 15);
        this.lblXmlInfo.TabIndex = 0;
        this.lblXmlInfo.Text = "Опционально: прикрепите XML файл метаданных, размеченный по схеме elibrary (иначе будет сгенерирован автоматически)";

        // 
        // txtXmlPath
        // 
        this.txtXmlPath.Location = new Point(10, 50);
        this.txtXmlPath.Name = "txtXmlPath";
        this.txtXmlPath.ReadOnly = true;
        this.txtXmlPath.Size = new Size(630, 23);
        this.txtXmlPath.TabIndex = 1;

        // 
        // btnBrowseXml
        // 
        this.btnBrowseXml.Location = new Point(650, 49);
        this.btnBrowseXml.Name = "btnBrowseXml";
        this.btnBrowseXml.Size = new Size(100, 25);
        this.btnBrowseXml.TabIndex = 2;
        this.btnBrowseXml.Text = "Обзор...";
        this.btnBrowseXml.UseVisualStyleBackColor = true;
        this.btnBrowseXml.Click += new EventHandler(this.btnBrowseXml_Click);

        // 
        // grpOutput
        // 
        this.grpOutput.Controls.Add(this.lblOutputInfo);
        this.grpOutput.Controls.Add(this.txtOutputPath);
        this.grpOutput.Controls.Add(this.btnBrowseOutput);
        this.grpOutput.Location = new Point(12, 622);
        this.grpOutput.Name = "grpOutput";
        this.grpOutput.Size = new Size(760, 90);
        this.grpOutput.TabIndex = 5;
        this.grpOutput.TabStop = false;
        this.grpOutput.Text = "6. Папка для сохранения / Output Folder";

        // 
        // lblOutputInfo
        // 
        this.lblOutputInfo.AutoSize = true;
        this.lblOutputInfo.ForeColor = Color.Gray;
        this.lblOutputInfo.Location = new Point(10, 25);
        this.lblOutputInfo.Name = "lblOutputInfo";
        this.lblOutputInfo.Size = new Size(300, 15);
        this.lblOutputInfo.TabIndex = 0;
        this.lblOutputInfo.Text = "Будут созданы подпапки: cover, articles, metadata";

        // 
        // txtOutputPath
        // 
        this.txtOutputPath.Location = new Point(10, 50);
        this.txtOutputPath.Name = "txtOutputPath";
        this.txtOutputPath.ReadOnly = true;
        this.txtOutputPath.Size = new Size(630, 23);
        this.txtOutputPath.TabIndex = 1;

        // 
        // btnBrowseOutput
        // 
        this.btnBrowseOutput.Location = new Point(650, 49);
        this.btnBrowseOutput.Name = "btnBrowseOutput";
        this.btnBrowseOutput.Size = new Size(100, 25);
        this.btnBrowseOutput.TabIndex = 2;
        this.btnBrowseOutput.Text = "Обзор...";
        this.btnBrowseOutput.UseVisualStyleBackColor = true;
        this.btnBrowseOutput.Click += new EventHandler(this.btnBrowseOutput_Click);

        // 
        // grpLog
        // 
        this.grpLog.Controls.Add(this.txtLog);
        this.grpLog.Location = new Point(12, 718);
        this.grpLog.Name = "grpLog";
        this.grpLog.Size = new Size(760, 150);
        this.grpLog.TabIndex = 6;
        this.grpLog.TabStop = false;
        this.grpLog.Text = "Журнал / Log";

        // 
        // txtLog
        // 
        this.txtLog.BackColor = Color.White;
        this.txtLog.Dock = DockStyle.Fill;
        this.txtLog.Font = new Font("Consolas", 9F);
        this.txtLog.Location = new Point(3, 19);
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.ReadOnly = true;
        this.txtLog.ScrollBars = ScrollBars.Vertical;
        this.txtLog.Size = new Size(754, 128);
        this.txtLog.TabIndex = 0;

        // 
        // pnlButtons
        // 
        this.pnlButtons.Controls.Add(this.btnBuildArchive);
        this.pnlButtons.Location = new Point(12, 874);
        this.pnlButtons.Name = "pnlButtons";
        this.pnlButtons.Size = new Size(760, 50);
        this.pnlButtons.TabIndex = 7;

        // 
        // btnBuildArchive
        // 
        this.btnBuildArchive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnBuildArchive.Location = new Point(290, 10);
        this.btnBuildArchive.Name = "btnBuildArchive";
        this.btnBuildArchive.Size = new Size(180, 35);
        this.btnBuildArchive.TabIndex = 0;
        this.btnBuildArchive.Text = "📦 Подготовить архив";
        this.btnBuildArchive.UseVisualStyleBackColor = true;
        this.btnBuildArchive.Click += new EventHandler(this.btnBuildArchive_Click);

        // 
        // ArchiveBuilderForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(784, 931);
        this.Controls.Add(this.pnlButtons);
        this.Controls.Add(this.grpLog);
        this.Controls.Add(this.grpOutput);
        this.Controls.Add(this.grpXml);
        this.Controls.Add(this.grpCombined);
        this.Controls.Add(this.grpArticles);
        this.Controls.Add(this.grpCoverEnglish);
        this.Controls.Add(this.grpCoverRussian);
        this.Controls.Add(this.grpCover);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ArchiveBuilderForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Подготовка архива выпуска / Issue Archive Builder";
        
        this.grpCover.ResumeLayout(false);
        this.grpCover.PerformLayout();
        this.grpCoverRussian.ResumeLayout(false);
        this.grpCoverRussian.PerformLayout();
        this.grpCoverEnglish.ResumeLayout(false);
        this.grpCoverEnglish.PerformLayout();
        this.grpArticles.ResumeLayout(false);
        this.grpArticles.PerformLayout();
        this.grpCombined.ResumeLayout(false);
        this.grpCombined.PerformLayout();
        this.grpXml.ResumeLayout(false);
        this.grpXml.PerformLayout();
        this.grpOutput.ResumeLayout(false);
        this.grpOutput.PerformLayout();
        this.grpLog.ResumeLayout(false);
        this.grpLog.PerformLayout();
        this.pnlButtons.ResumeLayout(false);
        
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
}
