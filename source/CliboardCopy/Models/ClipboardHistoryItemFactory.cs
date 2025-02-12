namespace CliboardCopy.Models;

/// <summary>
/// Clipboard history items factory class
/// </summary>
public class ClipboardHistoryItemFactory
{
    private readonly bool _logImages;

    public ClipboardHistoryItemFactory(bool logImages)
    {
        _logImages = logImages;
    }

    /// <summary>
    /// Build new log item, based on current clipboard content
    /// </summary>
    /// <returns></returns>
    public ClipboardHistoryItemBase? BuildNewItem(bool force_image)
    {
        var text = Clipboard.GetText();
        if (!force_image && !string.IsNullOrWhiteSpace(text)) return new ClipboardHistoryItemText(text, DateTime.Now);

        if (_logImages && Clipboard.ContainsImage())
        {
            var bitmap = Clipboard.GetImage();
            if (bitmap == null) return null;

            return new ClipboardHistoryItemImage(bitmap);
        }

        return null;
    }
}