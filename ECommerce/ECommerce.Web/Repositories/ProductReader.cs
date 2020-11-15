using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.Repositories
{
    public class ProductReader : IProductReader
    {
        private readonly IProductHolder _productHolder;

        public ProductReader(IProductHolder productHolder)
        {
            _productHolder = productHolder;
        }

        public Product Get(string productCode)
        {
            return _productHolder.ProductList.FirstOrDefault(p => p.ProductCode == productCode);
        }
    }
}
