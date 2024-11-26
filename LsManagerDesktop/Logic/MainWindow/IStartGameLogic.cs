using System;

namespace LsManagerDesktop.Logic.MainWindow;

public interface IStartGameLogic
{
    event EventHandler GameStarted;
    void StartGame(string executable, bool emptyModFolder, bool enableCheats);
}