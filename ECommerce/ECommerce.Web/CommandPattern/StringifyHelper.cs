using ECommerce.Web.Models;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public class StringifyHelper : IStringifyHelper
    {
        private readonly ITimer _timer;

        public StringifyHelper(ITimer timer)
        {
            _timer = timer;
        }

        public string StringifyCreateCampaignCommand(Campaign campaign)
        {
            return string.Format(
                "Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}",
                campaign.Name, campaign.Product.ProductCode, campaign.Duration, campaign.Limit,
                campaign.TargetSalesCount);

        }

        public string StringifyCreateOrderCommand(Order order)
        {
            return string.Format("Order created; product {0}, quantity {1}", order.Product.ProductCode, order.Quantity);
        }

        public string StringifyCreateProductCommand(Product product)
        {
            return string.Format("Product created; code {0}, price {1}, stock {2}", product.ProductCode, product.Price, product.Stock);
        }

        public string StringifyGetCampaignInfoCommand(Campaign campaign)
        {
            return string.Format(
                "Campaign {0} info; Status {1}, Target Sales {2}, Total Sales {3}, Turnover {4}, Average Item Price {5}",
                campaign.Name, campaign.Status.ToString(), campaign.TargetSalesCount, campaign.TotalSales,
                campaign.Turnover, campaign.AverageItemPrice);
        }

        public string StringifyGetProductInfoCommand(Product product)
        {
            return string.Format("Product {0} info; price {1}, stock {2}", product.ProductCode, (product.Price + product.PriceManupulation),
                product.Stock);
        }

        public string StringifyIncreaseTimeCommand()
        {
            return string.Format("Time is {0}", _timer.GetCurrentDateTime().ToString("HH:mm"));
        }
    }
}
