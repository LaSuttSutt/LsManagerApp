using System;
using System.IO;
using LsManagerDesktop.UI.__Shared;
using Path = System.IO.Path;

namespace LsManagerDesktop.UI._MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var steamDirectory = @"F:\Steam";
        var fsDirectory = Path.Combine(steamDirectory, @"steamapps\common\Farming Simulator 25");

        var fileInfo = File.Exists(Path.Combine(fsDirectory, "FarmingSimulator2025.exe"));
        
        var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var fsDataDirectory = Path.Combine(documentsDirectory, "My Games", "FarmingSimulator2025");
        
        var settingsFile = File.Exists(Path.Combine(fsDataDirectory, "gameSettings.xml"));
    }
}