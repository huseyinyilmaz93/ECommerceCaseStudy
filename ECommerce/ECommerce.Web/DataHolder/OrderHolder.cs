using System.Collections.Generic;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder
{
    public class OrderHolder : IOrderHolder
    {
        public List<Order> OrderList { get; set; }

        public OrderHolder()
        {
            OrderList = new List<Order>();
        }
    }
}
