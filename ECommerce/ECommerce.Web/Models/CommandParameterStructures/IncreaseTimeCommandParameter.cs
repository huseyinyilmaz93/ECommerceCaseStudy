namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct IncreaseTimeCommandParameter
    {
        public int Hour { get; set; }
        public IncreaseTimeCommandParameter(int hour)
        {
            Hour = hour;
        }
    }
}
