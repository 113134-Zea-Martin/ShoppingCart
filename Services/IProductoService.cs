using WebApplication8.Models;

namespace WebApplication8.Services
{
    public interface IProductoService
    {
        Task<List<Product>> GetProductosAsync();

        Task<Product> GetProductoByIdAsync(Guid Id);

        Task<Product> PostProductoAsync(Product producto);

        Task<Product> PutProductoAsync(Guid Id, Product producto);

        Task DeleteProductoAsync(Guid Id);
    }
}
