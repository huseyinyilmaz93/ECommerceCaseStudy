using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Web.Repositories;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class ReaderTests : BaseTest
    {
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

    }
}
