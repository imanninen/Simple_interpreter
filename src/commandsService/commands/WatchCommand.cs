using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class WatchCommand : BaseCommand, ICliCommand
{
    private readonly DirectoryInfo _dir;
    private readonly FileSystemWatcher Watcher;

    public WatchCommand(string dirPath)
    {
        if (dirPath == null)
            throw new ArgumentException("File should be not null!");
        try
        {
            _dir = new DirectoryInfo(dirPath);
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }

        if (!_dir.Exists)
        {
            throw new FileNotFoundException($"Directory: {_dir} should exists!");
        }

        Watcher = new FileSystemWatcher(dirPath);
        
    }

    public void Execute(EventHandler< OutputArgs> outputMethod)
    {
        OutputUpdate += outputMethod;
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"watch {_dir}";
    }
}