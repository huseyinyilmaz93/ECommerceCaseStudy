using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateProductParametersGetter
    {
        CreateProductCommandParameters GetParameters(string commandText);
    }
}
