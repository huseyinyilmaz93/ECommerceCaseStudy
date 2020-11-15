using ECommerce.Web.Constants;
using ECommerce.Web.Enums;
using ECommerce.Web.Models;
using ECommerce.Web.Services.ServiceInterfaces;

namespace ECommerce.Web.Services
{
    public class CampaignEnderService : ICampaignEnderService
    {
        public void EndCampaign(Campaign campaign)
        {
            campaign.Product.PriceManupulation = ECommerceConstants.DefaultPriceManipulationValue;
            campaign.Status = CampaignStatus.Ended;
        }
    }
}
