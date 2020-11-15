using ECommerce.Web.Models;

namespace ECommerce.Web.Repositories.RepositoryInterfaces
{
    public interface IOrderCreator
    {
        Order Create(Product product, decimal quantity);
    }
}
