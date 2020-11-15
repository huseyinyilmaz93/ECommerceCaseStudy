using ECommerce.Web.Models;

namespace ECommerce.Web.Events.EventInterfaces
{
    public interface ICampaignUpdatorAfterStockReducementEvent
    {
        void UpdateCampaignIfExists(Product product, decimal quantity);
    }
}
