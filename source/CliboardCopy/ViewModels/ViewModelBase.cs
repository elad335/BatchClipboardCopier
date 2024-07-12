using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CliboardCopy.ViewModels;

/// <summary>
/// Base ViewModel class
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dispose()
    {
        OnDispose();
    }

    /// <summary>
    /// Set property value helper
    /// </summary>
    /// <typeparam name="T">Property type</typeparam>
    /// <param name="propertyValue"></param>
    /// <param name="property"></param>
    /// <param name="propertyName"></param>
    protected void SetValue<T>(T propertyValue, out T property, [CallerMemberName] string propertyName = "")
    {
        property = propertyValue;
        RaisePropertyChanged(propertyName);
    }

    /// <summary>
    /// Raise property changed event
    /// </summary>
    /// <param name="propertyName"></param>
    protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (string.IsNullOrWhiteSpace(propertyName)) return;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Free used resources. Cleanup
    /// </summary>
    protected abstract void OnDispose();

    protected void DisplayError(Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}