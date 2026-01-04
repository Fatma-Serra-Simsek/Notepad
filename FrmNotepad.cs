namespace SimpleNotepad
{
    public partial class FrmNotepad : Form
    {
        private string currentFilePath = string.Empty;
        private bool isModified = false;

        public FrmNotepad()
        {
            InitializeComponent();
            UpdateTitle();
            UpdateStatusBar();
        }

        #region File Operations

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PromptSaveIfModified())
            {
                txtEditor.Clear();
                currentFilePath = string.Empty;
                isModified = false;
                UpdateTitle();
                UpdateStatusBar();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PromptSaveIfModified())
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|C# Files (*.cs)|*.cs|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
                            currentFilePath = openFileDialog.FileName;
                            isModified = false;
                            UpdateTitle();
                            UpdateStatusBar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Edit Operations

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtEditor.SelectionLength > 0)
            {
                txtEditor.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtEditor.SelectionLength > 0)
            {
                txtEditor.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtEditor.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.SelectAll();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmFind findForm = new FrmFind(txtEditor))
            {
                findForm.ShowDialog();
            }
        }

        #endregion

        #region Format Operations

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = txtEditor.Font;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    txtEditor.Font = fontDialog.Font;
                }
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = txtEditor.ForeColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    txtEditor.ForeColor = colorDialog.Color;
                }
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = txtEditor.BackColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    txtEditor.BackColor = colorDialog.Color;
                }
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            txtEditor.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        #endregion

        #region Help Operations

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Notepad\nVersion 1.0\n\nA basic text editor created with C# Windows Forms.",
                "About Simple Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Helper Methods

        private bool SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                return SaveFileAs();
            }
            else
            {
                try
                {
                    File.WriteAllText(currentFilePath, txtEditor.Text);
                    isModified = false;
                    UpdateTitle();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool SaveFileAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|C# Files (*.cs)|*.cs|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.FileName = string.IsNullOrEmpty(currentFilePath) ? "Untitled.txt" : Path.GetFileName(currentFilePath);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
                        currentFilePath = saveFileDialog.FileName;
                        isModified = false;
                        UpdateTitle();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return false;
        }

        private bool PromptSaveIfModified()
        {
            if (isModified)
            {
                string fileName = string.IsNullOrEmpty(currentFilePath) ? "Untitled" : Path.GetFileName(currentFilePath);
                DialogResult result = MessageBox.Show(
                    $"Do you want to save changes to {fileName}?",
                    "Simple Notepad",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    return SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "Untitled" : Path.GetFileName(currentFilePath);
            string modifiedIndicator = isModified ? "*" : "";
            this.Text = $"{fileName}{modifiedIndicator} - Simple Notepad";
        }

        private void UpdateStatusBar()
        {
            int lineCount = txtEditor.Lines.Length;
            int charCount = txtEditor.Text.Length;
            int currentLine = txtEditor.GetLineFromCharIndex(txtEditor.SelectionStart) + 1;
            int currentColumn = txtEditor.SelectionStart - txtEditor.GetFirstCharIndexOfCurrentLine() + 1;

            lblStatus.Text = $"Lines: {lineCount} | Characters: {charCount} | Ln {currentLine}, Col {currentColumn}";
        }

        #endregion

        #region Event Handlers

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            if (!isModified)
            {
                isModified = true;
                UpdateTitle();
            }
            UpdateStatusBar();
        }

        private void txtEditor_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void FrmNotepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PromptSaveIfModified())
            {
                e.Cancel = true;
            }
        }

        private void FrmNotepad_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle keyboard shortcuts
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        newToolStripMenuItem_Click(sender, e);
                        e.Handled = true;
                        break;
                    case Keys.O:
                        openToolStripMenuItem_Click(sender, e);
                        e.Handled = true;
                        break;
                    case Keys.S:
                        if (e.Shift)
                        {
                            saveAsToolStripMenuItem_Click(sender, e);
                        }
                        else
                        {
                            saveToolStripMenuItem_Click(sender, e);
                        }
                        e.Handled = true;
                        break;
                    case Keys.F:
                        findToolStripMenuItem_Click(sender, e);
                        e.Handled = true;
                        break;
                }
            }
        }

        #endregion
    }
}
