using System.Collections.Generic;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder.DataHolderInterfaces
{
    public interface IProductHolder
    {
        public List<Product> ProductList { get; set; }
    }
}
