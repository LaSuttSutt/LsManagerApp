using System;
using System.IO;
using System.Windows.Input;
using LsManagerDesktop.Logic;
using LsManagerDesktop.UI.__Shared;
using ReactiveUI;

namespace LsManagerDesktop.UI._MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    public bool StartGameEmptyModFolder { get; set; }
    public bool StartGameEnableCheats { get; set; }
    
    public ICommand StartGameCommand { get; set; }
    
    public MainWindowViewModel()
    {
        LogicManager.FileLogic.BuildAndCheckFolders(@"F:\Steam");
        StartGameCommand = ReactiveCommand.Create(StartGame);
    }

    private void StartGame()
    {
        Console.WriteLine("Starting game...");
        Console.WriteLine(StartGameEmptyModFolder);
        Console.WriteLine(StartGameEnableCheats);
    }
    
    private void FolderStuff()
    {
        var steamDirectory = @"F:\Steam";
        var fsDirectory = Path.Combine(steamDirectory, @"steamapps\common\Farming Simulator 25");

        var fileInfo = File.Exists(Path.Combine(fsDirectory, "FarmingSimulator2025.exe"));
        
        var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var fsDataDirectory = Path.Combine(documentsDirectory, "My Games", "FarmingSimulator2025");
        
        var settingsFile = File.Exists(Path.Combine(fsDataDirectory, "gameSettings.xml"));
    }
}