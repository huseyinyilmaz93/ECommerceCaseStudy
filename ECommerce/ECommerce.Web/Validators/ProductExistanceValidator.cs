using ECommerce.Web.Exceptions;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Validators
{
    public class ProductExistanceValidator : IProductExistanceValidator
    {
        private readonly IProductReader _productReader;

        public ProductExistanceValidator(IProductReader productReader)
        {
            _productReader = productReader;
        }
        public void Validate(string productCode)
        {
            var product = _productReader.Get(productCode);
            Validate(product);
        }

        public void Validate(Product product)
        {
            if (product != null)
            {
                throw new ECommerceExceptions.ProductExistsException();
            }
        }
    }
}
