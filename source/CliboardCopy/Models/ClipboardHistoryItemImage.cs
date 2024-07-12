using CliboardCopy.Extensions;

namespace CliboardCopy.Models;

/// <summary>
/// Clipboard image representer class
/// </summary>
public class ClipboardHistoryItemImage : ClipboardHistoryItemBase
{
    public ClipboardHistoryItemImage(Image image)
    {
        Image = image;
        ImageHash = image.ComputeMd5Hash();
    }

    public ClipboardHistoryItemImage(Image image, DateTime time) : base(time)
    {
        Image = image;
        ImageHash = image.ComputeMd5Hash();
    }

    /// <summary>
    /// Image in clipboard
    /// </summary>
    public Image Image { get; }

    /// <summary>
    /// Image MD5 hash
    /// </summary>
    /// <remarks>Duplication protection</remarks>
    public string ImageHash { get; }

    public override void Dispose()
    {
        Image.Dispose();
    }
}