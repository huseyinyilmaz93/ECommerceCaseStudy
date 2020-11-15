using ECommerce.Web.Exceptions;
using ECommerce.Web.Models;
using ECommerce.Web.Validators;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class ValidatorTests : BaseTest
    {
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
    }
}
