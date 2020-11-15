using System;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Helper.HelperInterfaces;

namespace ECommerce.Web.Helper
{
    public class IncreaseTimeCommandStringifier : IIncreaseTimeCommandStringifier
    {
        private readonly ITimer _timer;
        public IncreaseTimeCommandStringifier(ITimer timer)
        {
            _timer = timer;
        }
        public string Stringify()
        {
            return string.Format("Time is {0}", _timer.GetCurrentDateTime().ToString("HH:mm"));
        }
    }
}
