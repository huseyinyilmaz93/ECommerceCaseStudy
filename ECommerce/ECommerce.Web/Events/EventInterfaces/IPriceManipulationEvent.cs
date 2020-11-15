using ECommerce.Web.Models;

namespace ECommerce.Web.Events.EventInterfaces
{
    public interface IPriceManipulationEvent
    {
        void ManipulateAllCampaigns();
        void ManipulateIfCampaignExists(Product product);
        void Manipulate(Campaign campaign);
    }
}
