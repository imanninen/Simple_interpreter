using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class WatchCommand : ICliCommand
{
    private readonly DirectoryInfo _dir;

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
    }

    public void Execute(out string output)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"watch {_dir}";
    }
}