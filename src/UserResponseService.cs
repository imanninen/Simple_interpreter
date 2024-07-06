using System.Collections.ObjectModel;
using System.Text;
using Simple_interpreter_1.commandsService.core;
using Simple_interpreter_1.commandsService.factories;

namespace Simple_interpreter_1;

internal sealed class UserResponseService
{
    private ICollection<ICliCommandFactory> _factories = new List<ICliCommandFactory>(new ICliCommandFactory[]
    {
        new CatCommandFactory(),
        new HelpCommandFactory(),
        new LcCommandFactory()
    });

    public ICliCommand GetResponse(string input)
    {
        var tokensWithEmptyLines = input.Split(' ');
        var tokens = tokensWithEmptyLines.Where(token => token != "").ToList();

        var factory = GetCommandFactoryByName(tokens[0]);
        if (factory is HelpCommandFactory helpFactory)
            return ConstructHelpCommand(helpFactory, tokens);

        return factory.Create(tokens.ToArray());
    }

    private ICliCommand ConstructHelpCommand(HelpCommandFactory helpCommandFactory, List<string> tokens)
    {
        var descriptionsBuilder = new Collection<string>();
        
        descriptionsBuilder.Add(tokens[0]);
        foreach (var factory in _factories)
        {
            descriptionsBuilder.Add(factory.Description);
        }

        return helpCommandFactory.Create(descriptionsBuilder.ToArray());
    }

    private ICliCommandFactory GetCommandFactoryByName(string name)
    {
        foreach (var factory in _factories)
        {
            if (String.Equals(factory.Name, name))
            {
                return factory;
            }
        }

        throw new NotSupportedException($"Command {name} is not supported!");
    }
}