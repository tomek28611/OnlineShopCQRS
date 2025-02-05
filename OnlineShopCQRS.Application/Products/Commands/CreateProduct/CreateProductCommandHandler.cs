
using AutoMapper;
using MediatR;
using OnlineShopCQRS.Application.Products.Queries.Dto;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = new ProductEntity()
            {
                Title = request.Title,
                Description = request.Description,
                FullDesc = request.FullDesc,
                Price = request.Price,
                Discount = request.Discount,
                ImageName = request.ImageName,
                Qty = request.Qty,
                Tags = request.Tags,
                VideoUrl = request.VideoUrl
            };
            var result = await _productRepository.CreateProductAsync(productEntity);
            return _mapper.Map<ProductDto>(result);
          
        }


    }
}
