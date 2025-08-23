namespace IssueTracker
{
    public partial class SimpleInputForm : Form
    {
        public string InputText => txtInput.Text;

        public SimpleInputForm(string title, string prompt, string initialValue = "")
        {
            InitializeComponent();
            this.Text = title;
            lblPrompt.Text = prompt;
            txtInput.Text = initialValue;
        }

        private void SimpleInputForm_Load(object sender, EventArgs e)
        {
            txtInput.Select();
        }
    }
}