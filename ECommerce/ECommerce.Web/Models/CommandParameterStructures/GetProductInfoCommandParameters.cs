namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct GetProductInfoCommandParameters
    {
        public string ProductCode { get; set; }

        public GetProductInfoCommandParameters(string productCode)
        {
            ProductCode = productCode;
        }
    }
}
