namespace Simple_interpreter_1.commandsService.core;

public interface ICliCommand
{
    void Execute(out string output);

}