using ECommerce.Web.Models;

namespace ECommerce.Web.Helper.HelperInterfaces
{
    public interface ICreateCampaignCommandStringifier
    {
        string Stringify(Campaign campaign);
    }
}
