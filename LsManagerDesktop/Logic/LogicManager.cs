using LsManagerDesktop.Logic.FileHandling;
using LsManagerDesktop.Logic.MainWindow;

namespace LsManagerDesktop.Logic;

public static class LogicManager
{
    public static IMainWindowLogic MainWindow { get; set; } = new MainWindowLogic();
    public static IFileLogic FileLogic { get; set; } = new FileLogic();
}