using System;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Repositories
{
    public class ProductCreator : IProductCreator
    {
        private readonly IProductHolder _productHolder;
        private readonly IProductExistanceValidator _productExistanceValidator;

        public ProductCreator(IProductHolder productHolder, IProductExistanceValidator productExistanceValidator)
        {
            _productHolder = productHolder;
            _productExistanceValidator = productExistanceValidator;
        }

        public Product Create(string productCode, decimal price, decimal stock)
        {
            _productExistanceValidator.Validate(productCode);

            var product = new Product() {Price = price, ProductCode = productCode, Stock = stock};
            _productHolder.ProductList.Add(product);
            return product;
        }
    }
}
