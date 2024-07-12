using CliboardCopy.Extensions;

namespace CliboardCopy.Models;

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
    /// Anti duplication protection
    /// </summary>
    public string ImageHash { get; }

    public override void Dispose()
    {
        Image.Dispose();
    }
}