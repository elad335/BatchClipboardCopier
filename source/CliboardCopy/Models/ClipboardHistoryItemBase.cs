namespace CliboardCopy.Models;

/// <summary>
/// Clipboard history item base class
/// </summary>
public abstract class ClipboardHistoryItemBase : IDisposable
{
    protected ClipboardHistoryItemBase()
    {
        Time = DateTime.Now;
    }

    public ClipboardHistoryItemBase(DateTime time)
    {
        Time = time;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public DateTime Time { get; }

    public virtual void Dispose()
    {
    }
}