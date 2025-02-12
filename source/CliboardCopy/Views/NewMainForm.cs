using System.Diagnostics;
using System.Text;
using CliboardCopy.Services;
using CliboardCopy.ViewModels;

namespace CliboardCopy
{
    /// <summary>
    /// Main application view
    /// </summary>
    public partial class NewMainForm : Form
    {
        private readonly MainViewModel _viewModel = null!;

        /// <summary>
        ///
        /// </summary>
        public NewMainForm()
        {
            InitializeComponent();
            WriteLog("", ref log_file);
            _viewModel = new MainViewModel(WindowsClipboardMonitorService.Instance);
            btnStartClipboardLogging.DataBindings.Add(nameof(Button.Enabled), _viewModel, nameof(_viewModel.CanStartLogging));
            btnStopClipboardLogging.DataBindings.Add(nameof(Button.Enabled), _viewModel, nameof(_viewModel.LogEnabled));
            historyTextViewMode1.DataBindings.Add(nameof(historyTextViewMode1.Items), _viewModel, nameof(_viewModel.Items));
            _viewModel.InsertChangeFunc(textBox1_TextChanged);
        }

        private async void btnStartClipboardLogging_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viewModel.LogEnabled) return;

                if (MessageBox.Show("Clear clipboard?", "Starting new session", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Clipboard.Clear();
                }

                await _viewModel.StartLogAsync();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private async void btnStopClipboardLogging_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_viewModel.LogEnabled) return;

                await _viewModel.StopLogAsync();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void lnkLabelCreatedBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                lnkLabelCreatedBy.LinkVisited = true;
                Process.Start(new ProcessStartInfo("http://www.github.com/elad335") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        protected void DisplayError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NewMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Dispose();
        }

         FileStream log_file = null;

        public static void WriteLog(string strLog, ref FileStream fileStream)
        {
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
 
            if (fileStream == null || string.IsNullOrEmpty(strLog))
            {
                string logFilePath = "C:\\ClipBoardCopy\\";

                logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);

                if (!logDirInfo.Exists) logDirInfo.Create();
            
                fileStream = new FileStream(logFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fileStream.SetLength(0);
                fileStream.Seek(0, SeekOrigin.Begin);
                strLog = "";
            }

            fileStream.Write(Encoding.ASCII.GetBytes(strLog.Substring((int)fileStream.Position)));
            fileStream.Flush();
        }

        public void textBox1_TextChanged(object? sender, EventArgs e)
        {
            string text = ResultsTypeTxt.Text;
            string history = historyTextViewMode1.GetText();

            WriteLog(history, ref log_file);

            if (history.Length < text.Length || text.Length == 0)
            {
                ResultsNum.Text = "Results Saved: 0";
                return;
            }

            int count = 0;

            for (int i = 0; i < history.Length;)
            {
                if (text[0] != history[i])
                {
                    i++;
                    continue;
                }

                if (string.Compare(text, 0, history, i, text.Length) == 0)
                {
                    i += text.Length;
                    count++;
                }
                else
                {
                    i++;
                }
            }

            ResultsNum.Text = "Results Saved: " + count.ToString();
        }
    }
}
