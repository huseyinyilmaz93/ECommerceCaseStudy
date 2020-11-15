using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class GetCampaignInfoCommand : ICommand
    {
        private readonly ICampaignReader _campaignReader;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly ICommandParameterHelper _commandParameterHelper;

        private GetCampaignInfoCommandParameters _parameters;

        public GetCampaignInfoCommand(ICampaignReader campaignReader,
            IStringifyHelper stringifyHelper,
            ICommandParameterHelper commandParameterHelper)
        {
            _campaignReader = campaignReader;
            _stringifyHelper = stringifyHelper;
            _commandParameterHelper = commandParameterHelper;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameterHelper.GetCampaignInfoCommandParameter(commandText);
        }

        public string Execute()
        {
            var campaign = _campaignReader.Get(_parameters.Name);
            return _stringifyHelper.StringifyGetCampaignInfoCommand(campaign);
        }
    }
}
