using ECommerce.Web.Models;

namespace ECommerce.Web.Repositories.RepositoryInterfaces
{
    public interface IProductCreator
    {
        Product Create(string productCode, decimal price, decimal stock);
    }
}
