using System.Diagnostics;

namespace CliboardCopy
{
    public partial class WindowForm : Form
    {
        public WindowForm()
        {
            InitializeComponent();
        }

        Thread tracker_thread;
        bool should_track = false;
        Mutex mutex = new Mutex();
        HashSet<string> results = new HashSet<string>();

        private void ClipboardBegin_Click(object sender, EventArgs e)
        {
            ClipboardBegin.Enabled = false;

            if (tracker_thread == null)
            {
                should_track = true;

                tracker_thread = new Thread(() =>
                {
                    var getter = () => { try { return Clipboard.GetText(); } catch { return ""; } };

                    string last_cached = "";
                    string current = "";
                    IAsyncResult async_res = null;

                    while (should_track)
                    {
                        if (async_res != null && !async_res.IsCompleted)
                        {
                            Thread.Sleep(10);
                            continue;
                        }

                        async_res = this.BeginInvoke(() =>
                        {
                            current = Clipboard.GetText();

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
                                    }
                                }
                            }

                            last_cached = current;
                        });
                    }
                });

                tracker_thread.Start();
            }

            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            should_track = false;

            if (tracker_thread != null)
            {
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
