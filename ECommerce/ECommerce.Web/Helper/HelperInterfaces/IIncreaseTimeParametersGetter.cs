using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface IIncreaseTimeParametersGetter
    {
        IncreaseTimeCommandParameter GetParameters(string commandText);
    }
}
