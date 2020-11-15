using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.FactoryMethod.FactoryMethodInterfaces;
using ECommerce.Web.Helpers.HelperInterfaces;

namespace ECommerce.Web.Helpers
{
    public class CommandExecuter : ICommandExecuter
    {
        public readonly ICommandCreator _commandCreator;
        public readonly ICommandBroker _commandBroker;

        public CommandExecuter(ICommandCreator commandCreator, ICommandBroker commandBroker)
        {
            _commandCreator = commandCreator;
            _commandBroker = commandBroker;
        }

        public string Execute(string[] commandTexts)
        {
            foreach (var commandStr in commandTexts)
            {
                var command = _commandCreator.GetCommand(commandStr);
                _commandBroker.StageCommand(command);
            }

            var result = _commandBroker.ExecuteCommands().ToString();
            _commandBroker.DeleteAllRecords();

            return result;
        }
    }
}
