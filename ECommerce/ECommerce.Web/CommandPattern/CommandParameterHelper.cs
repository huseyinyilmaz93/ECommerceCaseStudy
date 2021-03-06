﻿using System;
using ECommerce.Web.Constants;
using ECommerce.Web.Extensions;
using ECommerce.Web.Models.CommandParameterStructures;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public class CommandParameterHelper : ICommandParameterHelper
    {
        private readonly ICommandParameterValidator _commandParameterValidator;

        public CommandParameterHelper(ICommandParameterValidator commandParameterValidator)
        {
            _commandParameterValidator = commandParameterValidator;
        }

        public CreateCampaignCommandParameters GetCreateCampaignCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters,  ECommerceConstants.CreateCampaignCommandParameterCount);
            return new CreateCampaignCommandParameters(parameters[1].ToString(), parameters[2].ToString(),
                Int32.Parse(parameters[3]), Int16.Parse(parameters[4]), Int32.Parse(parameters[5]));
        }

        public CreateOrderCommandParameters GetCreateOrderCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters, ECommerceConstants.CreateOrderCommandParameterCount);
            return new CreateOrderCommandParameters(parameters[1].ToString(),
                Int32.Parse(parameters[2]));
        }

        public CreateProductCommandParameters GetCreateProductCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters, ECommerceConstants.CreateProductCommandParameterCount);
            return new CreateProductCommandParameters(parameters[1].ToString(), Decimal.Parse(parameters[2]),
                Int32.Parse(parameters[3]));
        }

        public GetCampaignInfoCommandParameters GetCampaignInfoCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters,  ECommerceConstants.CampaignInfoCommandParameterCount);
            return new GetCampaignInfoCommandParameters(parameters[1].ToString());
        }

        public GetProductInfoCommandParameters GetProductInfoCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters, ECommerceConstants.ProductInfoCommandParameterCount);
            return new GetProductInfoCommandParameters(parameters[1].ToString());
        }

        public IncreaseTimeCommandParameter GetIncreaseTimeCommandParameter(string commandText)
        {
            var parameters = commandText.SplitBySingleSpace();
            _commandParameterValidator.Validate(parameters, ECommerceConstants.IncreaseTimeCommandParameterCount);
            return new IncreaseTimeCommandParameter(Int32.Parse(parameters[1]));
        }
    }
}
