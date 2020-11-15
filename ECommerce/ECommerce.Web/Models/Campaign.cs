using System;
using ECommerce.Web.Enums;

namespace ECommerce.Web.Models
{
    public class Campaign
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public CampaignStatus Status { get; set; }
        public int Duration { get; set; }
        public short Limit { get; set; }
        public int TargetSalesCount { get; set; }
        public decimal TotalSales { get; set; }
        public decimal Turnover { get; set; }
        public decimal AverageItemPrice { get; set; }
        public DateTime ActivationDateTime { get; set; }
    }
}
