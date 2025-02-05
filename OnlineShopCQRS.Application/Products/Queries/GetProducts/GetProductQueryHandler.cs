
using AutoMapper;
using MediatR;
using OnlineShopCQRS.Application.Products.Queries.Dto;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Products.Queries.GetProducts
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();
            var productList = _mapper.Map<List<ProductDto>>(products);

            return productList;
        }
    }
}
