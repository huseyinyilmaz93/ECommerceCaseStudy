using ECommerce.Web.CommandPattern.CommandPatternInterfaces;

namespace ECommerce.Web.FactoryMethod.FactoryMethodInterfaces
{
    public interface ICommandCreator
    {
        ICommand GetCommand(string commandText);
    }
}
