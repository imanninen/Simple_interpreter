// See https://aka.ms/new-console-template for more information


using Simple_interpreter_1.app;
using Simple_interpreter_1.commandsService.commands;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var interpreter = new Interpreter();
        
        interpreter.Run();
    }
}