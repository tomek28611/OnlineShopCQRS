
using MediatR;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {

            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new NotFoundException($"Produkt ID {request.Id} not exist.");
            }
            var deletedCount =  await _productRepository.DeleteProductAsync(request.Id);
            if (deletedCount == 0)
            {
                throw new ProductDeletionException($"Failed to remove product ID {request.Id}.");
            }

            return deletedCount;

        }
    }
}
