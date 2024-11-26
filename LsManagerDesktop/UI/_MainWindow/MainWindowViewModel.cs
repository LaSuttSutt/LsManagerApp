﻿using System;
using System.Windows.Input;
using LsManagerDesktop.Logic;
using LsManagerDesktop.UI.__Shared;
using ReactiveUI;

namespace LsManagerDesktop.UI._MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    public bool StartGameEmptyModFolder { get; set; }
    public bool StartGameEnableCheats { get; set; }
    public bool CanStartGame => LogicManager.FileLogic.CanExecute;
    
    public ICommand StartGameCommand { get; set; }
    public ICommand BtnSavegamesCLicked { get; set; }
    public ICommand BtnModDbClicked { get; set; }
    
    public MainWindowViewModel()
    {
        LogicManager.FileLogic.BuildAndCheckFolders(@"F:\Steam");
        LogicManager.StartGameLogic.GameStarted += StartGameLogicOnGameStarted;
        StartGameCommand = ReactiveCommand.Create(StartGame);
        BtnSavegamesCLicked = ReactiveCommand.Create(OnBtnSavegamesCLicked);
        BtnModDbClicked = ReactiveCommand.Create(OnBtnModDbClicked);
    }
    
    private void StartGame()
    {
        LogicManager.StartGameLogic.StartGame(LogicManager.FileLogic.LsExecutionFilePath, StartGameEmptyModFolder,
            StartGameEnableCheats);
    }
    
    private void StartGameLogicOnGameStarted(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    private void OnBtnSavegamesCLicked()
    {
        Console.WriteLine("OnBtnSavegamesCLicked");
    }

    private void OnBtnModDbClicked()
    {
        Console.WriteLine("OnBtnModDbClicked");
    }
}