using System.Drawing;

namespace IssueTracker
{
    public partial class SimpleInputForm : Form
    {
        public string InputText => txtInput.Text;

        public SimpleInputForm(string title, string prompt, string initialValue = "", bool multiline = false)
        {
            InitializeComponent();
            this.Text = title;
            lblPrompt.Text = prompt;
            txtInput.Text = initialValue;

            if (multiline)
            {
                const int textAreaHeight = 140;
                const int buttonTop = 40 + textAreaHeight + 12;  // 192
                const int formHeight = buttonTop + 30 + 16;       // 238

                txtInput.Multiline = true;
                txtInput.ScrollBars = ScrollBars.Vertical;
                txtInput.AcceptsReturn = true;
                txtInput.Height = textAreaHeight;

                // Must clear Bottom anchor BEFORE resizing form, otherwise
                // WinForms recalculates Top from the anchor and overrides our value
                btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnOk.Top = buttonTop;
                btnCancel.Top = buttonTop;

                this.ClientSize = new Size(this.ClientSize.Width, formHeight);
            }
        }

        private void SimpleInputForm_Load(object sender, EventArgs e)
        {
            txtInput.Select();
            txtInput.SelectionStart = txtInput.Text.Length;
        }
    }
}