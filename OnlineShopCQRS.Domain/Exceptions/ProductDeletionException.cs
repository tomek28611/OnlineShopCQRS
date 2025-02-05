

namespace OnlineShopCQRS.Domain.Exceptions
{
    public class ProductDeletionException : Exception
    {
        public ProductDeletionException(string message) : base(message) { }
    }
}
