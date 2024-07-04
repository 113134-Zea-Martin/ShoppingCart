using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Dtos;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lProductos = await _productoService.GetProductosAsync();

            return Ok(lProductos);
        }

        [HttpGet("/{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductoById(Guid id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            return Ok(producto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostProductoAsync([FromBody] ProductoDto productoDto)
        {
            Product producto = new Product()
            {
                Name = productoDto.Name,
                Description = productoDto.Description,
                Price = productoDto.Price,
                CartItems = null
            };
            await _productoService.PostProductoAsync(producto);
            return Ok(producto);
        }

        [HttpPut("/{id}")]
        [Authorize]
        public async Task<IActionResult> PutProductoAsync([FromRoute] Guid id, [FromBody] UpdateProductoDto updateProductoDto)
        {
            Product producto = new Product()
            {
                Name = updateProductoDto.Name,
                Description = updateProductoDto.Description,
                Price = updateProductoDto.Price,
                CartItems = null
            };

            var productoActualizado = await _productoService.PutProductoAsync(id, producto);

            return Ok(productoActualizado);
        }

        [HttpDelete("/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLibroAsync([FromRoute] Guid id)
        {
            await _productoService.DeleteProductoAsync(id);
            return Ok();
        }
    }
}
