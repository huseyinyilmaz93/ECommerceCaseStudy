using System;

namespace ECommerce.Web.CommandPattern.CommandPatternInterfaces
{
    public interface ITimer
    {
        void ResetTime();
        void IncreaseTime(int hour);
        DateTime GetCurrentDateTime();
    }
}
