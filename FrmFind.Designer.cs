namespace SimpleNotepad
{
    partial class FrmFind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFind = new Label();
            txtSearch = new TextBox();
            chkMatchCase = new CheckBox();
            btnFindNext = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblFind
            // 
            lblFind.AutoSize = true;
            lblFind.Location = new Point(14, 20);
            lblFind.Margin = new Padding(4, 0, 4, 0);
            lblFind.Name = "lblFind";
            lblFind.Size = new Size(65, 15);
            lblFind.TabIndex = 0;
            lblFind.Text = "Find what:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(87, 16);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(280, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // chkMatchCase
            // 
            chkMatchCase.AutoSize = true;
            chkMatchCase.Location = new Point(87, 52);
            chkMatchCase.Margin = new Padding(4, 3, 4, 3);
            chkMatchCase.Name = "chkMatchCase";
            chkMatchCase.Size = new Size(88, 19);
            chkMatchCase.TabIndex = 2;
            chkMatchCase.Text = "Match case";
            chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // btnFindNext
            // 
            btnFindNext.Location = new Point(387, 14);
            btnFindNext.Margin = new Padding(4, 3, 4, 3);
            btnFindNext.Name = "btnFindNext";
            btnFindNext.Size = new Size(100, 27);
            btnFindNext.TabIndex = 3;
            btnFindNext.Text = "Find Next";
            btnFindNext.UseVisualStyleBackColor = true;
            btnFindNext.Click += btnFindNext_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(387, 48);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 27);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmFind
            // 
            AcceptButton = btnFindNext;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(504, 90);
            Controls.Add(btnClose);
            Controls.Add(btnFindNext);
            Controls.Add(chkMatchCase);
            Controls.Add(txtSearch);
            Controls.Add(lblFind);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFind";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Find";
            FormClosing += FrmFind_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFind;
        private TextBox txtSearch;
        private CheckBox chkMatchCase;
        private Button btnFindNext;
        private Button btnClose;
    }
}
