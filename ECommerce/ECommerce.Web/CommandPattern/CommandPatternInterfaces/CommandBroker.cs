using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Models;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public class CommandBroker : ICommandBroker
    {
        private List<ICommand> _commandList;

        private readonly ITimer _timer;
        private readonly IOrderHolder _orderHolder;
        private readonly IProductHolder _productHolder;
        private readonly ICampaignHolder _campaignHolder;

        public CommandBroker(ITimer timer, IOrderHolder orderHolder, IProductHolder productHolder, ICampaignHolder campaignHolder)
        {
            _commandList = new List<ICommand>();

            _timer = timer;
            _orderHolder = orderHolder;
            _productHolder = productHolder;
            _campaignHolder = campaignHolder;
        }

        public void StageCommand(ICommand command)
        {
            _commandList.Add(command);
        }

        public StringBuilder ExecuteCommands()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var command in _commandList)
            {
                stringBuilder.AppendLine(command.Execute());
            }

            return stringBuilder;
        }

        public void DeleteAllRecords()
        {
            _timer.ResetTime();

            _orderHolder.OrderList = new List<Order>();
            _productHolder.ProductList = new List<Product>();
            _campaignHolder.CampaignList = new List<Campaign>();

            _commandList = new List<ICommand>();
        }
    }
}
