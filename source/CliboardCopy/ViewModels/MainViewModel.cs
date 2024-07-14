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

    /// <summary>
    /// Clipboard history log records
    /// </summary>
    public BindingList<ClipboardHistoryItemBase> Items { get; }

    private bool _logEnabled;

    /// <summary>
    /// TRUE - If logging enabled
    /// </summary>
    public bool LogEnabled
    {
        get => _logEnabled;
        set
        {
            SetValue(value, out _logEnabled);
            RaisePropertyChanged(nameof(CanStartLogging));
        }
    }

    /// <summary>
    /// TRUE - If user can enable logging
    /// </summary>
    public bool CanStartLogging => !_logEnabled;

    /// <summary>
    /// Start clipboard changes logging
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Stop clipboard changes logging
    /// </summary>
    /// <returns></returns>
    public async Task StopLogAsync()
    {
        try
        {
            if (!LogEnabled) return;

            LogEnabled = false;
            await _clipboardMonitorService.StopAsync();
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

    private void _clipboardMonitorService_ClipboardChanged(object? sender, ClipboardUpdatedEventArgs e)
    {
        try
        {
            if (e.Item == null) return;

            if (e.Item is ClipboardHistoryItemImage imageItem)
            {
                // If image with same hash already in log - skip it
                if (Items.OfType<ClipboardHistoryItemImage>().Any(item => item.ImageHash == imageItem.ImageHash)) return;
            }

            if (e.Item is ClipboardHistoryItemText textItem)
            {
                // If text exists - skip it
                if (Items.OfType<ClipboardHistoryItemText>().Any(item => item.Text == textItem.Text)) return;
            }

            Items.Add(e.Item);
        }
        catch (Exception ex)
        {
            DisplayError(ex);
        }
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