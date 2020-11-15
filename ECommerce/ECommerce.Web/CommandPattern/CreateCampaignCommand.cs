using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class CreateCampaignCommand : ICommand
    {
        private readonly IProductReader _productReader;
        private readonly ICampaignCreator _campaignCreator;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly ICommandParameterHelper _commandParameterHelper;
        private readonly IProductDoesNotExistValidator _productDoesNotExistValidator;

        private CreateCampaignCommandParameters _parameters;

        public CreateCampaignCommand(IProductReader productReader, ICampaignCreator campaignCreator, IStringifyHelper stringifyHelper,
            ICommandParameterHelper commandParameterHelper, IProductDoesNotExistValidator productDoesNotExistValidator)
        {
            _productReader = productReader;
            _campaignCreator = campaignCreator;
            _stringifyHelper = stringifyHelper;
            _commandParameterHelper = commandParameterHelper;
            _productDoesNotExistValidator = productDoesNotExistValidator;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameterHelper.GetCreateCampaignCommandParameter(commandText);
        }

        public string Execute()
        {
            var product = _productReader.Get(_parameters.ProductCode);
            _productDoesNotExistValidator.Validate(product);
            var campaign = _campaignCreator.Create(product, _parameters.Name, _parameters.Duration, _parameters.Limit, _parameters.TargetSalesCount);
            return _stringifyHelper.StringifyCreateCampaignCommand(campaign);
        }
    }
}
