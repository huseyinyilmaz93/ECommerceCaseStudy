using System;
using System.Collections.Generic;
using ECommerce.Web.CommandPattern;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.DataHolder;
using ECommerce.Web.DataHolder.DataHolderInterfaces;
using ECommerce.Web.Events;
using ECommerce.Web.Events.EventInterfaces;
using ECommerce.Web.FactoryMethod;
using ECommerce.Web.FactoryMethod.FactoryMethodInterfaces;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories;
using ECommerce.Web.Repositories.RepositoryInterfaces;
using ECommerce.Web.Services;
using ECommerce.Web.Services.ServiceInterfaces;
using ECommerce.Web.Validators;
using ECommerce.Web.Validators.ValidatorInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace ECommerce.UnitTest
{
    public class BaseUnitTest
    {

        protected IServiceProvider _serviceProvider;

        //private IOrderHolder _orderHolder;
        //private IProductHolder _productHolder;
        //private ICampaignHolder _campaignHolder;

        //private IOrderCreator _orderCreator;
        //private IProductCreator _productCreator;
        //private ICampaignCreator _campaignCreator;

        protected Mock<IServiceProvider> _serviceProviderMock;

        protected Mock<IProductHolder> _productHolderMock;
        protected Mock<ICampaignHolder> _campaignHolderMock;
        protected Mock<IOrderHolder> _orderHolderMock;

        protected Mock<IProductCreator> _productCreatorMock;
        protected Mock<ICampaignCreator> _campaignCreatorMock;
        protected Mock<IOrderCreator> _orderCreatorMock;

        protected Mock<IProductReader> _productReaderMock;
        protected Mock<ICampaignReader> _campaignReader;

        protected Mock<IStringifyHelper> _stringifyHelper;
        protected Mock<ICommandParameterHelper> _commandParameterHelper;

        //Mock<ICreateCampaignParametersGetter> _createCampaignParametersGetterMock;
        //Mock<ICreateOrderParametersGetter> _createOrderParametersGetterMock;
        //Mock<ICreateProductParametersGetter> _createProductParametersGetterMock;
        //Mock<IGetCampaignInfoParametersGetter> _getCampaignInfoParametersGetterMock;
        //Mock<IGetProductInfoParametersGetter> _getProductInfoParametersGetterMock;
        //Mock<IIncreaseTimeParametersGetter> _increaseTimeParametersGetterMock;

        //Mock<ICreateCampaignCommandStringifier> _createCampaignCommandStringifierMock;
        //Mock<ICreateOrderCommandStringifier> _createOrderCommandStringifierMock;
        //Mock<ICreateProductCommandStringifier> _createProductCommandStringifierMock;
        //Mock<IGetCampaignInfoCommandStringifier> _getCampaignInfoCommandStringifierMock;
        //Mock<IGetProductInfoCommandStringifier> _getProductInfoCommandStringifierMock;
        //Mock<IIncreaseTimeCommandStringifier> _increaseTimeCommandStringifierMock;

        protected Mock<ICommandParameterValidator> _commandParameterValidator;
        protected Mock<IProductExistanceValidator> _productExistanceValidatorMock;
        protected Mock<IProductDoesNotExistValidator> _productDoesNotExistValidatorMock;
        protected Mock<ICampaignExistanceForProductValidator> _campaignExistanceForProductValidatorMock;
        protected Mock<IStockAmountValidator> _stockAmountValidatorMock;

        protected Mock<IPriceManipulationEvent> _priceManipulationEventMock;
        protected Mock<ICampaignStatusUpdatorAfterHourTickingEvent> _campaignStatusUpdatorAfterHourTickingEventMock;
        protected Mock<ICampaignUpdatorAfterStockReducementEvent> _campaignUpdatorAfterStockReducementEventMock;

        protected Mock<ICampaignEnderService> _campaignEnderServiceMock;
        protected Mock<IStockAmountReduceService> _stockAmountReduceServiceMock;

        protected Mock<ICommandCreator> _commandCreatorMock;
        protected Mock<ICommandBroker> _commandBrokerMock;
        protected Mock<ITimer> _timerMock;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IProductHolder, ProductHolder>();
            services.AddSingleton<IOrderHolder, OrderHolder>();
            services.AddSingleton<ICampaignHolder, CampaignHolder>();

            services.AddSingleton<IProductCreator, ProductCreator>();
            services.AddSingleton<IOrderCreator, OrderCreator>();
            services.AddSingleton<ICampaignCreator, CampaignCreator>();

            services.AddSingleton<IProductReader, ProductReader>();
            services.AddSingleton<ICampaignReader, CampaignReader>();

            services.AddSingleton<IStringifyHelper, StringifyHelper>();
            services.AddSingleton<ICommandParameterHelper, CommandParameterHelper>();

            services.AddSingleton<IProductExistanceValidator, ProductExistanceValidator>();
            services.AddSingleton<ICommandParameterValidator, CommandParameterValidator>();
            services.AddSingleton<IProductDoesNotExistValidator, ProductDoesNotExistValidator>();
            services.AddSingleton<ICampaignExistanceForProductValidator, CampaignExistanceForProductValidator>();
            services.AddSingleton<IStockAmountValidator, StockAmountValidator>();

            services.AddTransient<ICommand, CreateCampaignCommand>();
            services.AddTransient<ICommand, CreateOrderCommand>();
            services.AddTransient<ICommand, CreateProductCommand>();
            services.AddTransient<ICommand, GetCampaignInfoCommand>();
            services.AddTransient<ICommand, GetProductInfoCommand>();
            services.AddTransient<ICommand, IncreaseTimeCommand>();


            services.AddSingleton<IPriceManipulationEvent, PriceManipulationEvent>();
            services.AddSingleton<ICampaignStatusUpdatorAfterHourTickingEvent, CampaignStatusUpdatorAfterHourTickingEvent>();
            services.AddSingleton<ICampaignUpdatorAfterStockReducementEvent, CampaignUpdatorAfterStockReducementEvent>();

            services.AddSingleton<ICampaignEnderService, CampaignEnderService>();
            services.AddSingleton<IStockAmountReduceService, StockAmountReduceService>();

            services.AddSingleton<ICommandCreator, CommandCreator>();
            services.AddSingleton<ICommandBroker, CommandBroker>();
            services.AddSingleton<ITimer, Timer>();

            _serviceProvider = services.BuildServiceProvider();

            _serviceProviderMock = new Mock<IServiceProvider>();

            _productHolderMock = new Mock<IProductHolder>(MockBehavior.Loose);
            _campaignHolderMock = new Mock<ICampaignHolder>(MockBehavior.Loose);
            _orderHolderMock = new Mock<IOrderHolder>(MockBehavior.Loose);

            _productCreatorMock = new Mock<IProductCreator>(MockBehavior.Loose);
            _campaignCreatorMock = new Mock<ICampaignCreator>(MockBehavior.Loose);
            _orderCreatorMock = new Mock<IOrderCreator>(MockBehavior.Loose);

            _stringifyHelper = new Mock<IStringifyHelper>();
            _commandParameterHelper = new Mock<ICommandParameterHelper>();

            _productReaderMock = new Mock<IProductReader>();
            _campaignReader = new Mock<ICampaignReader>();

            //_createCampaignParametersGetterMock = new Mock<ICreateCampaignParametersGetter>(MockBehavior.Loose);
            //_createOrderParametersGetterMock = new Mock<ICreateOrderParametersGetter>(MockBehavior.Loose);
            //_createProductParametersGetterMock = new Mock<ICreateProductParametersGetter>(MockBehavior.Loose);
            //_getCampaignInfoParametersGetterMock = new Mock<IGetCampaignInfoParametersGetter>(MockBehavior.Loose);
            //_getProductInfoParametersGetterMock = new Mock<IGetProductInfoParametersGetter>(MockBehavior.Loose);
            //_increaseTimeParametersGetterMock = new Mock<IIncreaseTimeParametersGetter>(MockBehavior.Loose);

            //_createCampaignCommandStringifierMock = new Mock<ICreateCampaignCommandStringifier>(MockBehavior.Loose);
            //_createOrderCommandStringifierMock = new Mock<ICreateOrderCommandStringifier>(MockBehavior.Loose);
            //_createProductCommandStringifierMock = new Mock<ICreateProductCommandStringifier>(MockBehavior.Loose);
            //_getCampaignInfoCommandStringifierMock = new Mock<IGetCampaignInfoCommandStringifier>(MockBehavior.Loose);
            //_getProductInfoCommandStringifierMock = new Mock<IGetProductInfoCommandStringifier>(MockBehavior.Loose);
            //_increaseTimeCommandStringifierMock = new Mock<IIncreaseTimeCommandStringifier>(MockBehavior.Loose);

            _commandParameterValidator = new Mock<ICommandParameterValidator>(MockBehavior.Loose);
            _productExistanceValidatorMock = new Mock<IProductExistanceValidator>(MockBehavior.Loose);
            _productDoesNotExistValidatorMock = new Mock<IProductDoesNotExistValidator>(MockBehavior.Loose);
            _campaignExistanceForProductValidatorMock = new Mock<ICampaignExistanceForProductValidator>(MockBehavior.Loose);
            _stockAmountValidatorMock = new Mock<IStockAmountValidator>(MockBehavior.Loose);

            _priceManipulationEventMock = new Mock<IPriceManipulationEvent>(MockBehavior.Loose);
            _campaignStatusUpdatorAfterHourTickingEventMock = new Mock<ICampaignStatusUpdatorAfterHourTickingEvent>(MockBehavior.Loose);
            _campaignUpdatorAfterStockReducementEventMock = new Mock<ICampaignUpdatorAfterStockReducementEvent>(MockBehavior.Loose);

            _campaignEnderServiceMock = new Mock<ICampaignEnderService>(MockBehavior.Loose);
            _stockAmountReduceServiceMock = new Mock<IStockAmountReduceService>(MockBehavior.Loose);

            _commandCreatorMock = new Mock<ICommandCreator>(MockBehavior.Loose);
            _commandBrokerMock = new Mock<ICommandBroker>(MockBehavior.Loose);
            _timerMock = new Mock<ITimer>(MockBehavior.Loose);
        }

        public void MockProductHolder()
        {
            _productHolderMock.Setup(ph => ph.ProductList).Returns(new List<Product>());
        }

        public void MockOrderHolder()
        {
            _orderHolderMock.Setup(oh => oh.OrderList).Returns(new List<Order>());
        }

        public void MockCampaignHolder()
        {
            _campaignHolderMock.Setup(ch => ch.CampaignList).Returns(new List<Campaign>());
        }

        public ICampaignCreator GetCampaignCreator()
        {
            MockCampaignHolder();
            return new CampaignCreator(_timerMock.Object, _campaignHolderMock.Object, _priceManipulationEventMock.Object,
                _campaignExistanceForProductValidatorMock.Object);
        }

        public IOrderCreator GetOrderCreator()
        {
            MockOrderHolder();
            return new OrderCreator(_orderHolderMock.Object, _stockAmountValidatorMock.Object,
                _stockAmountReduceServiceMock.Object);
        }

        public IProductCreator GetProductCreator()
        {
            MockProductHolder();
            return new ProductCreator(_productHolderMock.Object);
        }

        public IStringifyHelper MockStringifyHelper()
        {
            return new StringifyHelper(_timerMock.Object);
        }

        public ICommandParameterHelper MockCommandParameterHelper()
        {
            return new CommandParameterHelper(_commandParameterValidator.Object);
        }

        public Product CreateAProduct(string productCode, decimal price, int stock)
        {
            return GetProductCreator().Create("P1", 100, 100);
        }

        public Campaign CreateACampaign(Product product, string name, int duration, short limit, int targetSalesCount)
        {
            return GetCampaignCreator().Create(product, name, duration, limit, targetSalesCount);
        }

        public Order CreateAnOrder(Product product, decimal quantity)
        {
            return GetOrderCreator().Create(product, quantity);
        }
        
    }
}