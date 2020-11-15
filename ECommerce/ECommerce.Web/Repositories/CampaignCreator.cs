using System;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Enums;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Repositories
{
    public class CampaignCreator : ICampaignCreator
    {
        private readonly ITimer _timer;
        private readonly ICampaignHolder _campaignHolder;
        private readonly IPriceManipulationEvent _priceManipulationEvent;
        private readonly ICampaignExistanceForProductValidator _campaignExistanceForProductValidator;

        public CampaignCreator(ITimer timer, ICampaignHolder campaignHolder,
            IPriceManipulationEvent priceManipulationEvent,
            ICampaignExistanceForProductValidator campaignExistanceForProductValidator)
        {
            _timer = timer;
            _campaignHolder = campaignHolder;
            _priceManipulationEvent = priceManipulationEvent;
            _campaignExistanceForProductValidator = campaignExistanceForProductValidator;
        }

        public Campaign Create(Product product, string name, int duration, short limit, int targetSalesCount)
        {
            _campaignExistanceForProductValidator.Validate(product);
            var currentDateTime = _timer.GetCurrentDateTime();

            var campaign = new Campaign()
            {
                Product = product, Name = name, Duration = duration, Limit = limit, TargetSalesCount = targetSalesCount,
                Status = CampaignStatus.Active, ActivationDateTime = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second)
            };

            _campaignHolder.CampaignList.Add(campaign);
            _priceManipulationEvent.Manipulate(campaign);
            return campaign;
        }
    }
}
