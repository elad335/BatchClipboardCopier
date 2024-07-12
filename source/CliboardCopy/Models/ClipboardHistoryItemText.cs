namespace CliboardCopy.Models;

public class ClipboardHistoryItemText : ClipboardHistoryItemBase
{
    public ClipboardHistoryItemText(string text, DateTime time) : base(time)
    {
        Text = text;
    }

    public string Text { get; }
}