using System;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;

namespace ECommerce.Web.CommandPattern
{
    public class Timer : ITimer
    {
        private DateTime currentDateTime;
        
        public Timer()
        {
            ResetTime();
        }

        public void ResetTime()
        {
            currentDateTime = new DateTime(2020, 1, 1, 0, 0, 0);
        }

        public DateTime GetCurrentDateTime()
        {
            return currentDateTime;
        }

        public void IncreaseTime(int hour)
        {
            currentDateTime = currentDateTime.AddHours(hour);
        }
    }
}
