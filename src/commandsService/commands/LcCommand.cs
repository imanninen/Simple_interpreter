using Simple_interpreter_1.commandsService.core;
using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class LcCommand : BaseCommand, ICliCommand
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


    public override void Execute()
    {
        var numberOfLines = File.ReadLines(_file.FullName).Count();
        SendNewOutput(numberOfLines.ToString());
    }

    public override string ToString()
    {
        return $"lc {_file}";
    }
}