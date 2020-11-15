using System.Collections.Generic;
using ECommerce.Web.Events;
using ECommerce.Web.Models;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class EventTests : BaseTest
    {
        [Test]
        public void PriceManipulationEvent_ManipulateAllCampaigns__calls_manipulate_method_for_all_active_campaigns()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            _campaignReader.Setup(cr => cr.List()).Returns(new List<Campaign>() { campaign });

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);

            Assert.DoesNotThrow(() => priceManipulationEvent.ManipulateAllCampaigns());
        }

        [Test]
        public void PriceManipulationEvent_ManipulateIfCampaignExists_product__calls_manipulate_method_for_given_product()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(campaign);

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);

            Assert.DoesNotThrow(() => priceManipulationEvent.ManipulateIfCampaignExists(product));
        }

        [Test]
        public void PriceManipulationEvent_Manipulate_campaign__calculates_product_manipulation_value()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 20, 1000);

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);
            priceManipulationEvent.Manipulate(campaign);

            var actualManipulationValue = campaign.Product.Price + campaign.Product.PriceManupulation;
            var expectedManipulation = 90;

            Assert.AreEqual(expectedManipulation, actualManipulationValue);
        }

        [Test]
        public void
            CampaignStatusUpdatorAfterHourTickingEvent_UpdateCampaignStatus__reads_all_active_campaigns_and_set_status_to_end_if_necessary()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 0, 10, 10);

            _campaignReader.Setup(cr => cr.List()).Returns(new List<Campaign>() { campaign });

            var campaignStatusUpdatorAfterHourTickingEvent =
                new CampaignStatusUpdatorAfterHourTickingEvent(_timerMock.Object, _campaignReader.Object,
                    _campaignEnderServiceMock.Object);

            Assert.DoesNotThrow(() => campaignStatusUpdatorAfterHourTickingEvent.UpdateCampaignStatus());
        }

        [Test]
        public void
            CampaignUpdatorAfterStockReducementEvent_UpdateCampaignIfExists_product_quantity__updates_campaign_values_after_stock_operation()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 10, 100);

            var campaignUpdatorAfterStockReducementEvent =
                new CampaignUpdatorAfterStockReducementEvent(_campaignReader.Object, _campaignEnderServiceMock.Object);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(campaign);

            campaignUpdatorAfterStockReducementEvent.UpdateCampaignIfExists(product, 10);

            var expectedTotalSalesValue = 10;
            var expectedTurnover = 1000;
            var expectedAverageItemPrice = 100;

            Assert.AreEqual(expectedTotalSalesValue, campaign.TotalSales);
            Assert.AreEqual(expectedTurnover, campaign.Turnover);
            Assert.AreEqual(expectedAverageItemPrice, campaign.AverageItemPrice);

        }


    }
}
