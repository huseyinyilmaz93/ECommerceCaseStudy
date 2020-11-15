using ECommerce.Web.Models;

namespace ECommerce.Web.Services.ServiceInterfaces
{
    public interface IStockAmountReduceService
    {
        void ReduceStock(Product product, decimal quantity);
    }
}
