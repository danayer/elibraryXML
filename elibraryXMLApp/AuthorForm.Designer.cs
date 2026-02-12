namespace elibraryXMLApp;

partial class AuthorForm
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
        this.lblSurname = new Label();
        this.txtSurname = new TextBox();
        this.lblInitials = new Label();
        this.txtInitials = new TextBox();
        this.lblOrgName = new Label();
        this.txtOrgName = new TextBox();
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.lblSurnameEng = new Label();
        this.txtSurnameEng = new TextBox();
        this.lblInitialsEng = new Label();
        this.txtInitialsEng = new TextBox();
        this.lblOrgNameEng = new Label();
        this.txtOrgNameEng = new TextBox();
        this.lblOrcid = new Label();
        this.txtOrcid = new TextBox();
        this.lblScopusId = new Label();
        this.txtScopusId = new TextBox();
        this.lblResearcherId = new Label();
        this.txtResearcherId = new TextBox();
        this.lblSpin = new Label();
        this.txtSpin = new TextBox();
        this.lblRole = new Label();
        this.cmbRole = new ComboBox();
        this.lblCorrespondent = new Label();
        this.cmbCorrespondent = new ComboBox();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.SuspendLayout();
        // 
        // lblSurname
        // 
        this.lblSurname.AutoSize = true;
        this.lblSurname.Location = new Point(20, 20);
        this.lblSurname.Name = "lblSurname";
        this.lblSurname.Size = new Size(64, 15);
        this.lblSurname.TabIndex = 0;
        this.lblSurname.Text = "Фамилия: *";
        // 
        // txtSurname
        // 
        this.txtSurname.Location = new Point(150, 17);
        this.txtSurname.Name = "txtSurname";
        this.txtSurname.Size = new Size(300, 23);
        this.txtSurname.TabIndex = 1;
        // 
        // lblInitials
        // 
        this.lblInitials.AutoSize = true;
        this.lblInitials.Location = new Point(20, 60);
        this.lblInitials.Name = "lblInitials";
        this.lblInitials.Size = new Size(64, 15);
        this.lblInitials.TabIndex = 2;
        this.lblInitials.Text = "Инициалы:";
        // 
        // txtInitials
        // 
        this.txtInitials.Location = new Point(150, 57);
        this.txtInitials.Name = "txtInitials";
        this.txtInitials.Size = new Size(300, 23);
        this.txtInitials.TabIndex = 3;
        // 
        // lblOrgName
        // 
        this.lblOrgName.AutoSize = true;
        this.lblOrgName.Location = new Point(20, 100);
        this.lblOrgName.Name = "lblOrgName";
        this.lblOrgName.Size = new Size(85, 15);
        this.lblOrgName.TabIndex = 4;
        this.lblOrgName.Text = "Организация:";
        // 
        // txtOrgName
        // 
        this.txtOrgName.Location = new Point(150, 97);
        this.txtOrgName.Multiline = true;
        this.txtOrgName.Name = "txtOrgName";
        this.txtOrgName.Size = new Size(300, 60);
        this.txtOrgName.TabIndex = 5;
        // 
        // lblEmail
        // 
        this.lblEmail.AutoSize = true;
        this.lblEmail.Location = new Point(20, 170);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new Size(44, 15);
        this.lblEmail.TabIndex = 6;
        this.lblEmail.Text = "E-mail:";
        // 
        // txtEmail
        // 
        this.txtEmail.Location = new Point(150, 167);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new Size(300, 23);
        this.txtEmail.TabIndex = 7;
        // 
        // lblSurnameEng
        // 
        this.lblSurnameEng.AutoSize = true;
        this.lblSurnameEng.Location = new Point(20, 200);
        this.lblSurnameEng.Name = "lblSurnameEng";
        this.lblSurnameEng.Size = new Size(105, 15);
        this.lblSurnameEng.TabIndex = 8;
        this.lblSurnameEng.Text = "Фамилия (ENG): *";
        // 
        // txtSurnameEng
        // 
        this.txtSurnameEng.Location = new Point(150, 197);
        this.txtSurnameEng.Name = "txtSurnameEng";
        this.txtSurnameEng.Size = new Size(300, 23);
        this.txtSurnameEng.TabIndex = 9;
        // 
        // lblInitialsEng
        // 
        this.lblInitialsEng.AutoSize = true;
        this.lblInitialsEng.Location = new Point(20, 230);
        this.lblInitialsEng.Name = "lblInitialsEng";
        this.lblInitialsEng.Size = new Size(80, 15);
        this.lblInitialsEng.TabIndex = 10;
        this.lblInitialsEng.Text = "Инициалы (ENG):";
        // 
        // txtInitialsEng
        // 
        this.txtInitialsEng.Location = new Point(150, 227);
        this.txtInitialsEng.Name = "txtInitialsEng";
        this.txtInitialsEng.Size = new Size(300, 23);
        this.txtInitialsEng.TabIndex = 11;
        // 
        // lblOrgNameEng
        // 
        this.lblOrgNameEng.AutoSize = true;
        this.lblOrgNameEng.Location = new Point(20, 260);
        this.lblOrgNameEng.Name = "lblOrgNameEng";
        this.lblOrgNameEng.Size = new Size(120, 15);
        this.lblOrgNameEng.TabIndex = 12;
        this.lblOrgNameEng.Text = "Организация (ENG):";
        // 
        // txtOrgNameEng
        // 
        this.txtOrgNameEng.Location = new Point(150, 257);
        this.txtOrgNameEng.Multiline = true;
        this.txtOrgNameEng.Name = "txtOrgNameEng";
        this.txtOrgNameEng.Size = new Size(300, 60);
        this.txtOrgNameEng.TabIndex = 13;
        // 
        // lblOrcid
        // 
        this.lblOrcid.AutoSize = true;
        this.lblOrcid.Location = new Point(20, 330);
        this.lblOrcid.Name = "lblOrcid";
        this.lblOrcid.Size = new Size(50, 15);
        this.lblOrcid.TabIndex = 14;
        this.lblOrcid.Text = "ORCID:";
        // 
        // txtOrcid
        // 
        this.txtOrcid.Location = new Point(150, 327);
        this.txtOrcid.Name = "txtOrcid";
        this.txtOrcid.Size = new Size(300, 23);
        this.txtOrcid.TabIndex = 15;
        // 
        // lblScopusId
        // 
        this.lblScopusId.AutoSize = true;
        this.lblScopusId.Location = new Point(20, 360);
        this.lblScopusId.Name = "lblScopusId";
        this.lblScopusId.Size = new Size(67, 15);
        this.lblScopusId.TabIndex = 16;
        this.lblScopusId.Text = "Scopus ID:";
        // 
        // txtScopusId
        // 
        this.txtScopusId.Location = new Point(150, 357);
        this.txtScopusId.Name = "txtScopusId";
        this.txtScopusId.Size = new Size(300, 23);
        this.txtScopusId.TabIndex = 17;
        // 
        // lblResearcherId
        // 
        this.lblResearcherId.AutoSize = true;
        this.lblResearcherId.Location = new Point(20, 390);
        this.lblResearcherId.Name = "lblResearcherId";
        this.lblResearcherId.Size = new Size(88, 15);
        this.lblResearcherId.TabIndex = 18;
        this.lblResearcherId.Text = "Researcher ID:";
        // 
        // txtResearcherId
        // 
        this.txtResearcherId.Location = new Point(150, 387);
        this.txtResearcherId.Name = "txtResearcherId";
        this.txtResearcherId.Size = new Size(300, 23);
        this.txtResearcherId.TabIndex = 19;
        // 
        // lblSpin
        // 
        this.lblSpin.AutoSize = true;
        this.lblSpin.Location = new Point(20, 420);
        this.lblSpin.Name = "lblSpin";
        this.lblSpin.Size = new Size(37, 15);
        this.lblSpin.TabIndex = 20;
        this.lblSpin.Text = "SPIN:";
        // 
        // txtSpin
        // 
        this.txtSpin.Location = new Point(150, 417);
        this.txtSpin.Name = "txtSpin";
        this.txtSpin.Size = new Size(300, 23);
        this.txtSpin.TabIndex = 21;
        this.txtSpin.PlaceholderText = "XXXX-XXXX";
        // 
        // lblRole
        // 
        this.lblRole.AutoSize = true;
        this.lblRole.Location = new Point(20, 450);
        this.lblRole.Name = "lblRole";
        this.lblRole.Size = new Size(38, 15);
        this.lblRole.TabIndex = 22;
        this.lblRole.Text = "Роль:";
        // 
        // cmbRole
        // 
        this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbRole.FormattingEnabled = true;
        this.cmbRole.Items.AddRange(new object[] {
            "(не указано)",
            "0 - Редактор",
            "1 - Ответственный редактор",
            "2 - Научный редактор",
            "3 - Переводчик",
            "4 - Составитель",
            "5 - Фотограф",
            "6 - Художник",
            "9 - Иллюстратор",
            "10 - Автор комментария",
            "20 - Автор вступительной статьи",
            "23 - Рецензент",
            "24 - Автор предисловия",
            "25 - Автор послесловия",
            "26 - Научный руководитель",
            "48 - Редактор перевода"});
        this.cmbRole.Location = new Point(150, 447);
        this.cmbRole.Name = "cmbRole";
        this.cmbRole.Size = new Size(300, 23);
        this.cmbRole.TabIndex = 23;
        // 
        // lblCorrespondent
        // 
        this.lblCorrespondent.AutoSize = true;
        this.lblCorrespondent.Location = new Point(20, 480);
        this.lblCorrespondent.Name = "lblCorrespondent";
        this.lblCorrespondent.Size = new Size(125, 15);
        this.lblCorrespondent.TabIndex = 24;
        this.lblCorrespondent.Text = "Автор-корреспондент:";
        // 
        // cmbCorrespondent
        // 
        this.cmbCorrespondent.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbCorrespondent.FormattingEnabled = true;
        this.cmbCorrespondent.Items.AddRange(new object[] {
            "(не указано)",
            "0 - Автор",
            "1 - Автор, отвечающий за переписку"});
        this.cmbCorrespondent.Location = new Point(150, 477);
        this.cmbCorrespondent.Name = "cmbCorrespondent";
        this.cmbCorrespondent.Size = new Size(300, 23);
        this.cmbCorrespondent.TabIndex = 25;
        // 
        // btnSave
        // 
        this.btnSave.Location = new Point(230, 520);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new Size(100, 30);
        this.btnSave.TabIndex = 26;
        this.btnSave.Text = "Сохранить";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new Point(350, 520);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new Size(100, 30);
        this.btnCancel.TabIndex = 27;
        this.btnCancel.Text = "Отмена";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
        // 
        // AuthorForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(480, 570);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.cmbCorrespondent);
        this.Controls.Add(this.lblCorrespondent);
        this.Controls.Add(this.cmbRole);
        this.Controls.Add(this.lblRole);
        this.Controls.Add(this.txtSpin);
        this.Controls.Add(this.lblSpin);
        this.Controls.Add(this.txtResearcherId);
        this.Controls.Add(this.lblResearcherId);
        this.Controls.Add(this.txtScopusId);
        this.Controls.Add(this.lblScopusId);
        this.Controls.Add(this.txtOrcid);
        this.Controls.Add(this.lblOrcid);
        this.Controls.Add(this.txtOrgNameEng);
        this.Controls.Add(this.lblOrgNameEng);
        this.Controls.Add(this.txtInitialsEng);
        this.Controls.Add(this.lblInitialsEng);
        this.Controls.Add(this.txtSurnameEng);
        this.Controls.Add(this.lblSurnameEng);
        this.Controls.Add(this.txtEmail);
        this.Controls.Add(this.lblEmail);
        this.Controls.Add(this.txtOrgName);
        this.Controls.Add(this.lblOrgName);
        this.Controls.Add(this.txtInitials);
        this.Controls.Add(this.lblInitials);
        this.Controls.Add(this.txtSurname);
        this.Controls.Add(this.lblSurname);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AuthorForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Редактор автора";
        
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

    private Label lblSurname;
    private TextBox txtSurname;
    private Label lblInitials;
    private TextBox txtInitials;
    private Label lblOrgName;
    private TextBox txtOrgName;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblSurnameEng;
    private TextBox txtSurnameEng;
    private Label lblInitialsEng;
    private TextBox txtInitialsEng;
    private Label lblOrgNameEng;
    private TextBox txtOrgNameEng;
    private Label lblOrcid;
    private TextBox txtOrcid;
    private Label lblScopusId;
    private TextBox txtScopusId;
    private Label lblResearcherId;
    private TextBox txtResearcherId;
    private Label lblSpin;
    private TextBox txtSpin;
    private Label lblRole;
    private ComboBox cmbRole;
    private Label lblCorrespondent;
    private ComboBox cmbCorrespondent;
    private Button btnSave;
    private Button btnCancel;
}
