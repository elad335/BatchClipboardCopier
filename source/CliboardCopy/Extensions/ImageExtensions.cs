using System.Security.Cryptography;

namespace CliboardCopy.Extensions;

public static class ImageExtensions
{
    /// <summary>
    /// Calculate MD5 image hash
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static string ComputeMd5Hash(this Image image)
    {
        using (var md5 = MD5.Create())
        using (var ms = new MemoryStream())
        {
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            return BitConverter.ToString(md5.ComputeHash(ms));
        }
    }
}