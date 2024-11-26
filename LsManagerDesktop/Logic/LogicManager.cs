using LsManagerDesktop.Logic.FileHandling;
using LsManagerDesktop.Logic.MainWindow;

namespace LsManagerDesktop.Logic;

public static class LogicManager
{
    public static IFileLogic FileLogic { get; } = new FileLogic();
    public static IStartGameLogic StartGameLogic { get; set; } = new StartGameLogic(FileLogic.LsExecutionFilePath);
}