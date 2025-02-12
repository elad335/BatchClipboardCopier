using System.Runtime.InteropServices;
using CliboardCopy.Models;

namespace CliboardCopy.Services;

/// <summary>
/// Windows API based clipboard monitoring service implementation
/// </summary>
/// <remarks>Service exists as Singletone</remarks>
public class WindowsClipboardMonitorService : IClipboardMonitorService
{
    private static readonly WindowsClipboardMonitorService _instance = null!;
    private static SynchronizationContext? _uiSynchronizationContext;
    private readonly MessageOnlyWindow _messageOnlyWindow;

    private WindowsClipboardMonitorService()
    {
        _uiSynchronizationContext = SynchronizationContext.Current;
        _messageOnlyWindow = new MessageOnlyWindow(_uiSynchronizationContext, true, (text) => ClipboardChanged?.Invoke(this, new ClipboardUpdatedEventArgs(text)));
    }

    /// <summary>
    /// Singletone instance
    /// </summary>
    public static WindowsClipboardMonitorService Instance => _instance ?? new WindowsClipboardMonitorService();

    /// <summary>
    /// Clipboard changed notification event
    /// </summary>
    /// <remarks>UI-thread friendly</remarks>
    public event EventHandler<ClipboardUpdatedEventArgs> ClipboardChanged = null!;

    /// <inheritdoc/>
    public Task StartAsync()
    {
        _messageOnlyWindow.Start();
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task StopAsync()
    {
        _messageOnlyWindow.Stop();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Message-only helper form
    /// </summary>
    /// <remarks>Unvisible form used to monitor clipboard changed events</remarks>
    private class MessageOnlyWindow : Form
    {
        private readonly SynchronizationContext? _synchronizationContext;
        private readonly Action<ClipboardHistoryItemBase?> _onClipboardUpdated;
        private readonly ClipboardHistoryItemFactory _historyItemFactory;
        private bool use_fallback = false;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MessageOnlyWindow(SynchronizationContext? synchronizationContext, bool logImages, Action<ClipboardHistoryItemBase?> onClipboardUpdated)
        {
            _historyItemFactory = new ClipboardHistoryItemFactory(logImages);
            _synchronizationContext = synchronizationContext;
            _onClipboardUpdated = onClipboardUpdated;
            SetParent(Handle, new IntPtr(-3)); // Setup window as MESSAGE ONLY
            Start();
            use_fallback = true;
        }

        public void Start()
        {
            AddClipboardFormatListener(Handle);
        }

        public void Stop()
        {
            RemoveClipboardFormatListener(Handle);
        }

        string last_cached = "";
        int last_image_id = 0;
        protected override void WndProc(ref Message m)
        {
            do
            {
                if (!use_fallback)
                {
                    break;
                }

                string last_cached = "";
                string current = "";

                Thread.Sleep(10);

                current = Clipboard.GetText();

                if (!string.IsNullOrWhiteSpace(current) && current != last_cached)
                {
                    last_cached = current;
                    var item = _historyItemFactory.BuildNewItem(false);

                    if (item == null)
                    {

                    }
                    else if (_synchronizationContext != null)
                    {
                        _synchronizationContext.Post(obj => _onClipboardUpdated.Invoke(item), null);
                    }
                    else
                    {
                        _onClipboardUpdated.Invoke(item);
                    }
                }

                if (Clipboard.ContainsImage())
                {
                    Image? img = Clipboard.GetImage();

                    if (img != null)
                    {
                        int hash = img.GetHashCode();

                        if (hash != last_image_id)
                        {
                            last_image_id = hash;
                            var item = _historyItemFactory.BuildNewItem(true);

                            if (item == null)
                            {

                            }
                            else if (_synchronizationContext != null)
                            {
                                _synchronizationContext.Post(obj => _onClipboardUpdated.Invoke(item), null);
                            }
                            else
                            {
                                _onClipboardUpdated.Invoke(item);
                            }
                        }
                    }
                }
                return;
            }
            while (false);

            try
            {
                if (m.Msg != 0x031D) return; // WM_CLIPBOARDUPDATE

                var item = _historyItemFactory.BuildNewItem(false);
                if (item == null) return;

                if (_synchronizationContext != null)
                {
                    _synchronizationContext.Post(obj => _onClipboardUpdated.Invoke(item), null);
                }
                else
                {
                    _onClipboardUpdated.Invoke(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.WndProc(ref m);
            }
        }
    }
}