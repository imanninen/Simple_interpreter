using Simple_interpreter_1.commandsService.commands;
using Simple_interpreter_1.commandsService.core;
using Simple_interpreter_1.utils;

namespace Simple_interpreter_1.commandsService.factories;

internal sealed class WatchCommandFactory : ICliCommandFactory
{
    private const string Desc = "watch /path/to/dir - locks the directory and remind about updates in it";
    private const string CommandName = "watch";
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

        if (!string.Equals(args[0], CommandName, StringComparison.Ordinal))
        {
            throw new ArgumentException($"For {args[0]} command {CommandName} expected.");
        }
        var temp = new WatchCommand(args[1]);
        return temp;
    }
}