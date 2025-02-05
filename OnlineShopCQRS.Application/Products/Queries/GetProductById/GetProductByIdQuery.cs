
using MediatR;
using OnlineShopCQRS.Application.Products.Queries.Dto;

namespace OnlineShopCQRS.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}
