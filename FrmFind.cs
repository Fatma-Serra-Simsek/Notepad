namespace SimpleNotepad
{
    public partial class FrmFind : Form
    {
        private RichTextBox targetTextBox;
        private int lastFoundIndex = -1;

        public FrmFind(RichTextBox textBox)
        {
            InitializeComponent();
            targetTextBox = textBox;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please enter text to find.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringComparison comparison = chkMatchCase.Checked 
                ? StringComparison.Ordinal 
                : StringComparison.OrdinalIgnoreCase;

            int startIndex = lastFoundIndex >= 0 ? lastFoundIndex + 1 : 0;
            int foundIndex = targetTextBox.Text.IndexOf(txtSearch.Text, startIndex, comparison);

            if (foundIndex >= 0)
            {
                targetTextBox.Select(foundIndex, txtSearch.Text.Length);
                targetTextBox.ScrollToCaret();
                lastFoundIndex = foundIndex;
            }
            else
            {
                // If not found from current position, try from beginning
                foundIndex = targetTextBox.Text.IndexOf(txtSearch.Text, 0, comparison);
                
                if (foundIndex >= 0)
                {
                    targetTextBox.Select(foundIndex, txtSearch.Text.Length);
                    targetTextBox.ScrollToCaret();
                    lastFoundIndex = foundIndex;
                }
                else
                {
                    MessageBox.Show($"Cannot find \"{txtSearch.Text}\"", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lastFoundIndex = -1;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lastFoundIndex = -1; // Reset search position when search text changes
        }

        private void FrmFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastFoundIndex = -1;
        }
    }
}
