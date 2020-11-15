using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Web.Models;

namespace ECommerce.Web.Repositories.RepositoryInterfaces
{
    public interface IProductReader
    {
        Product Get(string productCode);
    }
}
