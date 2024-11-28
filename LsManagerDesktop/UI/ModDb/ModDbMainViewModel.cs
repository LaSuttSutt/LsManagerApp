using System;
using System.Windows.Input;
using Avalonia;
using LsManagerDesktop.UI.__Shared;
using LsManagerDesktop.UI.__Shared.Dialogs;
using ReactiveUI;

namespace LsManagerDesktop.UI.ModDb;

public class ModDbMainViewModel : ViewModelBase, IModalWindowModel
{
    public string Title => "LS Manager - Mod DB";
    public Size Size => new (900, 770);
    
    public ICommand AddNewModCommand { get; }

    public ModDbMainViewModel()
    {
        AddNewModCommand = ReactiveCommand.Create(OnAddNewModClicked);
    }
 
    private void OnAddNewModClicked()
    {
        Console.WriteLine("OnAddNewModClicked");
    }
}