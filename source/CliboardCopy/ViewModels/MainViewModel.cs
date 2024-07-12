using System.ComponentModel;
using CliboardCopy.Models;
using CliboardCopy.Services;

namespace CliboardCopy.ViewModels;

/// <summary>
/// Main ViewModel class
/// </summary>
public class MainViewModel : ViewModelBase
{
    private readonly IClipboardMonitorService _clipboardMonitorService;

    public MainViewModel(IClipboardMonitorService clipboardMonitorService)
    {
        Items = new BindingList<ClipboardHistoryItemBase>();
        _clipboardMonitorService = clipboardMonitorService;
        _clipboardMonitorService.ClipboardChanged += _clipboardMonitorService_ClipboardChanged;
    }

    public BindingList<ClipboardHistoryItemBase> Items { get; }

    private bool _logEnabled;

    public bool LogEnabled
    {
        get => _logEnabled;
        set
        {
            SetValue(value, out _logEnabled);
            RaisePropertyChanged(nameof(CanStartLogging));
        }
    }

    public bool CanStartLogging => !_logEnabled;

    public async Task StartLogAsync()
    {
        try
        {
            if (LogEnabled) return;

            LogEnabled = true;
            ClearHistory();
            await _clipboardMonitorService.StartAsync();
        }
        catch (Exception ex)
        {
            DisplayError(ex);
        }
    }

    public async Task StopLogAsync()
    {
        try
        {
            if (!LogEnabled) return;

            LogEnabled = false;
            await _clipboardMonitorService.StopAsync();
            ClearHistory();
        }
        catch (Exception ex)
        {
            DisplayError(ex);
        }
    }

    private void _clipboardMonitorService_ClipboardChanged(object? sender, ClipboardUpdatedEventArgs e)
    {
        try
        {
            if (e.Item == null) return;

            if (e.Item is ClipboardHistoryItemImage imageItem)
            {
                if (Items.OfType<ClipboardHistoryItemImage>().Any(item => item.ImageHash == imageItem.ImageHash)) return;
            }

            Items.Add(e.Item);
        }
        catch (Exception ex)
        {
            DisplayError(ex);
        }
    }

    protected override void OnDispose()
    {
        _clipboardMonitorService.ClipboardChanged -= _clipboardMonitorService_ClipboardChanged;
        ClearHistory();
    }

    private void ClearHistory()
    {
        try
        {
            foreach (var item in Items)
            {
                try
                {
                    item.Dispose();
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }
            }

            Items.Clear();
        }
        catch (Exception ex)
        {
            DisplayError(ex);
        }
    }
}