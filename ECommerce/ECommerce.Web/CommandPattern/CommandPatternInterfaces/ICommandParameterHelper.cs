using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public interface ICommandParameterHelper
    {
        CreateCampaignCommandParameters GetCreateCampaignCommandParameter(string commandText);
        CreateOrderCommandParameters GetCreateOrderCommandParameter(string commandText);
        CreateProductCommandParameters GetCreateProductCommandParameter(string commandText);
        GetCampaignInfoCommandParameters GetCampaignInfoCommandParameter(string commandText);
        GetProductInfoCommandParameters GetProductInfoCommandParameter(string commandText);
        IncreaseTimeCommandParameter GetIncreaseTimeCommandParameter(string commandText);
    }
}
