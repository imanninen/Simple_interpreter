using System.Text;
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal class HelpCommand(ICollection<string> collection) : ICliCommand
{
    private readonly ICollection<string> _descriptions = collection;

    public void Execute(out string output)
    {
        var helpMessageBuilder = new StringBuilder();
        var counter = 1;
        foreach (var element in _descriptions)
        {
            helpMessageBuilder.AppendLine($"{counter}) {element}");
            counter++;
        }

        output = helpMessageBuilder.ToString();
    }
}