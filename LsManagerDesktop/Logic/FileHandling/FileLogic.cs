﻿using System;
using System.IO;

namespace LsManagerDesktop.Logic.FileHandling;

public class FileLogic : IFileLogic
{
    public string SteamLibraryPath { get; set; } = string.Empty;
    public string LsExecutionFilePath { get; private set; }
    public bool CanExecute { get; private set; }
    public string LsUserFolderPath { get; private set; }
    public bool HasUserFolderPath { get; private set; }
    public void BuildAndCheckFolders(string steamLibraryPath)
    {
        SteamLibraryPath = steamLibraryPath;

        LsExecutionFilePath = Path.Combine(SteamLibraryPath,
            @"steamapps\common\Farming Simulator 25\FarmingSimulator2025.exe");
        CanExecute = File.Exists(LsExecutionFilePath);

        LsUserFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "My Games", "FarmingSimulator2025");
        var settingsFile = File.Exists(Path.Combine(LsUserFolderPath, "gameSettings.xml"));
    }
}