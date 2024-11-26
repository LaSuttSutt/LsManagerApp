using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LsManagerDesktop.Logic.MainWindow;

public class StartGameLogic(string executableString) : IStartGameLogic
{
    public event EventHandler? GameStarted;
    private string ExecutableString { get; } = executableString;

    public void StartGame(bool emptyModFolder, bool enableCheats)
    {
        var arguments = new List<string>();
        if (enableCheats)
            arguments.Add("-cheats");
         
        Process.Start(ExecutableString, arguments);
        GameStarted?.Invoke(this, EventArgs.Empty);
    }
}