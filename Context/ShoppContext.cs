using Microsoft.EntityFrameworkCore;
using WebApplication8.Models.Login;
using WebApplication8.Models;

namespace WebApplication8.Context
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Carts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            // Configuración de Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
            .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            // Configuración de Cart
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            // Configuración de CartItem
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItem)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId);
        }
    }
}
