using elibraryXMLApp.Models;

namespace elibraryXMLApp;

public partial class AuthorForm : Form
{
    public Author Author { get; private set; }

    public AuthorForm(Author? author = null)
    {
        InitializeComponent();
        Author = author ?? new Author();
        
        // Initialize ComboBoxes with default selection
        cmbRole.SelectedIndex = 0; // Default to "(не указано)"
        cmbCorrespondent.SelectedIndex = 0; // Default to "(не указано)"
        
        if (author != null && Author.IndividInfoList.Count > 0)
        {
            LoadAuthorData();
        }
    }

    private void LoadAuthorData()
    {
        // Load RUS data (primary language)
        var rusInfo = Author.IndividInfoList.FirstOrDefault(i => i.Lang == "RUS");
        if (rusInfo != null)
        {
            txtSurname.Text = rusInfo.Surname;
            txtInitials.Text = rusInfo.Initials ?? "";
            txtOrgName.Text = rusInfo.OrgName ?? "";
            txtEmail.Text = rusInfo.Email ?? "";
        }
        
        // Load ENG data (English translation)
        var engInfo = Author.IndividInfoList.FirstOrDefault(i => i.Lang == "ENG");
        if (engInfo != null)
        {
            txtSurnameEng.Text = engInfo.Surname;
            txtInitialsEng.Text = engInfo.Initials ?? "";
            txtOrgNameEng.Text = engInfo.OrgName ?? "";
        }
        
        txtOrcid.Text = Author.AuthorCodes?.Orcid ?? "";
        txtScopusId.Text = Author.AuthorCodes?.ScopusId ?? "";
        txtResearcherId.Text = Author.AuthorCodes?.ResearcherId ?? "";
        txtSpin.Text = Author.AuthorCodes?.Spin ?? "";
        
        // Load Role
        if (string.IsNullOrEmpty(Author.Role))
        {
            cmbRole.SelectedIndex = 0; // "(не указано)" - no role specified
        }
        else
        {
            int roleIndex = Author.Role switch
            {
                "0" => 1,
                "1" => 2,
                "2" => 3,
                "3" => 4,
                "4" => 5,
                "5" => 6,
                "6" => 7,
                "9" => 8,
                "10" => 9,
                "20" => 10,
                "23" => 11,
                "24" => 12,
                "25" => 13,
                "26" => 14,
                "48" => 15,
                _ => 0
            };
            cmbRole.SelectedIndex = roleIndex;
        }
        
        // Load Correspondent
        if (string.IsNullOrEmpty(Author.Correspondent))
        {
            cmbCorrespondent.SelectedIndex = 0; // "(не указано)" - not specified
        }
        else
        {
            int corrIndex = Author.Correspondent switch
            {
                "0" => 1,
                "1" => 2,
                _ => 0
            };
            cmbCorrespondent.SelectedIndex = corrIndex;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtSurname.Text))
        {
            MessageBox.Show("Пожалуйста, введите фамилию автора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Update or create RUS entry
        var rusInfo = Author.IndividInfoList.FirstOrDefault(i => i.Lang == "RUS");
        if (rusInfo == null)
        {
            rusInfo = new IndividInfo { Lang = "RUS" };
            Author.IndividInfoList.Add(rusInfo);
        }
        
        rusInfo.Surname = txtSurname.Text;
        rusInfo.Initials = txtInitials.Text;
        rusInfo.OrgName = txtOrgName.Text;
        rusInfo.Email = txtEmail.Text;

        // Update or create ENG entry if any English fields are provided
        if (!string.IsNullOrWhiteSpace(txtSurnameEng.Text) ||
            !string.IsNullOrWhiteSpace(txtInitialsEng.Text) ||
            !string.IsNullOrWhiteSpace(txtOrgNameEng.Text))
        {
            var engInfo = Author.IndividInfoList.FirstOrDefault(i => i.Lang == "ENG");
            if (engInfo == null)
            {
                engInfo = new IndividInfo { Lang = "ENG" };
                Author.IndividInfoList.Add(engInfo);
            }
            
            engInfo.Surname = txtSurnameEng.Text;
            engInfo.Initials = txtInitialsEng.Text;
            engInfo.OrgName = txtOrgNameEng.Text;
            // Email is only stored in RUS entry (not duplicated)
        }
        else
        {
            // Remove ENG entry if all English fields are empty
            var engInfo = Author.IndividInfoList.FirstOrDefault(i => i.Lang == "ENG");
            if (engInfo != null)
            {
                Author.IndividInfoList.Remove(engInfo);
            }
        }

        if (!string.IsNullOrWhiteSpace(txtOrcid.Text) || !string.IsNullOrWhiteSpace(txtScopusId.Text) ||
            !string.IsNullOrWhiteSpace(txtResearcherId.Text) || !string.IsNullOrWhiteSpace(txtSpin.Text))
        {
            Author.AuthorCodes = new AuthorCodes 
            { 
                Orcid = txtOrcid.Text,
                ScopusId = txtScopusId.Text,
                ResearcherId = txtResearcherId.Text,
                Spin = txtSpin.Text
            };
        }
        
        // Save Role
        Author.Role = cmbRole.SelectedIndex switch
        {
            0 => null, // "(не указано)" - no role value
            1 => "0",
            2 => "1",
            3 => "2",
            4 => "3",
            5 => "4",
            6 => "5",
            7 => "6",
            8 => "9",
            9 => "10",
            10 => "20",
            11 => "23",
            12 => "24",
            13 => "25",
            14 => "26",
            15 => "48",
            _ => null
        };
        
        // Save Correspondent
        Author.Correspondent = cmbCorrespondent.SelectedIndex switch
        {
            0 => null, // "(не указано)" - not specified
            1 => "0",
            2 => "1",
            _ => null
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
