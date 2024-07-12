using System.Runtime.InteropServices;
using CliboardCopy.Models;

namespace CliboardCopy.Services;

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

    /// <summary>
    /// Message-only helper form
    /// </summary>
    private class MessageOnlyWindow : Form
    {
        private readonly SynchronizationContext? _synchronizationContext;
        private readonly Action<ClipboardHistoryItemBase?> _onClipboardUpdated;
        private readonly ClipboardHistoryItemFactory _historyItemFactory;

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
        }

        public void Start()
        {
            AddClipboardFormatListener(Handle);
        }

        public void Stop()
        {
            RemoveClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg != 0x031D) return; // WM_CLIPBOARDUPDATE

                var item = _historyItemFactory.BuildNewItem();
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

    public Task StartAsync()
    {
        _messageOnlyWindow.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync()
    {
        _messageOnlyWindow.Stop();
        return Task.CompletedTask;
    }
}