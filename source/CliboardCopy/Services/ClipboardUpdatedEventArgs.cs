using CliboardCopy.Models;

namespace CliboardCopy.Services;

public class ClipboardUpdatedEventArgs : EventArgs
{
    public ClipboardUpdatedEventArgs(ClipboardHistoryItemBase? item)
    {
        Item = item;
    }

    public ClipboardHistoryItemBase? Item { get; }
}