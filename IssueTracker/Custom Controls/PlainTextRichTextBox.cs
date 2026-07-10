namespace IssueTracker.Custom_Controls
{
    public class PlainTextRichTextBox : RichTextBox
    {
        private const int WM_PASTE = 0x0302;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                PasteAsPlainText();
                return; // swallow the default (formatted) paste
            }
            base.WndProc(ref m);
        }

        private void PasteAsPlainText()
        {
            if (!Clipboard.ContainsText()) return;

            string text = Clipboard.GetText(TextDataFormat.UnicodeText);
            int caretPos = SelectionStart + text.Length;

            SelectedText = text; // replaces any current selection, no formatting carried over
            SelectionStart = caretPos;
            SelectionLength = 0;
        }
    }
}
