using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class CreateProductCommand : ICommand
    {
        private readonly IProductCreator _productCreator;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly ICommandParameterHelper _commandParameterHelper;

        private CreateProductCommandParameters _parameters;

        public CreateProductCommand(IProductCreator productCreator,
            IStringifyHelper stringifyHelper,
            ICommandParameterHelper commandParameterHelper)
        {
            _productCreator = productCreator;
            _stringifyHelper = stringifyHelper;
            _commandParameterHelper = commandParameterHelper;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameterHelper.GetCreateProductCommandParameter(commandText);
        }

        public string Execute()
        {
            var product = _productCreator.Create(_parameters.ProductCode, _parameters.Price, _parameters.Stock);
            return _stringifyHelper.StringifyCreateProductCommand(product);
        }
    }
}
