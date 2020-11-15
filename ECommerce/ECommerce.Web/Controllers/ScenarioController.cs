using ECommerce.Web.Constants;
using ECommerce.Web.Helpers.HelperInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ScenarioController : ControllerBase
    {
        public readonly IReader _reader;
        public readonly ICommandExecuter _commandExecuter;

        public ScenarioController(IReader reader, ICommandExecuter commandExecuter)
        {
            _reader = reader;
            _commandExecuter = commandExecuter;
        }

        [HttpGet]
        public string Scenario1()
        {
            return _commandExecuter.Execute(_reader.Read(ECommerceConstants.Scenario1));
        }

        [HttpGet]
        public string Scenario2()
        {
            return _commandExecuter.Execute(_reader.Read(ECommerceConstants.Scenario2));

        }

        [HttpGet]
        public string Scenario4()
        {
            return _commandExecuter.Execute(_reader.Read(ECommerceConstants.Scenario4));

        }

        [HttpGet]
        public string Scenario5()
        {
            return _commandExecuter.Execute(_reader.Read(ECommerceConstants.Scenario5));
        }
    }
}
