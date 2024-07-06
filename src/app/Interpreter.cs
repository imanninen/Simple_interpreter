using System.Threading.Channels;

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
                string output;
                var command = _commandService.GetResponse(input);
                command.Execute(out output);
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }
    }
}