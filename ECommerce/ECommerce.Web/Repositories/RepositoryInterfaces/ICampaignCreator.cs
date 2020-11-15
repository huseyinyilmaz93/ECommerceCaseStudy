using ECommerce.Web.Models;

namespace ECommerce.Web.Repositories.RepositoryInterfaces
{
    public interface ICampaignCreator
    {
        Campaign Create(Product product, string name, int duration, short limit, int targetSalesCount);
    }
}
