namespace ECommerce.Web.Validators.ValidatorInterfaces
{
    public interface ICommandParameterValidator
    {
        public void Validate(string[] parameters, int arrayLenght);
    }
}
