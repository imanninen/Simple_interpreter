using System.Text;
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class CatCommand : ICliCommand
{
    private readonly FileInfo _file;

    public CatCommand(string filePath)
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
        StringBuilder outputConstructor = new StringBuilder();

        foreach (var line in File.ReadLines(_file.FullName))
        {
            outputConstructor.AppendLine(line);
        }

        output = outputConstructor.ToString();
    }
}