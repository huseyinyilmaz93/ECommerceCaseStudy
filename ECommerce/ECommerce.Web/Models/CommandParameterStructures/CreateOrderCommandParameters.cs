namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct CreateOrderCommandParameters
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public CreateOrderCommandParameters(string productCode, int quantity)
        {
            ProductCode = productCode;
            Quantity = quantity;
        }
    }
}
