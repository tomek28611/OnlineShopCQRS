using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopCQRS.Domain.Exceptions
{
    public class ProductDeletionException : Exception
    {
        public ProductDeletionException(string message) : base(message) { }
    }
}
