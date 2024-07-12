namespace CliboardCopy.Models;

/// <summary>
/// Clipboard text content representer class
/// </summary>
public class ClipboardHistoryItemText : ClipboardHistoryItemBase
{
    public ClipboardHistoryItemText(string text, DateTime time) : base(time)
    {
        Text = text;
    }

    /// <summary>
    /// Clipboard text
    /// </summary>
    public string Text { get; }
}