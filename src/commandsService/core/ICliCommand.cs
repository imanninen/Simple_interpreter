using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.core;

public interface ICliCommand
{
    event EventHandler<OutputArgs>? OutputUpdate;
    void Execute();

    void ConfigureOutputMethod(EventHandler<OutputArgs> outputMethod);
}