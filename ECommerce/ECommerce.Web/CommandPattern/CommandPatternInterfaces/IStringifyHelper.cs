using ECommerce.Web.Models;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public interface IStringifyHelper
    {
        string StringifyCreateCampaignCommand(Campaign campaign);
        string StringifyCreateOrderCommand(Order order);
        string StringifyCreateProductCommand(Product product);
        string StringifyGetCampaignInfoCommand(Campaign campaign);
        string StringifyGetProductInfoCommand(Product product);
        string StringifyIncreaseTimeCommand();
    }
}
