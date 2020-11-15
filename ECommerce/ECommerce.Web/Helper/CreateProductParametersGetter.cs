using System;
using ECommerce.Web.Extensions;
using ECommerce.Web.Helper.HelperInterfaces;
using ECommerce.Web.Models.CommandParameterStructures;

namespace ECommerce.Web.Helper
{
    public class CreateProductParametersGetter : ICreateProductParametersGetter
    {
        public CreateProductCommandParameters GetParameters(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            return new CreateProductCommandParameters(parameters[1].ToString(), Decimal.Parse(parameters[2]),
                Int32.Parse(parameters[3]));
        }
    }
}
