namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct CreateCampaignCommandParameters
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public short Limit { get; set; }
        public int TargetSalesCount { get; set; }

        public CreateCampaignCommandParameters(string name, string productCode, int duration, short limit, int targetSalesCount)
        {
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            Limit = limit;
            TargetSalesCount = targetSalesCount;
        }
    }
}
