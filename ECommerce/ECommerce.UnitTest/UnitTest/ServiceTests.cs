using ECommerce.Web.Enums;
using ECommerce.Web.Services;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class ServiceTests : BaseTest
    {
        [Test]
        public void CampaignEnderService_EndCampaign__updates_campaign_status_as_ended_and_reset_price_manipulation()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 100, 10, 100);

            product.PriceManupulation = 1000;

            var campaignEnderService = new CampaignEnderService();

            campaignEnderService.EndCampaign(campaign);

            var expectedManipulationValue = 0;
            var expectedStatus = CampaignStatus.Ended;

            Assert.AreEqual(expectedManipulationValue, product.PriceManupulation);
            Assert.AreEqual(expectedStatus, campaign.Status);
        }

        [Test]
        public void StockAmountReduceService_ReduceStock_product_quantity__reduces_stock_value()
        {
            var product = CreateAProduct("P1", 100, 100);

            var stockAmountReduceService = new StockAmountReduceService(_priceManipulationEventMock.Object,
                _campaignUpdatorAfterStockReducementEventMock.Object);

            stockAmountReduceService.ReduceStock(product, 10);

            var expectedStock = 90;

            Assert.AreEqual(expectedStock, product.Stock);

        }


    }
}
