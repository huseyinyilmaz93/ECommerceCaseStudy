using System;
using ECommerce.Web.Exceptions;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Validators
{
    public class CampaignExistanceForProductValidator : ICampaignExistanceForProductValidator
    {
        private readonly ICampaignReader _campaignReader;
        public CampaignExistanceForProductValidator(ICampaignReader campaignReader)
        {
            _campaignReader = campaignReader;
        }

        public void Validate(Product product)
        {
            if(_campaignReader.Get(product) != null)
            {
                throw new ECommerceExceptions.CampaignAlreadyExistsForProductException(product.ProductCode);
            }
        }

        public void Validate(string campaignName)
        {
            if (_campaignReader.Get(campaignName) != null)
            {
                throw new ECommerceExceptions.CampaignNameAlreadyExistsException();
            }
        }
    }
}
