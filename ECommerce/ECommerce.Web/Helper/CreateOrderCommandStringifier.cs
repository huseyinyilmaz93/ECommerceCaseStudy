using System;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.Helper
{
    public class CreateOrderCommandStringifier : ICreateOrderCommandStringifier
    {
        public string Stringify(Order order)
        {
            return string.Format("Order created; product {0}, quantity {1}", order.Product.ProductCode, order.Quantity);
        }
    }
}
