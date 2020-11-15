using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class IncreaseTimeCommand : ICommand
    {
        private readonly ITimer _timer;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly IPriceManipulationEvent _priceManipulationEvent;
        private readonly ICommandParameterHelper _commandParameterHelper;
        private readonly ICampaignStatusUpdatorAfterHourTickingEvent _campaignStatusUpdatorAfterHourTickingEvent;

        private IncreaseTimeCommandParameter _parameters;

        public IncreaseTimeCommand(ITimer timer, ICampaignReader campaignReader, IStringifyHelper stringifyHelper,
            IPriceManipulationEvent priceManipulationEvent,
            ICommandParameterHelper commandParameterHelper,
            ICampaignStatusUpdatorAfterHourTickingEvent campaignStatusUpdatorAfterHourTickingEvent)
        {
            _timer = timer;
            _stringifyHelper = stringifyHelper;
            _priceManipulationEvent = priceManipulationEvent;
            _commandParameterHelper = commandParameterHelper;
            _campaignStatusUpdatorAfterHourTickingEvent = campaignStatusUpdatorAfterHourTickingEvent;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameterHelper.GetIncreaseTimeCommandParameter(commandText);
        }

        public string Execute()
        {
            _timer.IncreaseTime(_parameters.Hour);
            _campaignStatusUpdatorAfterHourTickingEvent.UpdateCampaignStatus();
            _priceManipulationEvent.ManipulateAllCampaigns();
            return _stringifyHelper.StringifyIncreaseTimeCommand();
        }
    }
}
