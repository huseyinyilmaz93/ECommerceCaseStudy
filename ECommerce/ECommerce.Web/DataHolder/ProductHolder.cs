using System.Collections.Generic;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder
{
    public class ProductHolder : IProductHolder
    {
        public List<Product> ProductList { get; set; }

        public ProductHolder()
        {
            ProductList = new List<Product>();
        }
    }
}
