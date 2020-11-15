using System;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.Helper
{
    public class CreateProductCommandStringifier : ICreateProductCommandStringifier
    {
        public string Stringify(Product product)
        {
            return string.Format("Product created; code {0}, price {1}, stock {2}", product.ProductCode, product.Price, product.Stock);
        }
    }
}
