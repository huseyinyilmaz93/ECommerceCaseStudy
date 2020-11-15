using ECommerce.Web.Exceptions;
using ECommerce.Web.Validators.ValidatorInterfaces;

namespace ECommerce.Web.Validators
{
    public class CommandParameterValidator : ICommandParameterValidator
    {
        public void Validate(string[] parameters, int arrayLenght)
        {
            if (parameters == null || parameters.Length != arrayLenght)
            {
                throw new ECommerceExceptions.CommandIsNotValidException();
            }
        }
    }
}
