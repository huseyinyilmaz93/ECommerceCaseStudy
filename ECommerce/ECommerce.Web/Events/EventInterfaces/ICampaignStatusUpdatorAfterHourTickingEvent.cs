using ECommerce.Web.Models;

namespace ECommerce.Web.Events.EventInterfaces
{
    public interface ICampaignStatusUpdatorAfterHourTickingEvent
    {
        void UpdateCampaignStatus();
    }
}
