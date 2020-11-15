using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class HelperTests : BaseTest
    {
        [Test]
        public void StringifyHelper_StringifyCreateCampaignCommand_campaign__stringifies_campaign()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format(
                "Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}",
                campaign.Name, campaign.Product.ProductCode, campaign.Duration, campaign.Limit,
                campaign.TargetSalesCount);

            var actual = stringifyHelper.StringifyCreateCampaignCommand(campaign);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyCreateOrderCommand_order__stringifies_order()
        {
            var product = CreateAProduct("P1", 100, 100);
            var order = CreateAnOrder(product, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Order created; product {0}, quantity {1}", order.Product.ProductCode,
                order.Quantity);

            var actual = stringifyHelper.StringifyCreateOrderCommand(order);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyCreateOrderCommand_product__stringifies_product()
        {
            var product = CreateAProduct("P1", 100, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Product created; code {0}, price {1}, stock {2}", product.ProductCode, product.Price, product.Stock);

            var actual = stringifyHelper.StringifyCreateProductCommand(product);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetCampaignInfoCommand_campaign__stringifies_campaign()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format(
                "Campaign {0} info; Status {1}, Target Sales {2}, Total Sales {3}, Turnover {4}, Average Item Price {5}",
                campaign.Name, campaign.Status.ToString(), campaign.TargetSalesCount, campaign.TotalSales,
                campaign.Turnover, campaign.AverageItemPrice);

            var actual = stringifyHelper.StringifyGetCampaignInfoCommand(campaign);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetProductInfoCommand_product__stringifies_product()
        {
            var product = CreateAProduct("P1", 100, 100);

            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Product {0} info; price {1}, stock {2}", product.ProductCode, (product.Price + product.PriceManupulation),
                product.Stock);

            var actual = stringifyHelper.StringifyGetProductInfoCommand(product);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetProductInfoCommand__stringifies_time()
        {
            var expected = string.Format("Time is {0}", _timerMock.Object.GetCurrentDateTime().ToString("HH:mm"));
            var stringifyHelper = MockStringifyHelper();

            var actual = stringifyHelper.StringifyIncreaseTimeCommand();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void
            CommandParameterHelper_GetCreateCampaignCommandParameter_commandText__returns_parameters_for_create_campaign_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedProductCode = "P1";
            var expectedTargetSalesCount = 100;
            var expectedDuration = 10;
            var expectedLimit = 20;
            var expectedName = "C1";

            var actualObj = commandParameterHelper.GetCreateCampaignCommandParameter("create_campaign C1 P1 10 20 100");

            Assert.AreEqual(expectedProductCode, actualObj.ProductCode);
            Assert.AreEqual(expectedTargetSalesCount, actualObj.TargetSalesCount);
            Assert.AreEqual(expectedName, actualObj.Name);
            Assert.AreEqual(expectedDuration, actualObj.Duration);
            Assert.AreEqual(expectedLimit, actualObj.Limit);

        }

        [Test]
        public void
            CommandParameterHelper_GetCreateOrderCommandParameter_commandText__returns_parameters_for_create_order_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedQuantity = 3;
            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCreateOrderCommandParameter("create_order P1 3");

            Assert.AreEqual(expectedQuantity, actualObj.Quantity);
            Assert.AreEqual(expectedProductCode, actualObj.ProductCode);
        }

        [Test]
        public void
            CommandParameterHelper_GetCreateProductCommandParameter_commandText__returns_parameters_for_create_product_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedPrice = 100;
            var expectedStock = 1000;
            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCreateProductCommandParameter("create_product P1 100 1000");

            Assert.AreEqual(actualObj.Price, expectedPrice);
            Assert.AreEqual(actualObj.Stock, expectedStock);
            Assert.AreEqual(actualObj.ProductCode, expectedProductCode);
        }

        [Test]
        public void
            CommandParameterHelper_GetCampaignInfoCommandParameter_commandText__returns_parameters_for_get_campaign_info_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedName = "C1";

            var actualObj = commandParameterHelper.GetCampaignInfoCommandParameter("get_campaign_info C1");

            Assert.AreEqual(expectedName, actualObj.Name);
        }

        [Test]
        public void
            CommandParameterHelper_GetProductInfoCommandParameter_commandText__returns_parameters_for_get_product_info_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCampaignInfoCommandParameter("get_product_info P1");

            Assert.AreEqual(expectedProductCode, actualObj.Name);
        }

        [Test]
        public void
            CommandParameterHelper_GetIncreaseTimeCommandParameter_commandText__returns_parameters_for_increase_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedHour = 1;

            var actualObj = commandParameterHelper.GetIncreaseTimeCommandParameter("increase_time 1");

            Assert.AreEqual(expectedHour, actualObj.Hour);
        }

    }
}
