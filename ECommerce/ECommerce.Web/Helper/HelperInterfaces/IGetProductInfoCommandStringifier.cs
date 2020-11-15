using ECommerce.Web.Models;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface IGetProductInfoCommandStringifier
    {
        string Stringify(Product product);
    }
}
