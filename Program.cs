using Simple_interpreter_1.app;

namespace Simple_interpreter_1;

public static class Program
{
    public static void Main(string[] args)
    {
        var interpreter = new Interpreter();
        
        interpreter.Run();
    }
}