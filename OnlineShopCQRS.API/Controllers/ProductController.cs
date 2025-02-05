
using Microsoft.AspNetCore.Mvc;
using OnlineShopCQRS.Application.Products.Commands.CreateProduct;
using OnlineShopCQRS.Application.Products.Commands.DeleteProduct;
using OnlineShopCQRS.Application.Products.Commands.UpdateProduct;
using OnlineShopCQRS.Application.Products.Queries.GetProductById;
using OnlineShopCQRS.Application.Products.Queries.GetProducts;

namespace OnlineShopCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await Mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await Mediator.Send(new GetProductByIdQuery { ProductId = id });
            return product == null ? NotFound($"Product with ID {id} not found") : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var createProduct = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = createProduct.Id }, createProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
        {
            command.Id = id; 
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await Mediator.Send(new DeleteProductCommand { Id = id });
            return result == 0 ? NotFound() : NoContent(); 
        }

    }
}
