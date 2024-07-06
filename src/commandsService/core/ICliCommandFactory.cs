namespace Simple_interpreter_1.commandsService.core;

public interface ICliCommandFactory
{
    string Description { get; }
    string Name { get; }
    ICliCommand Create(params string[] args);
}