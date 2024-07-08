
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.app;

public sealed class Interpreter
{
    private readonly UserResponseService _commandService = new UserResponseService();
    
    public void Run()
    {
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null)
                continue;
            if (string.Equals(input, "exit"))
                break;
            try
            {
                var command = _commandService.GetResponse(input);
                command.Execute(WriteToConsole);
            }
            catch (Exception e)
            {
               WriteErrorToConsole(e.Message);
            }
        }
    }

    private void WriteToConsole(object? sender, OutputArgs e)
    {
        Console.WriteLine(e.Output);
    }

    private void WriteErrorToConsole(string message)
    {
        Console.WriteLine($"ERROR: {message}");
    }
}