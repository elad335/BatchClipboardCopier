namespace CliboardCopy
{
    partial class WindowForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            ClipboardBegin = new Button();
            richTextBox1 = new RichTextBox();
            ResultsNum = new Label();
            linkLabel1 = new LinkLabel();
            clearClipCheckbox = new CheckBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.Location = new Point(0, 157);
            button1.Name = "button1";
            button1.Size = new Size(538, 62);
            button1.TabIndex = 0;
            button1.Text = "Stop And Output Results";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ClipboardBegin
            // 
            ClipboardBegin.Dock = DockStyle.Top;
            ClipboardBegin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ClipboardBegin.Location = new Point(0, 42);
            ClipboardBegin.Name = "ClipboardBegin";
            ClipboardBegin.Size = new Size(538, 57);
            ClipboardBegin.TabIndex = 1;
            ClipboardBegin.Text = "Begin Clipboard Listening";
            ClipboardBegin.UseVisualStyleBackColor = true;
            ClipboardBegin.Click += ClipboardBegin_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ControlLightLight;
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(0, 219);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(538, 330);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // ResultsNum
            // 
            ResultsNum.AutoSize = true;
            ResultsNum.Font = new Font("Segoe UI", 10F);
            ResultsNum.Location = new Point(203, 12);
            ResultsNum.Name = "ResultsNum";
            ResultsNum.Size = new Size(107, 19);
            ResultsNum.TabIndex = 4;
            ResultsNum.Text = "Results Saved: 0";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(373, 14);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(137, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Made By: Elad Ashkenazi";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // clearClipCheckbox
            // 
            clearClipCheckbox.AutoSize = true;
            clearClipCheckbox.Checked = true;
            clearClipCheckbox.CheckState = CheckState.Checked;
            clearClipCheckbox.Location = new Point(12, 109);
            clearClipCheckbox.Name = "clearClipCheckbox";
            clearClipCheckbox.Size = new Size(180, 19);
            clearClipCheckbox.TabIndex = 7;
            clearClipCheckbox.Text = "Clear Previous Clipboard Text";
            clearClipCheckbox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ResultsNum);
            panel1.Controls.Add(linkLabel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 42);
            panel1.TabIndex = 8;
            // 
            // WindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(538, 549);
            Controls.Add(ClipboardBegin);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(clearClipCheckbox);
            Controls.Add(richTextBox1);
            Name = "WindowForm";
            Text = "Clipboard Dumper";
            Load += WindowForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button ClipboardBegin;
        private RichTextBox richTextBox1;
        private Label ResultsNum;
        private LinkLabel linkLabel1;
        private CheckBox clearClipCheckbox;
        private Panel panel1;
    }
}
