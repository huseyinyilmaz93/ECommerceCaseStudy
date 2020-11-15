using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Enums;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;

namespace ECommerce.Web.Repositories
{
    public class CampaignReader : ICampaignReader
    {
        private readonly ICampaignHolder _campaignHolder;

        public CampaignReader(ICampaignHolder campaignHolder)
        {
            _campaignHolder = campaignHolder;
        }

        public List<Campaign> List()
        {
            return _campaignHolder.CampaignList.Where(c => c.Status != CampaignStatus.Ended).ToList();
        }

        public Campaign Get(Product product)
        {
            return _campaignHolder.CampaignList.SingleOrDefault(c => c.Product == product && c.Status != CampaignStatus.Ended);
        }

        public Campaign Get(string name)
        {
            return _campaignHolder.CampaignList.SingleOrDefault(c => c.Name == name);
        }
    }
}
