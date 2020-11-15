using ECommerce.Web.Models;

namespace ECommerce.Web.Validators.ValidatorInterfaces
{
    public interface IProductDoesNotExistValidator
    {
        void Validate(Product product);
    }
}
