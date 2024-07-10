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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.Location = new Point(-2, 123);
            button1.Name = "button1";
            button1.Size = new Size(540, 62);
            button1.TabIndex = 0;
            button1.Text = "Stop And Output Results";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ClipboardBegin
            // 
            ClipboardBegin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ClipboardBegin.Location = new Point(-2, 36);
            ClipboardBegin.Name = "ClipboardBegin";
            ClipboardBegin.Size = new Size(540, 67);
            ClipboardBegin.TabIndex = 1;
            ClipboardBegin.Text = "Begin Clipboard Listening";
            ClipboardBegin.UseVisualStyleBackColor = true;
            ClipboardBegin.Click += ClipboardBegin_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(0, 204);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(538, 330);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // ResultsNum
            // 
            ResultsNum.AutoSize = true;
            ResultsNum.Location = new Point(195, 9);
            ResultsNum.Name = "ResultsNum";
            ResultsNum.Size = new Size(90, 15);
            ResultsNum.TabIndex = 4;
            ResultsNum.Text = "Results count: 0";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(364, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(137, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Made By: Elad Ashkenazi";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // WindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(538, 534);
            Controls.Add(linkLabel1);
            Controls.Add(ResultsNum);
            Controls.Add(richTextBox1);
            Controls.Add(ClipboardBegin);
            Controls.Add(button1);
            Name = "WindowForm";
            Text = "Cliboard Listener";
            Load += WindowForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button ClipboardBegin;
        private RichTextBox richTextBox1;
        private Label ResultsNum;
        private LinkLabel linkLabel1;
    }
}
