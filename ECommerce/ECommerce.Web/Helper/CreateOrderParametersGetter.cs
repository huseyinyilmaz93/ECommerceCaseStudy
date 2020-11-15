using ECommerce.Web.Helper.HelperInterfaces;
using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class CreateOrderParametersGetter : ICreateOrderParametersGetter
    {
        public CreateOrderCommandParameters GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            return new CreateOrderCommandParameters(parameters[1].ToString(),
                Int32.Parse(parameters[2]));
        }
    }
}
