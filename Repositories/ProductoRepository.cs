using Microsoft.EntityFrameworkCore;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Repositories
{
    public class ProductoRepository : IProductosRepository
    {
        private readonly ShoppingContext _shoppingContext;

        public ProductoRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        public async Task DeleteProductoAsync(Guid Id)
        {
            var producto = await _shoppingContext.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (producto != null)
            {
                _shoppingContext.Products.Remove(producto);
                await _shoppingContext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductoByIdAsync(Guid id)
        {
            return await _shoppingContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductosAsync()
        {
            return await _shoppingContext.Products.ToListAsync();
        }

        public async Task<Product> PostProductoAsync(Product producto)
        {
            await _shoppingContext.Products.AddAsync(producto);
            await _shoppingContext.SaveChangesAsync();

            return producto;
        }

        public async Task<Product> PutProductoAsync(Guid Id, Product producto)
        {
            var productoAEditar = await _shoppingContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (productoAEditar != null)
            {
                productoAEditar.Name = producto.Name;
                productoAEditar.Description = producto.Description;
                productoAEditar.Price = producto.Price;
                await _shoppingContext.SaveChangesAsync();
            }

            return producto;
        }
    }
}
