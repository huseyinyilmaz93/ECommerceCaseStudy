using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Web.CommandPattern;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Enums;
using ECommerce.Web.Events;
using ECommerce.Web.Exceptions;
using ECommerce.Web.FactoryMethod;
using ECommerce.Web.Models;
using ECommerce.Web.Repositories;
using ECommerce.Web.Services;
using ECommerce.Web.Validators;
using Moq;
using NUnit.Framework;

namespace ECommerce.UnitTest
{
    public class UnitTests : BaseUnitTest
    {
        [Test]
        public void ProductCreator_Create__creates_a_product_instance()
        {
            var productCreator = GetProductCreator();
            var createdProduct = productCreator.Create("P1", 100, 100);

            Assert.AreEqual(_productHolderMock.Object.ProductList.Count, 1);

            var actualObject = _productHolderMock.Object.ProductList.First();

            Assert.AreEqual(createdProduct.ProductCode, actualObject.ProductCode);
            Assert.AreEqual(createdProduct.Price, actualObject.Price);
            Assert.AreEqual(createdProduct.Stock, actualObject.Stock);
            Assert.AreEqual(createdProduct.PriceManupulation, actualObject.PriceManupulation);
        }

        [Test]
        public void CampaignCreator_Create_creates_a_campaign_instance()
        {
            var campaignCreator = GetCampaignCreator();

            var product = CreateAProduct("P1", 100, 100);
            var createdCampaign = campaignCreator.Create(product, "C1", 10, 30, 100);

            Assert.AreEqual(_campaignHolderMock.Object.CampaignList.Count, 1);

            var actualObject = _campaignHolderMock.Object.CampaignList.First();

            Assert.AreEqual(createdCampaign.ActivationDateTime, actualObject.ActivationDateTime);
            Assert.AreEqual(createdCampaign.AverageItemPrice, actualObject.AverageItemPrice);
            Assert.AreEqual(createdCampaign.Duration, actualObject.Duration);
            Assert.AreEqual(createdCampaign.Limit, actualObject.Limit);
            Assert.AreEqual(createdCampaign.Name, actualObject.Name);
            Assert.AreEqual(createdCampaign.Product, actualObject.Product);
            Assert.AreEqual(createdCampaign.Status, actualObject.Status);
            Assert.AreEqual(createdCampaign.TargetSalesCount, actualObject.TargetSalesCount);
            Assert.AreEqual(createdCampaign.TotalSales, actualObject.TotalSales);
            Assert.AreEqual(createdCampaign.Turnover, actualObject.Turnover);
        }

        [Test]
        public void OrderCreator_Create_creates_an_order_instance()
        {
            var orderCreator = GetOrderCreator();

            var createdOrder = orderCreator.Create(CreateAProduct("P1", 100, 100), 20);

            Assert.AreEqual(_orderHolderMock.Object.OrderList.Count, 1);

            var actualObject = _orderHolderMock.Object.OrderList.First();

            Assert.AreEqual(createdOrder.Product, actualObject.Product);
            Assert.AreEqual(createdOrder.Quantity, actualObject.Quantity);
        }

        [Test]
        public void ProductReader_Get_productCode__returns_product_by_product_code_if_exists()
        {
            var createdProduct = CreateAProduct("P1", 100, 10);

            var productReader = new ProductReader(_productHolderMock.Object);
            var readProduct = productReader.Get("P1");

            Assert.AreEqual(createdProduct, readProduct);
        }

        [Test]
        public void ProductReader_Get_productCode__returns_null_if_product_code_does_not_exist()
        {
            CreateAProduct("P1", 100, 10);

            var productReader = new ProductReader(_productHolderMock.Object);
            var readProduct = productReader.Get("P2");

            Assert.IsNull(readProduct);

        }

        [Test]
        public void CampaignReader_Get_name__returns_campaign_by_name_if_exists()
        {
            string name = "C1";
            var createdCampaign = CreateACampaign(CreateAProduct("P1", 100, 100), name, 10, 20, 100);

            var campaignReader = new CampaignReader(_campaignHolderMock.Object);
            var readCampaign = campaignReader.Get(name);

            Assert.AreEqual(createdCampaign, readCampaign);
        }

