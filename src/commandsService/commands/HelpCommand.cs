using System.Text;
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.commands;

internal class HelpCommand(ICollection<string> collection) : BaseCommand, ICliCommand
{
    private readonly ICollection<string> _descriptions = collection;

    public override void Execute()
    {
        var helpMessageBuilder = new StringBuilder();
        var counter = 1;
        foreach (var element in _descriptions)
        {
            helpMessageBuilder.AppendLine($"{counter}) {element}");
            counter++;
        }

        SendNewOutput(helpMessageBuilder.ToString());
    }

    public override string ToString()
    {
        return "help";
    }
}