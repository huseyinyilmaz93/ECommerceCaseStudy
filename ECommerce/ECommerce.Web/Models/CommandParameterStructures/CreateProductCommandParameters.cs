namespace ECommerce.Web.Models.CommandParameterStructures
{
    public struct CreateProductCommandParameters
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommandParameters(string productCode, decimal price, int stock)
        {
            ProductCode = productCode;
            Price = price;
            Stock = stock;
        }
    }
}
