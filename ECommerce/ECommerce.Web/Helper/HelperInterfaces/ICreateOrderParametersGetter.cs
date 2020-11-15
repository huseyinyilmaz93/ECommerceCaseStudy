using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateOrderParametersGetter
    {
        CreateOrderCommandParameters GetParameters(string commandText);
    }
}
