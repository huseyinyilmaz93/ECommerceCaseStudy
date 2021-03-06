﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using ECommerce.Web.CommandPattern;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Constants;
using ECommerce.Web.Exceptions;
using ECommerce.Web.FactoryMethod;
using ECommerce.Web.Helpers;
using ECommerce.Web.Models;
using Moq;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class CommandTests : BaseTest
    {
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
            var commandBroker = new CommandBroker(_timerMock.Object, _orderHolderMock.Object, _productHolderMock.Object,
                _campaignHolderMock.Object);

            Assert.DoesNotThrow(() => commandBroker.StageCommand(new CreateCampaignCommand(_productReaderMock.Object, _campaignCreatorMock.Object,
                _stringifyHelper.Object, _commandParameterHelper.Object, _productDoesNotExistValidatorMock.Object)));
        }

        [Test]
        public void CommandBroker_ExecuteCommands__executes_stashedCommands_one_by_one()
        {
            var commandBroker = new CommandBroker(_timerMock.Object, _orderHolderMock.Object, _productHolderMock.Object,
                _campaignHolderMock.Object);

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

        [Test]
        public void CommandBroker_DeleteAllRecors__deletes_all_order_product_campaign_records()
        {
            var commandBroker = new CommandBroker(_timerMock.Object, _orderHolderMock.Object, _productHolderMock.Object,
                _campaignHolderMock.Object);

            var product = CreateAProduct("P1", 100, 100);
            CreateAnOrder(product, 10);
            CreateACampaign(product, "C1", 10, 20, 100);

            _campaignHolderMock.Setup(ch => ch.CampaignList).Returns(new List<Campaign>());
            _orderHolderMock.Setup(ch => ch.OrderList).Returns(new List<Order>());
            _productHolderMock.Setup(ch => ch.ProductList).Returns(new List<Product>());

            commandBroker.DeleteAllRecords();

            Assert.AreEqual(_campaignHolderMock.Object.CampaignList.Count, 0);
            Assert.AreEqual(_orderHolderMock.Object.OrderList.Count, 0);
            Assert.AreEqual(_productHolderMock.Object.ProductList.Count, 0);
        }

        [Test]
        public void
            CommandExecuter_Execute_commandTexts__stages_all_commands_one_by_one_executes_and_deletes_all_records()
        {
            var commandExecuter = new CommandExecuter(_commandCreatorMock.Object, _commandBrokerMock.Object);

            _commandCreatorMock.Setup(cc => cc.GetCommand(It.IsAny<string>())).Returns(
                new CreateCampaignCommand(_productReaderMock.Object, _campaignCreatorMock.Object,
                    _stringifyHelper.Object, _commandParameterHelper.Object, _productDoesNotExistValidatorMock.Object));

            _commandBrokerMock.Setup(cb => cb.ExecuteCommands()).Returns(new StringBuilder("OK"));

            var expected = "OK";
            var actual = commandExecuter.Execute(new string[] {""}).ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FileReader_Read_accessor__reads_file_from_given_file_location()
        {
            var fileReader = new FileReader();
            var actual = fileReader.Read(ECommerceConstants.Scenario1);
            var expected = File.ReadAllLines(ECommerceConstants.Scenario1);

            Assert.AreEqual(expected, actual);
        }

    }
}
