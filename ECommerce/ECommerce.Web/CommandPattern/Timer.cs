using System;
using ECommerce.Web.CommandPattern.CommandPatternInterfaces;
using ECommerce.Web.Constants;

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
            currentDateTime = new DateTime(ECommerceConstants.DefaultYear, ECommerceConstants.DefaultMonth,
                ECommerceConstants.DefaultDay, ECommerceConstants.DefaultHour, ECommerceConstants.DefaultMinute,
                ECommerceConstants.DefaultSecond);
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
