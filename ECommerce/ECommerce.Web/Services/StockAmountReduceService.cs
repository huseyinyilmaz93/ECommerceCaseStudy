using System;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Services.ServiceInterfaces;

namespace ECommerce.Web.Services
{
    public class StockAmountReduceService : IStockAmountReduceService
    {
        private readonly IPriceManipulationEvent _priceManupulationEvent;
        private readonly ICampaignUpdatorAfterStockReducementEvent _campaignUpdatorAfterStockReducementEvent;

        public StockAmountReduceService(IPriceManipulationEvent priceManupulationEvent, ICampaignUpdatorAfterStockReducementEvent campaignUpdatorAfterStockReducementEvent)
        {
            _priceManupulationEvent = priceManupulationEvent;
            _campaignUpdatorAfterStockReducementEvent = campaignUpdatorAfterStockReducementEvent;
        }

        public void ReduceStock(Product product, decimal quantity)
        {
            product.Stock -= quantity;
            _campaignUpdatorAfterStockReducementEvent.UpdateCampaignIfExists(product, quantity);
            _priceManupulationEvent.ManipulateIfCampaignExists(product);
        }
    }
}
