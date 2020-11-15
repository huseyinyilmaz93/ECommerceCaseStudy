using ECommerce.Web.Enums;
using ECommerce.Web.Models;
using ECommerce.Web.Services.ServiceInterfaces;

namespace ECommerce.Web.Services
{
    public class CampaignEnderService : ICampaignEnderService
    {
        public void EndCampaign(Campaign campaign)
        {
            campaign.Product.PriceManupulation = 0;
            campaign.Status = CampaignStatus.Ended;
        }
    }
}
