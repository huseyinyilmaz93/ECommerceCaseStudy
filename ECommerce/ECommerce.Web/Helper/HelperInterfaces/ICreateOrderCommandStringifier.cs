using ECommerce.Web.Models;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateOrderCommandStringifier
    {
        string Stringify(Order order);
    }
}
