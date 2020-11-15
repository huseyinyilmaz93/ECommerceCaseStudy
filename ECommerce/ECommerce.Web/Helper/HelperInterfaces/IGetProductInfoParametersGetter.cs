using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface IGetProductInfoParametersGetter
    {
        GetProductInfoCommandParameters GetParameters(string commandText);
    }
}
