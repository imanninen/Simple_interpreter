using Simple_interpreter_1.commandsService.commands;
using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.factories;

internal class CatCommandFactory : ICliCommandFactory
{
    private const string CommandName = "cat";
    private const string Desc = "cat <path/to/file> - shows all lines of file.";

    public string Description => Desc;
    public string Name => CommandName;
    
    public ICliCommand Create(params string[] args)
    {
        switch (args.Length)
        {
            case > 2:
                throw new ArgumentException("Two many arguments!");
            case < 2:
                throw new ArgumentException("Not enough arguments!");
        }

        if (! string.Equals(args[0], CommandName, StringComparison.Ordinal))
        {
            throw new ArgumentException($"For {args[0]} command {CommandName} expected.");
        }

        return new CatCommand(args[1]);
    }
}
