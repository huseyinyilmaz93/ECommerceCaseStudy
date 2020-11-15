using ECommerce.Web.Models;

namespace ECommerce.Web.Validators.ValidatorInterfaces
{
    public interface IProductExistanceValidator
    {
        void Validate(string productCode);
        void Validate(Product product);
    }
}
