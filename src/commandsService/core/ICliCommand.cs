namespace Simple_interpreter_1.commandsService.core;

public interface ICliCommand
{
    void Execute(EventHandler< OutputArgs> outputMethod);
}