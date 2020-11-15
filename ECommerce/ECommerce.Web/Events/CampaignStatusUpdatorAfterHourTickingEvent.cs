using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Services.ServiceInterfaces;

namespace ECommerce.Web.Events
{
    public class CampaignStatusUpdatorAfterHourTickingEvent : ICampaignStatusUpdatorAfterHourTickingEvent
    {
        private readonly ITimer _timer;
        private readonly ICampaignReader _campaignReader;
        private readonly ICampaignEnderService _campaignEnderService;
        public CampaignStatusUpdatorAfterHourTickingEvent(ITimer timer, ICampaignReader campaignReader, ICampaignEnderService campaignEnderService)
        {
            _timer = timer;
            _campaignReader = campaignReader;
            _campaignEnderService = campaignEnderService;
        }

        public void UpdateCampaignStatus()
        {
            foreach (var campaign in _campaignReader.List())
            {
                if (campaign.ActivationDateTime.AddHours(campaign.Duration) < _timer.GetCurrentDateTime())
                {
                    _campaignEnderService.EndCampaign(campaign);
                }
            }

        }
    }
}
