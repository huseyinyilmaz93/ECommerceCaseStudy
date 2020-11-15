using System.Collections.Generic;
using ECommerce.Web.Models;

namespace ECommerce.Web.Repositories.RepositoryInterfaces
{
    public interface ICampaignReader
    {
        List<Campaign> List();
        Campaign Get(Product product);
        Campaign Get(string name);
    }
}
