namespace elibraryXMLApp;

partial class AboutForm
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
        this.pictureBoxLogo = new PictureBox();
        this.lblTitle = new Label();
        this.lblVersion = new Label();
        this.lblDeveloper = new Label();
        this.lblLicense = new Label();
        this.panelHeader = new Panel();
        this.panelContent = new Panel();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
        this.panelHeader.SuspendLayout();
        this.panelContent.SuspendLayout();
        this.SuspendLayout();
        
        // 
        // panelHeader
        // 
        this.panelHeader.BackColor = Color.FromArgb(45, 45, 48);
        this.panelHeader.Controls.Add(this.pictureBoxLogo);
        this.panelHeader.Dock = DockStyle.Top;
        this.panelHeader.Location = new Point(0, 0);
        this.panelHeader.Name = "panelHeader";
        this.panelHeader.Size = new Size(500, 150);
        this.panelHeader.TabIndex = 0;
        
        // 
        // pictureBoxLogo
        // 
        this.pictureBoxLogo.Location = new Point(175, 10);
        this.pictureBoxLogo.Name = "pictureBoxLogo";
        this.pictureBoxLogo.Size = new Size(150, 130);
        this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
        this.pictureBoxLogo.TabIndex = 0;
        this.pictureBoxLogo.TabStop = false;
        
        // Load the icon image
        try
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ico.png");
            if (File.Exists(iconPath))
            {
                this.pictureBoxLogo.Image = Image.FromFile(iconPath);
            }
        }
        catch
        {
            // If image loading fails, continue without image
        }
        
        // 
        // panelContent
        // 
        this.panelContent.BackColor = Color.White;
        this.panelContent.Controls.Add(this.lblTitle);
        this.panelContent.Controls.Add(this.lblVersion);
        this.panelContent.Controls.Add(this.lblDeveloper);
        this.panelContent.Controls.Add(this.lblLicense);
        this.panelContent.Dock = DockStyle.Fill;
        this.panelContent.Location = new Point(0, 150);
        this.panelContent.Name = "panelContent";
        this.panelContent.Size = new Size(500, 250);
        this.panelContent.TabIndex = 1;
        
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = false;
        this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.FromArgb(45, 45, 48);
        this.lblTitle.Location = new Point(30, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(440, 40);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "eLibrary XML";
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // lblVersion
        // 
        this.lblVersion.AutoSize = false;
        this.lblVersion.Font = new Font("Segoe UI", 10F);
        this.lblVersion.ForeColor = Color.FromArgb(100, 100, 100);
        this.lblVersion.Location = new Point(30, 65);
        this.lblVersion.Name = "lblVersion";
        this.lblVersion.Size = new Size(440, 25);
        this.lblVersion.TabIndex = 1;
        this.lblVersion.Text = "Версия 2.3";
        this.lblVersion.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // lblDeveloper
        // 
        this.lblDeveloper.AutoSize = false;
        this.lblDeveloper.Font = new Font("Segoe UI", 10F);
        this.lblDeveloper.ForeColor = Color.FromArgb(70, 70, 70);
        this.lblDeveloper.Location = new Point(30, 100);
        this.lblDeveloper.Name = "lblDeveloper";
        this.lblDeveloper.Size = new Size(440, 50);
        this.lblDeveloper.TabIndex = 2;
        this.lblDeveloper.Text = "Разработано Danayer\nпри поддержке ИФ МГТУ ГА";
        this.lblDeveloper.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // lblLicense
        // 
        this.lblLicense.AutoSize = false;
        this.lblLicense.Font = new Font("Segoe UI", 9F);
        this.lblLicense.ForeColor = Color.FromArgb(100, 100, 100);
        this.lblLicense.Location = new Point(30, 155);
        this.lblLicense.Name = "lblLicense";
        this.lblLicense.Size = new Size(440, 35);
        this.lblLicense.TabIndex = 3;
        this.lblLicense.Text = "Распространяется по лицензии\nGNU General Public License (GPL) версии 3 (GPL v3)";
        this.lblLicense.TextAlign = ContentAlignment.MiddleCenter;
        
        // 
        // AboutForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(500, 400);
        this.Controls.Add(this.panelContent);
        this.Controls.Add(this.panelHeader);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AboutForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "О программе";
        
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
        
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
        this.panelHeader.ResumeLayout(false);
        this.panelContent.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private PictureBox pictureBoxLogo;
    private Label lblTitle;
    private Label lblVersion;
    private Label lblDeveloper;
    private Label lblLicense;
    private Panel panelHeader;
    private Panel panelContent;
}
