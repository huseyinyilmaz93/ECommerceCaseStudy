namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct GetCampaignInfoCommandParameters
    {
        public string Name { get; set; }

        public GetCampaignInfoCommandParameters(string name)
        {
            Name = name;
        }
    }
}
