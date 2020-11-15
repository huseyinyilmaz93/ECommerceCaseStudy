using System;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.Helper
{
    public class GetCampaignInfoCommandStringifier : IGetCampaignInfoCommandStringifier
    {
        public string Stringify(Campaign campaign)
        {
            return string.Format(
                "Campaign {0} info; Status {1}, Target Sales {2}, Total Sales {3}, Turnover {4}, Average Item Price {5}",
                campaign.Name, campaign.Status.ToString(), campaign.TargetSalesCount, campaign.TotalSales,
                campaign.Turnover, campaign.AverageItemPrice);
        }
    }
}
