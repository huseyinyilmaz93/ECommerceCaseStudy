using ECommerce.Web.Exceptions;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Validators
{
    public class ProductDoesNotExistValidator : IProductDoesNotExistValidator
    {
        private readonly IProductReader _productReader;

        public ProductDoesNotExistValidator(IProductReader productReader)
        {
            _productReader = productReader;
        }

        public void Validate(Product product)
        {
            if (product == null)
            {
                throw new ECommerceExceptions.ProductDoesNotExistException();
            }
        }
    }
}
