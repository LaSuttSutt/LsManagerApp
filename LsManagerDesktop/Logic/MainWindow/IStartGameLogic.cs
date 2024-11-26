using System;

namespace LsManagerDesktop.Logic.MainWindow;

public interface IStartGameLogic
{
    event EventHandler GameStarted;
    void StartGame(bool emptyModFolder, bool enableCheats);
}