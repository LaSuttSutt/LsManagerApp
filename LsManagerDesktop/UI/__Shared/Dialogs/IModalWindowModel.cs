using Avalonia;

namespace LsManagerDesktop.UI.__Shared.Dialogs;

public interface IModalWindowModel
{
    public string Title { get; }
    public Size Size { get; }
}