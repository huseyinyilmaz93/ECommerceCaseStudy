using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class CreateOrderCommand : ICommand
    {
        private readonly IOrderCreator _orderCreator;
        private readonly IProductReader _productReader;
        private readonly IStringifyHelper _stringifyHelper;
        private readonly ICommandParameterHelper _commandParameterHelper;
        private readonly IProductDoesNotExistValidator _productDoesNotExistValidator;

        private CreateOrderCommandParameters _parameters;

        public CreateOrderCommand(IOrderCreator orderCreator, IProductReader productReader,
            IStringifyHelper stringifyHelper,
            ICommandParameterHelper commandParameterHelper,
            IProductDoesNotExistValidator productDoesNotExistValidator)
        {
            _orderCreator = orderCreator;
            _productReader = productReader;
            _stringifyHelper = stringifyHelper;
            _commandParameterHelper = commandParameterHelper;
            _productDoesNotExistValidator = productDoesNotExistValidator;
        }

        public void GetParameters(string commandText)
        {
            _parameters = _commandParameterHelper.GetCreateOrderCommandParameter(commandText);
        }

        public string Execute()
        {
            var product = _productReader.Get(_parameters.ProductCode);
            _productDoesNotExistValidator.Validate(product);
            var order = _orderCreator.Create(product, _parameters.Quantity);
            return _stringifyHelper.StringifyCreateOrderCommand(order);
        }
    }
}
