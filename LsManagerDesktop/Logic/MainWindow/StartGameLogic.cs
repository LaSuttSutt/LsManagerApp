using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LsManagerDesktop.Logic.MainWindow;

public class StartGameLogic : IStartGameLogic
{
    public event EventHandler? GameStarted;

    public void StartGame(string executable, bool emptyModFolder, bool enableCheats)
    {
        var arguments = new List<string>();
        if (enableCheats)
            arguments.Add("-cheats");
         
        Process.Start(executable, arguments);
        GameStarted?.Invoke(this, EventArgs.Empty);
    }
}