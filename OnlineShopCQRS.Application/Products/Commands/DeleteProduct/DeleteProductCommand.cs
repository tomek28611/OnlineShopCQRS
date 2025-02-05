

using MediatR;

namespace OnlineShopCQRS.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
