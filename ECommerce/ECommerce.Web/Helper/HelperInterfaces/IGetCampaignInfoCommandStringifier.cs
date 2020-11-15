using ECommerce.Web.Models;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface IGetCampaignInfoCommandStringifier
    {
        string Stringify(Campaign campaign);
    }
}
