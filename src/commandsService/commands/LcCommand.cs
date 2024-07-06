using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class LcCommand : ICliCommand
{
    private readonly FileInfo _file;

    public LcCommand(string filePath)
    {
        if (filePath == null)
            throw new ArgumentException("File should be not null!");
        try
        {
            _file = new FileInfo(filePath);
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }

        if (!_file.Exists)
        {
            throw new FileNotFoundException($"File: {_file} should exists!");
        }
    }


    public void Execute(out string output)
    {
        var numberOfLines = File.ReadLines(_file.FullName).Count();
        output = numberOfLines.ToString();
    }

    public override string ToString()
    {
        return $"lc {_file}";
    }
}