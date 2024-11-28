namespace LsManagerDesktop.UI.__Shared.Dialogs;

public class ModalWindowModel(IModalWindowModel modalWindowModel) : ViewModelBase
{
    public ViewModelBase ViewModel { get; set; } = (ViewModelBase)modalWindowModel;
}