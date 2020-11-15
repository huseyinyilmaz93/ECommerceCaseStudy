using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateCampaignParametersGetter
    {
        CreateCampaignCommandParameters GetParameters(string commandText);
    }
}
