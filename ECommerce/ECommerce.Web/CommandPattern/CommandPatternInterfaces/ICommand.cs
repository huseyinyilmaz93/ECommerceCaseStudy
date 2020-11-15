namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public interface ICommand
    {
        string Execute();
        void GetParameters(string commandText);
    }
}
