namespace ECommerce.Web.Validators.ValidatorInterfaces
{
    public interface IStockAmountValidator
    {
        public void Validate(decimal stock, decimal quantity);
    }
}
