using WebApplication8.Models;
using WebApplication8.Repositories;

namespace WebApplication8.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductosRepository _productosRepository;

        public ProductoService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }
        public async Task DeleteProductoAsync(Guid Id)
        {
            await _productosRepository.DeleteProductoAsync(Id);
        }

        public async Task<Product> GetProductoByIdAsync(Guid Id)
        {
            return await _productosRepository.GetProductoByIdAsync(Id);
        }

        public async Task<List<Product>> GetProductosAsync()
        {
            return await _productosRepository.GetProductosAsync();
        }

        public async Task<Product> PostProductoAsync(Product producto)
        {
            return await _productosRepository.PostProductoAsync(producto);
        }

        public async Task<Product> PutProductoAsync(Guid Id, Product producto)
        {
            return await _productosRepository.PutProductoAsync(Id, producto);
        }
    }
}
