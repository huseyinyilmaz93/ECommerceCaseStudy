using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class GetProductInfoCommand : ICommand
    {
        private readonly IProductReader _productReader;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly ICommandParameterHelper _commandParameter;

        private GetProductInfoCommandParameters _parameters;

        public GetProductInfoCommand(IProductReader productReader,
            IStringifyHelper stringifyHelper,
            ICommandParameterHelper commandParameter)
        {
            _productReader = productReader;
            _stringifyHelper = stringifyHelper;
            _commandParameter = commandParameter;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameter.GetProductInfoCommandParameter(commandText);
        }

        public string Execute()
        {
            var product = _productReader.Get(_parameters.ProductCode);
            return _stringifyHelper.StringifyGetProductInfoCommand(product);
        }
    }
}
