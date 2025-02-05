
using MediatR;
using OnlineShopCQRS.Application.Products.Queries.Dto;

namespace OnlineShopCQRS.Application.Products.Queries.GetProducts
{
    public class GetProductQuery : IRequest<List<ProductDto>>
    {
    }
}
