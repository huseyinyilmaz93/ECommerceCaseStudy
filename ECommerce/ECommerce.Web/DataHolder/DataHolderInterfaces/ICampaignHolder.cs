using System.Collections.Generic;
using ECommerce.Web.Models;

namespace ECommerce.Web.DataHolder.DataHolderInterfaces
{
    public interface ICampaignHolder
    {
        public List<Campaign> CampaignList { get; set; }
    }
}