        [Test]
        public void CampaignReader_Get_name__returns_null_by_name_if_name_does_not_exist()
        {
            string name1 = "C1";
            string name2 = "C2";
            CreateACampaign(CreateAProduct("P1", 100, 100), name1, 10, 20, 100);

            var campaignReader = new CampaignReader(_campaignHolderMock.Object);
            var readCampaign = campaignReader.Get(name2);

            Assert.IsNull(readCampaign);
        }

        [Test]
        public void CampaignReader_Get_product__returns_campaign_if_campaign_definition_exists_for_given_product()
        {
            var product = CreateAProduct("P1", 100, 100);
            var createdCampaign = CreateACampaign(product, "C1", 10, 20, 100);

            var campaignReader = new CampaignReader(_campaignHolderMock.Object);
            var readCampaign = campaignReader.Get(product);

            Assert.AreEqual(createdCampaign, readCampaign);
        }

        [Test]
        public void CampaignReader_Get_product__returns_null_if_campaign_definition_does_not_exist_for_given_product()
        {
            var product1 = CreateAProduct("P1", 100, 100);
            var product2 = CreateAProduct("P2", 100, 100);

            CreateACampaign(product1, "C1", 10, 20, 100);

            var campaignReader = new CampaignReader(_campaignHolderMock.Object);
            var readCampaign = campaignReader.Get(product2);

            Assert.IsNull(readCampaign);
        }

        [Test]
        public void StringifyHelper_StringifyCreateCampaignCommand_campaign__stringifies_campaign()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format(
                "Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}",
                campaign.Name, campaign.Product.ProductCode, campaign.Duration, campaign.Limit,
                campaign.TargetSalesCount);

            var actual = stringifyHelper.StringifyCreateCampaignCommand(campaign);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyCreateOrderCommand_order__stringifies_order()
        {
            var product = CreateAProduct("P1", 100, 100);
            var order = CreateAnOrder(product, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Order created; product {0}, quantity {1}", order.Product.ProductCode,
                order.Quantity);

            var actual = stringifyHelper.StringifyCreateOrderCommand(order);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyCreateOrderCommand_product__stringifies_product()
        {
            var product = CreateAProduct("P1", 100, 100);
            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Product created; code {0}, price {1}, stock {2}", product.ProductCode, product.Price, product.Stock);

            var actual = stringifyHelper.StringifyCreateProductCommand(product);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetCampaignInfoCommand_campaign__stringifies_campaign()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format(
                "Campaign {0} info; Status {1}, Target Sales {2}, Total Sales {3}, Turnover {4}, Average Item Price {5}",
                campaign.Name, campaign.Status.ToString(), campaign.TargetSalesCount, campaign.TotalSales,
                campaign.Turnover, campaign.AverageItemPrice);

            var actual = stringifyHelper.StringifyGetCampaignInfoCommand(campaign);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetProductInfoCommand_product__stringifies_product()
        {
            var product = CreateAProduct("P1", 100, 100);

            var stringifyHelper = MockStringifyHelper();

            var expected = string.Format("Product {0} info; price {1}, stock {2}", product.ProductCode, (product.Price + product.PriceManupulation),
                product.Stock);

            var actual = stringifyHelper.StringifyGetProductInfoCommand(product);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void StringifyHelper_StringifyGetProductInfoCommand__stringifies_time()
        {
            var expected = string.Format("Time is {0}", _timerMock.Object.GetCurrentDateTime().ToString("HH:mm"));
            var stringifyHelper = MockStringifyHelper();

            var actual = stringifyHelper.StringifyIncreaseTimeCommand();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void
            CommandParameterHelper_GetCreateCampaignCommandParameter_commandText__returns_parameters_for_create_campaign_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedProductCode = "P1";
            var expectedTargetSalesCount = 100;
            var expectedDuration = 10;
            var expectedLimit = 20;
            var expectedName = "C1";

            var actualObj = commandParameterHelper.GetCreateCampaignCommandParameter("create_campaign C1 P1 10 20 100");

            Assert.AreEqual(expectedProductCode, actualObj.ProductCode);
            Assert.AreEqual(expectedTargetSalesCount, actualObj.TargetSalesCount);
            Assert.AreEqual(expectedName, actualObj.Name);
            Assert.AreEqual(expectedDuration, actualObj.Duration);
            Assert.AreEqual(expectedLimit, actualObj.Limit);

        }

        [Test]
        public void
            CommandParameterHelper_GetCreateOrderCommandParameter_commandText__returns_parameters_for_create_order_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedQuantity = 3;
            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCreateOrderCommandParameter("create_order P1 3");

            Assert.AreEqual(expectedQuantity, actualObj.Quantity);
            Assert.AreEqual(expectedProductCode, actualObj.ProductCode);
        }

        [Test]
        public void
            CommandParameterHelper_GetCreateProductCommandParameter_commandText__returns_parameters_for_create_product_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedPrice = 100;
            var expectedStock = 1000;
            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCreateProductCommandParameter("create_product P1 100 1000");

            Assert.AreEqual(actualObj.Price, expectedPrice);
            Assert.AreEqual(actualObj.Stock, expectedStock);
            Assert.AreEqual(actualObj.ProductCode, expectedProductCode);
        }

        [Test]
        public void
            CommandParameterHelper_GetCampaignInfoCommandParameter_commandText__returns_parameters_for_get_campaign_info_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedName = "C1";

            var actualObj = commandParameterHelper.GetCampaignInfoCommandParameter("get_campaign_info C1");

            Assert.AreEqual(expectedName, actualObj.Name);
        }

