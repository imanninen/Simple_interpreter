using System.Text;
using Simple_interpreter_1.commandsService.core;
using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.commands;

internal sealed class CatCommand : BaseCommand, ICliCommand
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
    
    
    
    public void Execute(EventHandler< OutputArgs> outputMethod)
    {
        OutputUpdate += outputMethod;
        
        StringBuilder outputConstructor = new StringBuilder();

        foreach (var line in File.ReadLines(_file.FullName))
        {
            outputConstructor.AppendLine(line);
        }
        
        SendNewOutput(outputConstructor.ToString());
    }
    
    public override string ToString()
    {
        return $"cat {_file}";
    }
}