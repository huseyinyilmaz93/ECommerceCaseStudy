using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
