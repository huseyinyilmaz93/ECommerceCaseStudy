using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Web.CommandPattern;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Exceptions;
using ECommerce.Web.FactoryMethod.FactoryMethodInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Web.FactoryMethod
{
    public class CommandCreator : ICommandCreator
    {
        private readonly IServiceProvider _serviceProvider;

        private Dictionary<string, Type> _commandDictionary = new Dictionary<string, Type>()
        {
            { "create_product", typeof(CreateProductCommand) },
            { "get_product_info", typeof(GetProductInfoCommand) },
            { "create_order", typeof(CreateOrderCommand) },
            { "create_campaign", typeof(CreateCampaignCommand) },
            { "get_campaign_info", typeof(GetCampaignInfoCommand) },
            { "increase_time", typeof(IncreaseTimeCommand) },
        };



        private readonly List<ICommand> _commandList;
        public CommandCreator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommand GetCommand(string commandText)
        {
            var commandKey = commandText?.Split(' ')?.FirstOrDefault() ?? string.Empty;

            if (_commandDictionary.ContainsKey(commandKey))
            {
                Type type = _commandDictionary[commandKey];
                var command = _serviceProvider.GetServices<ICommand>().Single(c => c.GetType() == type);
                command.GetParameters(commandText);
                return command;
            }

            throw new ECommerceExceptions.CommandIsNotKnownException(commandText);
        }
    }
}
