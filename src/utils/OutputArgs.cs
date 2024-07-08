namespace Simple_interpreter_1.utils;

public class OutputArgs(string output) : EventArgs
{
    public string Output { get; } = output;
}