using System.Collections.Generic;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder.DataHolderInterfaces
{
    public interface IOrderHolder
    {
        public List<Order> OrderList { get; set; }
    }
}
