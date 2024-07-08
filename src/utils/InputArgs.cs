namespace Simple_interpreter_1.utils;

public class InputArgs(string input) : EventArgs
{
    public string Input { get; } = input;
}