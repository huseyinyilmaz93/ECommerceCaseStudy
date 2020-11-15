namespace ECommerce.Web.Constants
{
    public class ECommerceConstants
    {
        public const char CommandSplitCharacter = ' ';

        public const string Scenario1 = "Scenarios/Scenario1.txt";
        public const string Scenario2 = "Scenarios/Scenario2.txt";
        public const string Scenario4 = "Scenarios/Scenario4.txt";
        public const string Scenario5 = "Scenarios/Scenario5.txt";

        public const decimal _100 = 100;

        public const decimal DiscountLimitInitialUsageRate = 0.5m;
        public const decimal SellingAndCampaignProgressTradeOffRate = 0.5m;

        public const int CreateCampaignCommandParameterCount = 6;
        public const int CreateOrderCommandParameterCount = 3;
        public const int CreateProductCommandParameterCount = 4;
        public const int CampaignInfoCommandParameterCount = 2;
        public const int ProductInfoCommandParameterCount = 2;
        public const int IncreaseTimeCommandParameterCount = 2;


        public const int DefaultYear = 2020;
        public const int DefaultMonth = 1;
        public const int DefaultDay = 1;
        public const int DefaultHour = 0;
        public const int DefaultMinute = 0;
        public const int DefaultSecond = 0;

        public const decimal DefaultPriceManipulationValue = 0;

        public const string CreateCampaignCommandString = "create_campaign";
        public const string CreateOrderCommandString = "create_order";
        public const string CreateProductCommandString = "create_product";
        public const string CampaignInfoCommandString = "get_campaign_info";
        public const string ProductInfoCommandString = "get_product_info";
        public const string IncreaseTimeCommandString = "increase_time";

    }
}
