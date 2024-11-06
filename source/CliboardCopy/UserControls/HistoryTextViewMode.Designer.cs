namespace CliboardCopy.UserControls
{
    partial class HistoryTextViewMode
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtContent = new RichTextBox();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Dock = DockStyle.Fill;
            txtContent.Location = new Point(0, 0);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(513, 391);
            txtContent.TabIndex = 0;
            txtContent.Text = "";
            txtContent.LinkClicked += txtContent_LinkClicked;
            // 
            // HistoryTextViewMode
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtContent);
            Name = "HistoryTextViewMode";
            Size = new Size(513, 391);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtContent;

        public string GetText()
        {
            return txtContent.Text;
        }
    }
}
