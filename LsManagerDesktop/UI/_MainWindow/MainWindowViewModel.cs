using System;
using System.Threading.Tasks;
using System.Windows.Input;
using LsManagerDesktop.Data;
using LsManagerDesktop.Logic;
using LsManagerDesktop.UI.__Shared;
using LsManagerDesktop.UI.__Shared.Dialogs;
using LsManagerDesktop.UI.ModDb;
using ReactiveUI;

namespace LsManagerDesktop.UI._MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    #region C'tor
    
    public MainWindowViewModel()
    {
        DataAccess.Initialize();
        LogicManager.FileLogic.BuildAndCheckFolders(@"F:\Steam");
        LogicManager.StartGameLogic.GameStarted += OnGameStarted;
        StartGameCommand = ReactiveCommand.Create(OnStartGame);
        BtnSavegamesCLicked = ReactiveCommand.Create(OnBtnSavegamesCLicked);
        BtnModDbClicked = ReactiveCommand.Create(OnBtnModDbClicked);
    }
    
    #endregion
    
    #region View Properties
    
    public bool StartGameEmptyModFolder { get; set; }
    public bool StartGameEnableCheats { get; set; }
    public bool CanStartGame => LogicManager.FileLogic.CanExecute;
    
    #endregion
    
    #region View Commands
    
    public ICommand StartGameCommand { get; set; }
    public ICommand BtnSavegamesCLicked { get; set; }
    public ICommand BtnModDbClicked { get; set; }
    
    #endregion
    
    #region Command Handler
    
    private void OnStartGame()
    {
        LogicManager.StartGameLogic.StartGame(LogicManager.FileLogic.LsExecutionFilePath, StartGameEmptyModFolder,
            StartGameEnableCheats);
    }
    
    private void OnGameStarted(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private void OnBtnSavegamesCLicked()
    {
        Console.WriteLine("OnBtnSavegamesCLicked");
    }

    private async Task<bool> OnBtnModDbClicked()
    {
        var viewModel = new ModDbMainViewModel();
        return await ModalWindow.Show<MainWindow>(viewModel);
    }
    
    #endregion
}