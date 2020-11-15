using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class IncreaseTimeParametersGetter : IIncreaseTimeParametersGetter
    {
        public IncreaseTimeCommandParameter GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            return new IncreaseTimeCommandParameter(Int32.Parse(parameters[1]));
        }
    }
}
