﻿

using MediatR;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
         
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new ProductCreationException("Product title cannot be empty.");
            }

            if (request.Price <= 0)
            {
                throw new ProductCreationException("Product price must be greater than zero.");
            }
            var UpdateProductEntity = new ProductEntity()
            {
                Id = request.Id,
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
            return await _productRepository.UpdateProductAsync(request.Id, UpdateProductEntity);
        }
    }
}
