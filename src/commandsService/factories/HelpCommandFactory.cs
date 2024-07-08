using System.Collections.ObjectModel;
using Simple_interpreter_1.commandsService.commands;
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.factories;

public class HelpCommandFactory : ICliCommandFactory
{
    private const string Desc = "help - shows avaliable commands.";
    private const string CommandName = "help";

    public string Description => Desc;
    public string Name => CommandName;
    
    public ICliCommand Create(params string[] args)
    {
        if (! string.Equals(args[0], CommandName, StringComparison.Ordinal))
        {
            throw new ArgumentException($"For {args[0]} command {CommandName} expected.");
        }

        Collection<string> argsForCommand = new Collection<string>();
        for (int i = 1; i < args.Length; i++)
        {
            argsForCommand.Add(args[i]);
        }

        return new HelpCommand(argsForCommand);
    }
}