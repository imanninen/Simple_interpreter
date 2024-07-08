using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.core;

internal class BaseCommand : ICliCommand
{
    public event EventHandler<OutputArgs>? OutputUpdate;

    protected virtual void SendNewOutput(string output)
    {
        var e = new OutputArgs(output);
        if (OutputUpdate == null)
            throw new Exception("Output method is not specified!");
        OutputUpdate.Invoke(this, e);
    }

    public virtual void Execute()
    {
        Console.WriteLine($"Execute method of the {GetType()}");
    }

    public void ConfigureOutputMethod(EventHandler<OutputArgs> outputMethod)
    {
        OutputUpdate += outputMethod;
    }
}