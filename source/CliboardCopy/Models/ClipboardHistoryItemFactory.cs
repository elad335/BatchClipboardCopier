namespace CliboardCopy.Models;

public class ClipboardHistoryItemFactory
{
    private readonly bool _logImages;

    public ClipboardHistoryItemFactory(bool logImages)
    {
        _logImages = logImages;
    }

    public ClipboardHistoryItemBase? BuildNewItem()
    {
        var text = Clipboard.GetText();
        if (!string.IsNullOrWhiteSpace(text)) return new ClipboardHistoryItemText(text, DateTime.Now);

        if (_logImages && Clipboard.ContainsImage())
        {
            var bitmap = Clipboard.GetImage();
            if (bitmap == null) return null;

            return new ClipboardHistoryItemImage(bitmap);
        }

        return null;
    }
}