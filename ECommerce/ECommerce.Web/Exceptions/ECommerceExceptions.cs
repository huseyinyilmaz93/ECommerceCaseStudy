using System;

namespace ECommerce.Web.Exceptions
{

    public class BaseECommerceException : Exception { }

    public class ECommerceExceptions
    {
        public class ProductExistsException : BaseECommerceException { }
        public class ProductDoesNotExistException : BaseECommerceException { }
        public class CommandIsNotKnownException : BaseECommerceException { public CommandIsNotKnownException(string command) {  } }
        public class InsufficentStockAmountException: BaseECommerceException { }
        public class CampaignAlreadyExistsForProductException : BaseECommerceException { public CampaignAlreadyExistsForProductException(string productCode) { } }
        public class CommandIsNotValidException : BaseECommerceException { }

        public class CampaignNameAlreadyExistsException : BaseECommerceException { }

    }
}
