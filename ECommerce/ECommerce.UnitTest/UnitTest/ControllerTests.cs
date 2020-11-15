using ECommerce.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace ECommerce.UnitTest.UnitTest
{
    public class ControllerTests : BaseTest
    {
        [Test]
        public void ScenarioContoller_Scenario1__reads_and_calls_execute_method_for_scenario1txt()
        {
            var controller = new ScenarioController(_readerMock.Object, _commandExecuterMock.Object);

            _readerMock.Setup(r => r.Read(It.IsAny<string>())).Returns(new string[] {"", ""});
            _commandExecuterMock.Setup(ce => ce.Execute(It.IsAny<string[]>())).Returns("OK");

            var actual = controller.Scenario1();
            var expected = "OK";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScenarioContoller_Scenario2__reads_and_calls_execute_method_for_scenario1txt()
        {
            var controller = new ScenarioController(_readerMock.Object, _commandExecuterMock.Object);

            _readerMock.Setup(r => r.Read(It.IsAny<string>())).Returns(new string[] { "", "" });
            _commandExecuterMock.Setup(ce => ce.Execute(It.IsAny<string[]>())).Returns("OK");

            var actual = controller.Scenario2();
            var expected = "OK";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ScenarioContoller_Scenario4__reads_and_calls_execute_method_for_scenario1txt()
        {
            var controller = new ScenarioController(_readerMock.Object, _commandExecuterMock.Object);

            _readerMock.Setup(r => r.Read(It.IsAny<string>())).Returns(new string[] { "", "" });
            _commandExecuterMock.Setup(ce => ce.Execute(It.IsAny<string[]>())).Returns("OK");

            var actual = controller.Scenario4();
            var expected = "OK";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ScenarioContoller_Scenario5__reads_and_calls_execute_method_for_scenario1txt()
        {
            var controller = new ScenarioController(_readerMock.Object, _commandExecuterMock.Object);

            _readerMock.Setup(r => r.Read(It.IsAny<string>())).Returns(new string[] { "", "" });
            _commandExecuterMock.Setup(ce => ce.Execute(It.IsAny<string[]>())).Returns("OK");

            var actual = controller.Scenario5();
            var expected = "OK";

            Assert.AreEqual(expected, actual);
        }

    }
}
