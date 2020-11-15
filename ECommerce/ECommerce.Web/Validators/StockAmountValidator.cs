using ECommerce.Web.Exceptions;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Validators
{
    public class StockAmountValidator : IStockAmountValidator
    {
        public void Validate(decimal stock, decimal quantity)
        {
            if (stock - quantity < 0)
            {
                throw new ECommerceExceptions.InsufficentStockAmountException();
            }
        }
    }
}
