

namespace OnlineShopCQRS.Domain.Exceptions
{
    public class ProductCreationException : Exception
    {
        public ProductCreationException(string message) : base(message) { }
    }
}

