using System.IO;
using ECommerce.Web.Controllers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ECommerce.UnitTest.IntegrationTest
{
    public class ControllerTest : BaseTest
    {

        [Test]
        public void ScenarioController_Scenario1__runs_whole_business_and_compares_expected_result()
        {
            var controller = _serviceProvider.GetService<ScenarioController>();

            var expected = File.ReadAllText("Scenarios/Scenario1Result.txt");
            var actual = controller.Scenario1();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScenarioController_Scenario2__runs_whole_business_and_compares_expected_result()
        {
            var controller = _serviceProvider.GetService<ScenarioController>();

            var expected = File.ReadAllText("Scenarios/Scenario2Result.txt");
            var actual = controller.Scenario2();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScenarioController_Scenario4__runs_whole_business_and_compares_expected_result()
        {
            var controller = _serviceProvider.GetService<ScenarioController>();

            var expected = File.ReadAllText("Scenarios/Scenario4Result.txt");
            var actual = controller.Scenario4();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScenarioController_Scenario5__runs_whole_business_and_compares_expected_result()
        {
            var controller = _serviceProvider.GetService<ScenarioController>();

            var expected = File.ReadAllText("Scenarios/Scenario5Result.txt");
            var actual = controller.Scenario5();

            Assert.AreEqual(expected, actual);
        }


    }
}
