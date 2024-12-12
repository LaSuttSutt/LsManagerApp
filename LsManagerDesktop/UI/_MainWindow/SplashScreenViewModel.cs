using System;
using System.Collections.Generic;
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
    #region View
    
    public ICommand BtnModDbFolderCommand { get; set; }
    public ICommand BtnCancelCommand { get; set; }
    public ICommand BtnContinueCommand { get; set; }
    public bool ShowModDbFolder { get; set; }
    public string ModDbPath { get; set; } = string.Empty;
    public bool CanContinue { get; set; }
    
    #endregion
    
    #region Declarations
    
    private bool IsFinished { get; set; }
    private int Frequency => 500;
    
    #endregion
    
    #region C'tor
    
    public SplashScreenViewModel()
    {
        BtnModDbFolderCommand = ReactiveCommand.Create<Window, Task>(SelectModDbFolder);
        BtnCancelCommand = ReactiveCommand.Create(() => Environment.Exit(0));
        BtnContinueCommand = ReactiveCommand.Create(() => IsFinished = true);
    }
    
    #endregion
    
    #region Methods
    
    public async Task Load()
    {
        var tasks = new List<Task> {
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
                DataAccess.GetEntity<Setting>(s => s.Key == Settings.ModDbPath);
                IsFinished = true;
            }
            catch (InvalidOperationException)
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
            DataAccess.AddEntity(new Setting
            {
                Key = Settings.ModDbPath,
                Value = folders[0].Path.AbsolutePath
            });
            ModDbPath = folders[0].Path.AbsolutePath;
            CanContinue = true;
            this.RaisePropertyChanged(nameof(ModDbPath));
            this.RaisePropertyChanged(nameof(CanContinue));
        }
    }
    
    #endregion
}