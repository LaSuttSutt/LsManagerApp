namespace LsManagerDesktop.Logic.FileHandling;

public interface IFileLogic
{
    string SteamLibraryPath { get; set; }
    string LsExecutionFilePath { get; }
    bool CanExecute { get; }
    string LsUserFolderPath { get; }
    bool HasUserFolderPath { get; }
    void BuildAndCheckFolders(string steamLibraryPath);
}