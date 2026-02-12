namespace elibraryXMLApp;

public partial class AboutForm : Form
{
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    private static extern bool DestroyIcon(IntPtr handle);

    public AboutForm()
    {
        InitializeComponent();
    }
}
