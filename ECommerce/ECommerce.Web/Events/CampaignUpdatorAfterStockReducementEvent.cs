using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Services.ServiceInterfaces;

namespace ECommerce.Web.Events
{
    public class CampaignUpdatorAfterStockReducementEvent : ICampaignUpdatorAfterStockReducementEvent
    {
        private readonly ICampaignReader _campaignReader;
        private readonly ICampaignEnderService _campaignEnderService;
        
        public CampaignUpdatorAfterStockReducementEvent(ICampaignReader campaignReader, ICampaignEnderService campaignEnderService)
        {
            _campaignReader = campaignReader;
            _campaignEnderService = campaignEnderService;
        }

        public void UpdateCampaignIfExists(Product product, decimal quantity)
        {
            var campaign = _campaignReader.Get(product);
            if (campaign != null)
            {
                campaign.TotalSales += quantity;
                campaign.Turnover += (product.Price + product.PriceManupulation) * quantity;
                campaign.AverageItemPrice = campaign.Turnover / campaign.TotalSales;

                if (campaign.TotalSales >= campaign.TargetSalesCount)
                {
                    _campaignEnderService.EndCampaign(campaign);
                }
            }
        }
    }
}