        [Test]
        public void
            CommandParameterHelper_GetProductInfoCommandParameter_commandText__returns_parameters_for_get_product_info_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedProductCode = "P1";

            var actualObj = commandParameterHelper.GetCampaignInfoCommandParameter("get_product_info P1");

            Assert.AreEqual(expectedProductCode, actualObj.Name);
        }

        [Test]
        public void
            CommandParameterHelper_GetIncreaseTimeCommandParameter_commandText__returns_parameters_for_increase_command()
        {
            var commandParameterHelper = MockCommandParameterHelper();

            var expectedHour = 1;

            var actualObj = commandParameterHelper.GetIncreaseTimeCommandParameter("increase_time 1");

            Assert.AreEqual(expectedHour, actualObj.Hour);
        }


        [Test]
        public void
            CommandParameterValidator_Validate_parameters_arraylength__throws_exception_if_parameters_array_is_null()
        {
            var commandParameterValidator = new CommandParameterValidator();

            Assert.Throws<ECommerceExceptions.CommandIsNotValidException>(() =>
                commandParameterValidator.Validate(null, 1));
        }

        [Test]
        public void
            CommandParameterValidator_Validate_parameters_arraylength__throws_exception_if_parameters_array_length_is_bigger_than_arrayLength_parameter()
        {
            var commandParameterValidator = new CommandParameterValidator();

            Assert.Throws<ECommerceExceptions.CommandIsNotValidException>(() =>
                commandParameterValidator.Validate(new string[] { "", "" }, 3));
        }

        [Test]
        public void
            CommandParameterValidator_Validate_parameters_arraylength__throws_exception_if_parameters_array_length_is_lower_than_arrayLength_parameter()
        {
            var commandParameterValidator = new CommandParameterValidator();

            Assert.Throws<ECommerceExceptions.CommandIsNotValidException>(() =>
                commandParameterValidator.Validate(new string[] { "", "" }, 1));
        }

        [Test]
        public void
            CommandParameterValidator_Validate_parameters_arraylength__does_not_throw_exception_if_parameters_array_length_is_equal_arrayLength_parameter()
        {
            var commandParameterValidator = new CommandParameterValidator();

            Assert.DoesNotThrow(() =>
                commandParameterValidator.Validate(new string[] { "", "" }, 2));
        }

        [Test]
        public void ProductExistanceValidator_Validate_product__throws_exception_if_product_is_not_null()
        {
            var productExistanceValidator = new ProductExistanceValidator(_productReaderMock.Object);

            Assert.Throws<ECommerceExceptions.ProductExistsException>(() =>
                productExistanceValidator.Validate(CreateAProduct("P1", 100, 100)));
        }

        [Test]
        public void ProductExistanceValidator_Validate_product__does_not_throw_exception_if_product_is_not_null()
        {
            var productExistanceValidator = new ProductExistanceValidator(_productReaderMock.Object);

            Assert.DoesNotThrow(() =>
                productExistanceValidator.Validate(product: null));
        }

