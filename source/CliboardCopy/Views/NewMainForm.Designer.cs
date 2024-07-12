namespace CliboardCopy
{
    partial class NewMainForm
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
            btnStopClipboardLogging = new Button();
            btnStartClipboardLogging = new Button();
            ResultsNum = new Label();
            lnkLabelCreatedBy = new LinkLabel();
            panel1 = new Panel();
            tabControlViewModes = new TabControl();
            tabTextViewMode = new TabPage();
            historyTextViewMode1 = new UserControls.HistoryTextViewMode();
            tabImageViewMode = new TabPage();
            panel1.SuspendLayout();
            tabControlViewModes.SuspendLayout();
            tabTextViewMode.SuspendLayout();
            SuspendLayout();
            // 
            // btnStopClipboardLogging
            // 
            btnStopClipboardLogging.Dock = DockStyle.Bottom;
            btnStopClipboardLogging.Enabled = false;
            btnStopClipboardLogging.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStopClipboardLogging.Location = new Point(0, 227);
            btnStopClipboardLogging.Margin = new Padding(5, 6, 5, 6);
            btnStopClipboardLogging.Name = "btnStopClipboardLogging";
            btnStopClipboardLogging.Size = new Size(922, 124);
            btnStopClipboardLogging.TabIndex = 0;
            btnStopClipboardLogging.Text = "Stop And Output Results";
            btnStopClipboardLogging.UseVisualStyleBackColor = true;
            btnStopClipboardLogging.Click += btnStopClipboardLogging_Click;
            // 
            // btnStartClipboardLogging
            // 
            btnStartClipboardLogging.Dock = DockStyle.Top;
            btnStartClipboardLogging.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStartClipboardLogging.Location = new Point(0, 84);
            btnStartClipboardLogging.Margin = new Padding(5, 6, 5, 6);
            btnStartClipboardLogging.Name = "btnStartClipboardLogging";
            btnStartClipboardLogging.Size = new Size(922, 114);
            btnStartClipboardLogging.TabIndex = 1;
            btnStartClipboardLogging.Text = "Begin Clipboard Listening";
            btnStartClipboardLogging.UseVisualStyleBackColor = true;
            btnStartClipboardLogging.Click += btnStartClipboardLogging_Click;
            // 
            // ResultsNum
            // 
            ResultsNum.AutoSize = true;
            ResultsNum.Font = new Font("Segoe UI", 10F);
            ResultsNum.Location = new Point(348, 24);
            ResultsNum.Margin = new Padding(5, 0, 5, 0);
            ResultsNum.Name = "ResultsNum";
            ResultsNum.Size = new Size(184, 32);
            ResultsNum.TabIndex = 4;
            ResultsNum.Text = "Results Saved: 0";
            // 
            // lnkLabelCreatedBy
            // 
            lnkLabelCreatedBy.AutoSize = true;
            lnkLabelCreatedBy.Location = new Point(639, 28);
            lnkLabelCreatedBy.Margin = new Padding(5, 0, 5, 0);
            lnkLabelCreatedBy.Name = "lnkLabelCreatedBy";
            lnkLabelCreatedBy.Size = new Size(244, 30);
            lnkLabelCreatedBy.TabIndex = 6;
            lnkLabelCreatedBy.TabStop = true;
            lnkLabelCreatedBy.Text = "Made By: Elad335";
            lnkLabelCreatedBy.LinkClicked += lnkLabelCreatedBy_LinkClicked;
            // 
            // panel1
            // 
            panel1.Controls.Add(ResultsNum);
            panel1.Controls.Add(lnkLabelCreatedBy);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(922, 84);
            panel1.TabIndex = 8;
            // 
            // tabControlViewModes
            // 
            tabControlViewModes.Controls.Add(tabTextViewMode);
            tabControlViewModes.Controls.Add(tabImageViewMode);
            tabControlViewModes.Dock = DockStyle.Bottom;
            tabControlViewModes.Location = new Point(0, 351);
            tabControlViewModes.Name = "tabControlViewModes";
            tabControlViewModes.SelectedIndex = 0;
            tabControlViewModes.Size = new Size(922, 747);
            tabControlViewModes.TabIndex = 9;
            // 
            // tabTextViewMode
            // 
            tabTextViewMode.Controls.Add(historyTextViewMode1);
            tabTextViewMode.Location = new Point(4, 39);
            tabTextViewMode.Name = "tabTextViewMode";
            tabTextViewMode.Padding = new Padding(3);
            tabTextViewMode.Size = new Size(914, 704);
            tabTextViewMode.TabIndex = 0;
            tabTextViewMode.Text = "Text Mode";
            tabTextViewMode.UseVisualStyleBackColor = true;
            // 
            // historyTextViewMode1
            // 
            historyTextViewMode1.Dock = DockStyle.Fill;
            historyTextViewMode1.Items = null;
            historyTextViewMode1.Location = new Point(3, 3);
            historyTextViewMode1.Name = "historyTextViewMode1";
            historyTextViewMode1.Size = new Size(908, 698);
            historyTextViewMode1.TabIndex = 0;
            // 
            // tabImageViewMode
            // 
            tabImageViewMode.Location = new Point(4, 39);
            tabImageViewMode.Name = "tabImageViewMode";
            tabImageViewMode.Padding = new Padding(3);
            tabImageViewMode.Size = new Size(914, 704);
            tabImageViewMode.TabIndex = 1;
            tabImageViewMode.Text = "Images";
            tabImageViewMode.UseVisualStyleBackColor = true;
            // 
            // NewMainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(922, 1098);
            Controls.Add(btnStartClipboardLogging);
            Controls.Add(panel1);
            Controls.Add(btnStopClipboardLogging);
            Controls.Add(tabControlViewModes);
            Margin = new Padding(5, 6, 5, 6);
            Name = "NewMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clipboard Dumper";
            FormClosing += NewMainForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControlViewModes.ResumeLayout(false);
            tabTextViewMode.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStopClipboardLogging;
        private Button btnStartClipboardLogging;
        private Label ResultsNum;
        private LinkLabel lnkLabelCreatedBy;
        private Panel panel1;
        private TabControl tabControlViewModes;
        private TabPage tabTextViewMode;
        private TabPage tabImageViewMode;
        private UserControls.HistoryTextViewMode historyTextViewMode1;
    }
}
