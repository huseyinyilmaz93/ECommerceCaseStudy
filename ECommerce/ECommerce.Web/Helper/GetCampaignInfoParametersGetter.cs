using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class GetCampaignInfoParametersGetter : IGetCampaignInfoParametersGetter
    {
        public GetCampaignInfoCommandParameters GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            return new GetCampaignInfoCommandParameters(parameters[1].ToString());

        }
    }
}
