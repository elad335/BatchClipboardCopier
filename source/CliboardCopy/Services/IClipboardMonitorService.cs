namespace CliboardCopy.Services;

public interface IClipboardMonitorService
{
    event EventHandler<ClipboardUpdatedEventArgs> ClipboardChanged;

    Task StartAsync();

    Task StopAsync();
}