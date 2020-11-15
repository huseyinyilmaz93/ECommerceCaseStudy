using System.Collections.Generic;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder
{
    public class CampaignHolder : ICampaignHolder
    {
        public List<Campaign> CampaignList { get; set; }

        public CampaignHolder()
        {
            CampaignList = new List<Campaign>();
        }
    }
}
