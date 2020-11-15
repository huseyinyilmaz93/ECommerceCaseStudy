using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class CreateCampaignParametersGetter : ICreateCampaignParametersGetter
    {
        private ICommandParameterValidator _commandParameterValidator;

        public CreateCampaignCommandParameters GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();



            return new CreateCampaignCommandParameters(parameters[1].ToString(), parameters[2].ToString(),
                Int32.Parse(parameters[3]), Int16.Parse(parameters[4]), Int32.Parse(parameters[5]));
        }
    }
}
