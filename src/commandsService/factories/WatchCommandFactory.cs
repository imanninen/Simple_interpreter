using Simple_interpreter_1.commandsService.core;

namespace Simple_interpreter_1.commandsService.factories;

internal sealed class WatchCommandFactory : ICliCommandFactory
{
    private const string Desc = "locks the directory and remind about updates in it";
    private const string CommandName = "watch";
    public string Description => Desc;
    public string Name => CommandName;
    public ICliCommand Create(params string[] args)
    {
        throw new NotImplementedException();
    }
}