using System;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Constants;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.Events
{
    public class PriceManipulationEvent : IPriceManipulationEvent
    {
        private readonly ITimer _timer;
        private readonly ICampaignReader _campaignReader;

        public PriceManipulationEvent(ITimer timer, ICampaignReader campaignReader)
        {
            _timer = timer;
            _campaignReader = campaignReader;
        }

        public void ManipulateAllCampaigns()
        {
            foreach (var campaign in _campaignReader.List())
            {
                Manipulate(campaign);
            }
        }

        public void ManipulateIfCampaignExists(Product product)
        {
            var campaign = _campaignReader.Get(product);
            if (campaign != null)
            {
                Manipulate(campaign);
            }
        }

        public void Manipulate(Campaign campaign)
        {
            var manupulationBoundary = campaign.Product.Price * ((decimal)campaign.Limit / ECommerceConstants._100);

            var campaignProductSellingPercent = campaign.TotalSales / (decimal)campaign.TargetSalesCount;
            var campaignProgressPercent = (_timer.GetCurrentDateTime() - campaign.ActivationDateTime).Hours / (decimal)campaign.Duration;

            campaign.Product.PriceManupulation = -(manupulationBoundary * ECommerceConstants.DiscountLimitInitialUsageRate) +
                                                 (campaignProductSellingPercent - campaignProgressPercent) *
                                                 (manupulationBoundary * ECommerceConstants.SellingAndCampaignProgressTradeOffRate);
        }

    }
}
