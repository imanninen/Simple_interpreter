using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.core;

internal class BaseCommand
{
    protected event EventHandler<OutputArgs>? OutputUpdate;
    protected virtual void SendNewOutput(string output)
    {
        var e = new OutputArgs(output);
        OutputUpdate?.Invoke(this, e);
    }
}