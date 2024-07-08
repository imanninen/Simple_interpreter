namespace Simple_interpreter_1.commandsService.core;

public class OutputArgs(string output) : EventArgs
{
    public string Output { get; } = output;
}