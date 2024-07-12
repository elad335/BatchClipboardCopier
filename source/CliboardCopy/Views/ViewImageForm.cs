namespace CliboardCopy
{
    public partial class ViewImageForm : Form
    {
        public ViewImageForm()
        {
            InitializeComponent();
        }

        public void Intialize(Image image)
        {
            if (image == null) return;

            pictureBox1.Image = image;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                if (saveImageDialog.ShowDialog() == DialogResult.Cancel) return;

                var selectedExtension = Path.GetExtension(saveImageDialog.FileName);
                switch (selectedExtension)
                {
                    case ".jpg":
                        pictureBox1.Image.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case ".png":
                        pictureBox1.Image.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                Close();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}