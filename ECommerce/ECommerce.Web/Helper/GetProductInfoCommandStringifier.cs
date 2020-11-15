using System;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.Helper
{
    public class GetProductInfoCommandStringifier : IGetProductInfoCommandStringifier
    {
        public string Stringify(Product product)
        {
            return string.Format("Product {0} info; price {1}, stock {2}", product.ProductCode, (product.Price + product.PriceManupulation),
                product.Stock);
        }
    }
}
