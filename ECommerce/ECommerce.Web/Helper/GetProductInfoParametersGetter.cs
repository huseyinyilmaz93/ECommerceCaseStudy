using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class GetProductInfoParametersGetter : IGetProductInfoParametersGetter
    {
        public GetProductInfoCommandParameters GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            return new GetProductInfoCommandParameters(parameters[1].ToString());
        }
    }
}
