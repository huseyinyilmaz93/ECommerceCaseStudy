using System.Text;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public interface ICommandBroker
    {
        void StageCommand(ICommand command);
        StringBuilder ExecuteCommands();
        void DeleteAllRecords();
    }
}
