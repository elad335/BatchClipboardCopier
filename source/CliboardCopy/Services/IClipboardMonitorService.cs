namespace CliboardCopy.Services;

/// <summary>
/// Clipboard monitor service interface
/// </summary>
/// <remarks>Can be used in DI</remarks>
public interface IClipboardMonitorService
{
    /// <summary>
    /// Event occured when clipboard content changed
    /// </summary>
    event EventHandler<ClipboardUpdatedEventArgs> ClipboardChanged;

    /// <summary>
    /// Start clipboard content monitoring
    /// </summary>
    /// <returns></returns>
    Task StartAsync();

    /// <summary>
    /// Stop clipboard content monitoring
    /// </summary>
    /// <returns></returns>
    Task StopAsync();
}