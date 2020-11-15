using System.Linq;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class CreatorTests : BaseTest
    {
        [Test]
        public void ProductCreator_Create__creates_a_product_instance()
        {
            var productCreator = GetProductCreator();
            var createdProduct = productCreator.Create("P1", 100, 100);

            Assert.AreEqual(_productHolderMock.Object.ProductList.Count, 1);

            var actualObject = _productHolderMock.Object.ProductList.First();

            Assert.AreEqual(createdProduct.ProductCode, actualObject.ProductCode);
            Assert.AreEqual(createdProduct.Price, actualObject.Price);
            Assert.AreEqual(createdProduct.Stock, actualObject.Stock);
            Assert.AreEqual(createdProduct.PriceManupulation, actualObject.PriceManupulation);
        }

        [Test]
        public void CampaignCreator_Create_creates_a_campaign_instance()
        {
            var campaignCreator = GetCampaignCreator();

            var product = CreateAProduct("P1", 100, 100);
            var createdCampaign = campaignCreator.Create(product, "C1", 10, 30, 100);

            Assert.AreEqual(_campaignHolderMock.Object.CampaignList.Count, 1);

            var actualObject = _campaignHolderMock.Object.CampaignList.First();

            Assert.AreEqual(createdCampaign.ActivationDateTime, actualObject.ActivationDateTime);
            Assert.AreEqual(createdCampaign.AverageItemPrice, actualObject.AverageItemPrice);
            Assert.AreEqual(createdCampaign.Duration, actualObject.Duration);
            Assert.AreEqual(createdCampaign.Limit, actualObject.Limit);
            Assert.AreEqual(createdCampaign.Name, actualObject.Name);
            Assert.AreEqual(createdCampaign.Product, actualObject.Product);
            Assert.AreEqual(createdCampaign.Status, actualObject.Status);
            Assert.AreEqual(createdCampaign.TargetSalesCount, actualObject.TargetSalesCount);
            Assert.AreEqual(createdCampaign.TotalSales, actualObject.TotalSales);
            Assert.AreEqual(createdCampaign.Turnover, actualObject.Turnover);
        }

        [Test]
        public void OrderCreator_Create_creates_an_order_instance()
        {
            var orderCreator = GetOrderCreator();

            var createdOrder = orderCreator.Create(CreateAProduct("P1", 100, 100), 20);

            Assert.AreEqual(_orderHolderMock.Object.OrderList.Count, 1);

            var actualObject = _orderHolderMock.Object.OrderList.First();

            Assert.AreEqual(createdOrder.Product, actualObject.Product);
            Assert.AreEqual(createdOrder.Quantity, actualObject.Quantity);
        }

    }
}
