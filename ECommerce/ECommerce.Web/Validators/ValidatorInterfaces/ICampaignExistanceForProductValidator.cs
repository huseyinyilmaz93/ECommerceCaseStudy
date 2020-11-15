using ECommerce.Web.Models;

namespace ECommerce.Web.Validators.ValidatorInterfaces
{
    public interface ICampaignExistanceForProductValidator
    {
        void Validate(Product product);

        void Validate(string campaignName);
    }
}
