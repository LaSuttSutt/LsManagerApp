using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using LsManagerDesktop.UI.__Shared;
using ReactiveUI;
using Shared.Data;
using Shared.Data.DomainModel;

namespace LsManagerDesktop.UI._MainWindow;

public class SplashScreenViewModel : ViewModelBase
{
    public bool ShowModDbFolder { get; set; }
    public ICommand BtnModDbFolderCommand { get; set; }
    private bool IsFinished { get; set; }
    private int Frequency => 500;

    public SplashScreenViewModel()
    {
        BtnModDbFolderCommand = ReactiveCommand.Create<Window, Task>(SelectModDbFolder);
    }
    
    public async Task Load()
    {
        var tasks = new List<Task> {
            
            // Check for ModDbFolder
            CheckModDbFolder()
        };

        await Task.WhenAll(tasks);
    }

    public async Task AwaitFinish()
    {
        var waitTask = Task.Run(async () =>
        {
            while (!IsFinished) await Task.Delay(Frequency);
        });

        await waitTask;
    }

    private Task CheckModDbFolder()
    {
        return Task.Factory.StartNew(() =>
        {
            try
            {
                var modDbSetting = DataAccess.GetEntity<Setting>(s => s.Key == "ModDbPath");
            }
            catch (InvalidOperationException ex)
            {
                ShowModDbFolder = true;
                IsFinished = false;
                this.RaisePropertyChanged(nameof(ShowModDbFolder));
            }
        });
    }

    private async Task SelectModDbFolder(Window window)
    {
        var topLevel = TopLevel.GetTopLevel(window);
        if (topLevel == null) return;
        
        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Open ModDb Folder",
            AllowMultiple = false
        });

        if (folders.Count >= 1)
        {
            Console.WriteLine(folders[0].Path.AbsolutePath);
            IsFinished = true;
        }
    }
}