using Simple_interpreter_1.commandsService.core;
using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class WatchCommand : BaseCommand, ICliCommand
{
    private readonly FileSystemWatcher _watcher;

    public WatchCommand(string dirPath)
    {
        if (dirPath == null && dirPath != "")
            throw new ArgumentException("File should be not null!");
        try
        {
            _watcher = new FileSystemWatcher(dirPath);
            _watcher.NotifyFilter = NotifyFilters.FileName |
                                    NotifyFilters.DirectoryName;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public override void Execute()
    {
        _watcher.EnableRaisingEvents = true;
        while (true)
        {
            var line = Console.ReadLine();
            if (string.Equals(line, "exit"))
                break;
        }

        _watcher.EnableRaisingEvents = false;
    }

    private void OnCreated(object? sender, FileSystemEventArgs e)
    {
        SendNewOutput($"File created: {e.FullPath}");
    }

    private void OnDeleted(object? sender, FileSystemEventArgs e)
    {
        SendNewOutput($"File deleted: {e.FullPath}");
    }

    public override string ToString()
    {
        return $"watch {_watcher.Path}";
    }
}