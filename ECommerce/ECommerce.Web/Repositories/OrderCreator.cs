using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Services.ServiceInterfaces;
using ECommerce.Web.Validators;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Repositories
{
    public class OrderCreator : IOrderCreator
    {
        private readonly IOrderHolder _orderHolder;
        private readonly IStockAmountValidator _stockAmountValidator;
        private readonly IStockAmountReduceService _stockAmountReduceService;

        public OrderCreator(IOrderHolder orderHolder,
            IStockAmountValidator stockAmountValidator,
            IStockAmountReduceService stockAmountReduceService)
        {
            _orderHolder = orderHolder;
            _stockAmountValidator = stockAmountValidator;
            _stockAmountReduceService = stockAmountReduceService;
        }

        public Order Create(Product product, decimal quantity)
        {
            var order = new Order() {Product = product, Quantity = quantity};
            
            _orderHolder.OrderList.Add(order);
            _stockAmountValidator.Validate(product.Stock, quantity);
            _stockAmountReduceService.ReduceStock(product, quantity);

            return order;
        }
    }
}