        [Test]
        public void ProductExistanceValidator_Validate_productCode__reads_product_by_code_and_calls_validate_method()
        {
            CreateAProduct("P1", 100, 100);

            var productExistanceValidator = new ProductExistanceValidator(_productReaderMock.Object);

            Assert.DoesNotThrow(() =>
                productExistanceValidator.Validate("P1"));
        }

        [Test]
        public void ProductDoesNotExistValidator_Validate_product__throws_exception_if_product_is_null()
        {
            var productExistanceValidator = new ProductDoesNotExistValidator(_productReaderMock.Object);

            Assert.Throws<ECommerceExceptions.ProductDoesNotExistException>(() =>
                productExistanceValidator.Validate(null));
        }

        [Test]
        public void ProductDoesNotExistValidator_Validate_product__does_not_throw_exception_if_product_is_not_null()
        {
            var product = CreateAProduct("P1", 100, 100);

            var productExistanceValidator = new ProductDoesNotExistValidator(_productReaderMock.Object);

            Assert.DoesNotThrow(() =>
                productExistanceValidator.Validate(product));
        }

        [Test]
        public void
            CampaignExistanceForProductValidator_Validate_product__throws_exception_if_any_active_campaign_is_exist_for_given_product()
        {
            var product = CreateAProduct("p1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            var campaignExistanceForProductValidator = new CampaignExistanceForProductValidator(_campaignReader.Object);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(campaign);

            Assert.Throws<ECommerceExceptions.CampaignAlreadyExistsForProductException>(() =>
                campaignExistanceForProductValidator.Validate(product));
        }

        [Test]
        public void
            CampaignExistanceForProductValidator_Validate_product__does_not_throw_exception_if_an_active_campaign_is_not_exist_for_given_product()
        {
            var product = CreateAProduct("p1", 100, 100);

            var campaignExistanceForProductValidator = new CampaignExistanceForProductValidator(_campaignReader.Object);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(default(Campaign));

            Assert.DoesNotThrow(() =>
                campaignExistanceForProductValidator.Validate(product));
        }

        [Test]
        public void StockAmountValidator_Validate_stock_quantity__throws_exception_if_stock_value_falls_below_zero()
        {
            var stockAmountValidator = new StockAmountValidator();

            Assert.Throws<ECommerceExceptions.InsufficentStockAmountException>(() =>
                stockAmountValidator.Validate(100, 1000));
        }

        [Test]
        public void StockAmountValidator_Validate_stock_quantity__does_not_throw_exception_if_stock_value_is_enough_for_quantity()
        {
            var stockAmountValidator = new StockAmountValidator();

            Assert.DoesNotThrow(() =>
                stockAmountValidator.Validate(100, 1));
        }

        [Test]
        public void PriceManipulationEvent_ManipulateAllCampaigns__calls_manipulate_method_for_all_active_campaigns()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            _campaignReader.Setup(cr => cr.List()).Returns(new List<Campaign>() { campaign });

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);

