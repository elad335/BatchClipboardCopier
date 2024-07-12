using System.Diagnostics;

namespace CliboardCopy
{
    /// <summary>
    /// Main application view
    /// </summary>
    public partial class WindowForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public WindowForm()
        {
            InitializeComponent();
        }

        private Thread tracker_thread;
        private UInt32 tracking_id = 0;
        private HashSet<string> results = new HashSet<string>();

        private void ClipboardBegin_Click(object sender, EventArgs e)
        {
            if (!ClipboardBegin.Enabled)
            {
                return;
            }

            if (clearClipCheckbox.Checked)
            {
                Clipboard.Clear();
            }

            ClipboardBegin.Enabled = false;
            clearClipCheckbox.Enabled = false;

            if (tracker_thread == null)
            {
                // ID to invaldate discarded callbacks
                UInt32 old_id = ++tracking_id;

                tracker_thread = new Thread(() =>
                {
                    string last_cached = "";
                    string current = "";
                    IAsyncResult async_res = null;

                    while (old_id == tracking_id)
                    {
                        Thread.Sleep(10);

                        if (async_res != null && !async_res.IsCompleted)
                        {
                            continue;
                        }

                        async_res = this.BeginInvoke(() =>
                        {
                            try
                            {
                                current = Clipboard.GetText();
                            }
                            catch
                            {
                                current = "";
                            }

                            if (current.Length == 0 || old_id != tracking_id)
                            {
                                return;
                            }

                            // Optimization (not relavant as long as it is the same thread
                            //if (last_cached != current)
                            {
                                // Main thread
                                //lock (this)
                                {
                                    if (!results.Contains(current))
                                    {
                                        results.Add(current);
                                        ResultsNum.Text = "Results count: " + results.Count;
                                        button1.Enabled = true;
                                    }
                                }
                            }

                            last_cached = current;
                        });
                    }
                });

                tracker_thread.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!button1.Enabled)
            {
                return;
            }

            button1.Enabled = false;

            if (tracker_thread != null)
            {
                tracking_id++;
                tracker_thread.Join();
                tracker_thread = null;

                string result = "";

                //lock (this)
                {
                    foreach (string s in results)
                    {
                        if (result.Length != 0)
                        {
                            result += "\n";
                        }

                        // TODO: Format the result to deal with newlines
                        result += s;
                    }

                    results.Clear();
                }

                if (result.Length != 0)
                {
                    Console.WriteLine(result);
                    richTextBox1.Text = result;
                }
            }

            clearClipCheckbox.Enabled = true;
            ClipboardBegin.Enabled = true;
        }

        private void WindowForm_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("http://www.github.com/elad335") { UseShellExecute = true });
            linkLabel1.LinkVisited = true;
        }
    }
}