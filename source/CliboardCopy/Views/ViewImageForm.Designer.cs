namespace CliboardCopy
{
    partial class ViewImageForm
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
            pictureBox1 = new PictureBox();
            btnSaveImage = new Button();
            btnCancel = new Button();
            saveImageDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(744, 507);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnSaveImage
            // 
            btnSaveImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveImage.Location = new Point(591, 533);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(165, 40);
            btnSaveImage.TabIndex = 1;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += btnSaveImage_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 533);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // saveImageDialog
            // 
            saveImageDialog.Filter = "JPEG|*.jpg|PNG|*.png";
            // 
            // ViewImageForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 585);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveImage);
            Controls.Add(pictureBox1);
            Name = "ViewImageForm";
            Text = "Save image?";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnSaveImage;
        private Button btnCancel;
        private SaveFileDialog saveImageDialog;
    }
}