            Assert.DoesNotThrow(() => priceManipulationEvent.ManipulateAllCampaigns());
        }

        [Test]
        public void PriceManipulationEvent_ManipulateIfCampaignExists_product__calls_manipulate_method_for_given_product()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 5, 100);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(campaign);

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);

            Assert.DoesNotThrow(() => priceManipulationEvent.ManipulateIfCampaignExists(product));
        }

        [Test]
        public void PriceManipulationEvent_Manipulate_campaign__calculates_product_manipulation_value()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 20, 1000);

            var priceManipulationEvent = new PriceManipulationEvent(_timerMock.Object, _campaignReader.Object);
            priceManipulationEvent.Manipulate(campaign);

            var actualManipulationValue = campaign.Product.Price + campaign.Product.PriceManupulation;
            var expectedManipulation = 90;

            Assert.AreEqual(expectedManipulation, actualManipulationValue);
        }

        [Test]
        public void
            CampaignStatusUpdatorAfterHourTickingEvent_UpdateCampaignStatus__reads_all_active_campaigns_and_set_status_to_end_if_necessary()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 0, 10, 10);

            _campaignReader.Setup(cr => cr.List()).Returns(new List<Campaign>() { campaign });

            var campaignStatusUpdatorAfterHourTickingEvent =
                new CampaignStatusUpdatorAfterHourTickingEvent(_timerMock.Object, _campaignReader.Object,
                    _campaignEnderServiceMock.Object);

            Assert.DoesNotThrow(() => campaignStatusUpdatorAfterHourTickingEvent.UpdateCampaignStatus());
        }

        [Test]
        public void
            CampaignUpdatorAfterStockReducementEvent_UpdateCampaignIfExists_product_quantity__updates_campaign_values_after_stock_operation()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 10, 10, 100);

            var campaignUpdatorAfterStockReducementEvent =
                new CampaignUpdatorAfterStockReducementEvent(_campaignReader.Object, _campaignEnderServiceMock.Object);

            _campaignReader.Setup(cr => cr.Get(product)).Returns(campaign);

            campaignUpdatorAfterStockReducementEvent.UpdateCampaignIfExists(product, 10);

            var expectedTotalSalesValue = 10;
            var expectedTurnover = 1000;
            var expectedAverageItemPrice = 100;

            Assert.AreEqual(expectedTotalSalesValue, campaign.TotalSales);
            Assert.AreEqual(expectedTurnover, campaign.Turnover);
            Assert.AreEqual(expectedAverageItemPrice, campaign.AverageItemPrice);

        }

        [Test]
        public void CampaignEnderService_EndCampaign__updates_campaign_status_as_ended_and_reset_price_manipulation()
        {
            var product = CreateAProduct("P1", 100, 100);
            var campaign = CreateACampaign(product, "C1", 100, 10, 100);

            product.PriceManupulation = 1000;

            var campaignEnderService = new CampaignEnderService();

            campaignEnderService.EndCampaign(campaign);

            var expectedManipulationValue = 0;
            var expectedStatus = CampaignStatus.Ended;

            Assert.AreEqual(expectedManipulationValue, product.PriceManupulation);
            Assert.AreEqual(expectedStatus, campaign.Status);
        }

        [Test]
        public void StockAmountReduceService_ReduceStock_product_quantity__reduces_stock_value()
        {
            var product = CreateAProduct("P1", 100, 100);

            var stockAmountReduceService = new StockAmountReduceService(_priceManipulationEventMock.Object,
                _campaignUpdatorAfterStockReducementEventMock.Object);

            stockAmountReduceService.ReduceStock(product, 10);

            var expectedStock = 90;

            Assert.AreEqual(expectedStock, product.Stock);

        }

        [Test]
        public void CommandCreator_GetCommand_commandText__throws_if_command_is_not_known()
        {
            var commandCreator = new CommandCreator(_serviceProvider);

            Assert.Throws<ECommerceExceptions.CommandIsNotKnownException>(() =>
                commandCreator.GetCommand("Unnknown command"));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_createCampaignCommand_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("create_campaign C1 P1 10 20 100");

            Assert.AreEqual(command.GetType(), typeof(CreateCampaignCommand));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_getProductInfo_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("get_product_info P1");

            Assert.AreEqual(command.GetType(), typeof(GetProductInfoCommand));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_createOrder_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("create_order P1 3");

            Assert.AreEqual(command.GetType(), typeof(CreateOrderCommand));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_getCampaignCommand_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("get_campaign_info C1");

            Assert.AreEqual(command.GetType(), typeof(GetCampaignInfoCommand));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_increaseTimeCommand_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("increase_time 1");

            Assert.AreEqual(command.GetType(), typeof(IncreaseTimeCommand));
        }

        [Test]
        public void CommandCreator_GetCommand_commandText__returns_createproduct_based_on_given_commandText()
        {
            var commandCreator = new CommandCreator(_serviceProvider);
            var command = commandCreator.GetCommand("create_product P1 100 1000");

            Assert.AreEqual(command.GetType(), typeof(CreateProductCommand));
        }

        [Test]
        public void CommandBroker_StageCommand__inserts_command_to_commandList()
        {
            var commandBroker = new CommandBroker();

            Assert.DoesNotThrow(() => commandBroker.StageCommand(new CreateCampaignCommand(_productReaderMock.Object, _campaignCreatorMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object, _productDoesNotExistValidatorMock.Object)));
        }

        [Test]
        public void CommandBroker_ExecuteCommands__executes_stashedCommands_one_by_one()
        {
            var commandBroker = new CommandBroker();

            Mock<ICommand> mockCommand = new Mock<ICommand>();

            mockCommand.Setup(c => c.Execute()).Returns("OK");

            commandBroker.StageCommand(mockCommand.Object);
            commandBroker.StageCommand(mockCommand.Object);

            var strBuilder = commandBroker.ExecuteCommands();

            var expectedResult = "OK\r\nOK\r\n";

            Assert.AreEqual(expectedResult, strBuilder.ToString());
        }

        [Test]
        public void CreateCampaignCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var createCampaignCommand = new CreateCampaignCommand(_productReaderMock.Object,
                _campaignCreatorMock.Object, _stringifyHelper.Object, _commandParameterHelper.Object,
                _productDoesNotExistValidatorMock.Object);

            Assert.DoesNotThrow(() => createCampaignCommand.GetParameters("create_campaign C1 P1 10 20 100"));
        }

        [Test]
        public void CreateCampaignCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var createCampaignCommand = new CreateCampaignCommand(_productReaderMock.Object,
                _campaignCreatorMock.Object, _stringifyHelper.Object, _commandParameterHelper.Object,
                _productDoesNotExistValidatorMock.Object);

            Assert.DoesNotThrow(() => createCampaignCommand.Execute());
        }

        [Test]
        public void CreateOrderCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var createOrderCommand = new CreateOrderCommand(_orderCreatorMock.Object,
                _productReaderMock.Object, _stringifyHelper.Object, _commandParameterHelper.Object,
                _productDoesNotExistValidatorMock.Object);

            Assert.DoesNotThrow(() => createOrderCommand.GetParameters("create_order P1 3"));
        }

        [Test]
        public void CreateOrderCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var createOrderCommand = new CreateOrderCommand(_orderCreatorMock.Object,
                _productReaderMock.Object, _stringifyHelper.Object, _commandParameterHelper.Object,
                _productDoesNotExistValidatorMock.Object);

            Assert.DoesNotThrow(() => createOrderCommand.Execute());
        }

        [Test]
        public void CreateProductCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var createProductCommand = new CreateProductCommand(_productCreatorMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => createProductCommand.GetParameters("create_product P1 100 1000"));
        }

        [Test]
        public void CreateProductCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var createProductCommand = new CreateProductCommand(_productCreatorMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => createProductCommand.Execute());
        }

        [Test]
        public void GetCampaignInfoCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var getCampaignInfoCommand = new GetCampaignInfoCommand(_campaignReader.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => getCampaignInfoCommand.GetParameters("get_campaign_info C1"));
        }

        [Test]
        public void GetCampaignInfoCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var getCampaignInfoCommand = new GetCampaignInfoCommand(_campaignReader.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => getCampaignInfoCommand.Execute());
        }

        [Test]
        public void GetProductInfoCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var getProductInfoCommand = new GetProductInfoCommand(_productReaderMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => getProductInfoCommand.GetParameters("get_product_info P1"));
        }

        [Test]
        public void GetProductInfoCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var getProductInfoCommand = new GetProductInfoCommand(_productReaderMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object);

            Assert.DoesNotThrow(() => getProductInfoCommand.Execute());
        }

        [Test]
        public void IncreaseTimeCommand_GetParameters__calls_command_parameter_helper_get_does_not_throw_any_exception()
        {
            var increaseTimeCommand = new IncreaseTimeCommand(_timerMock.Object, _campaignReader.Object,
                _stringifyHelper.Object, _priceManipulationEventMock.Object, _commandParameterHelper.Object,
                _campaignStatusUpdatorAfterHourTickingEventMock.Object);

            Assert.DoesNotThrow(() => increaseTimeCommand.GetParameters("increase_time 1"));
        }

        [Test]
        public void IncreaseTimeCommand_Execute__executes_command_does_not_throw_any_exception()
        {
            var increaseTimeCommand = new IncreaseTimeCommand(_timerMock.Object, _campaignReader.Object,
                _stringifyHelper.Object, _priceManipulationEventMock.Object, _commandParameterHelper.Object,
                _campaignStatusUpdatorAfterHourTickingEventMock.Object);

            Assert.DoesNotThrow(() => increaseTimeCommand.Execute());
        }

    }
}
