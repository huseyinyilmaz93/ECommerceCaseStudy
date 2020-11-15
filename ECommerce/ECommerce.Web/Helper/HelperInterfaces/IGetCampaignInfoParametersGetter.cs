using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface IGetCampaignInfoParametersGetter
    {
        GetCampaignInfoCommandParameters GetParameters(string commandText);
    }
}
