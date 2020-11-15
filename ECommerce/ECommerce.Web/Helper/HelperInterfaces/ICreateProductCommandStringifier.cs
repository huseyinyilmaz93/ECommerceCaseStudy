using ECommerce.Web.Models;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateProductCommandStringifier
    {
        string Stringify(Product product);
    }
}
