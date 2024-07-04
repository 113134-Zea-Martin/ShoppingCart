using WebApplication8.Models.Login;

namespace WebApplication8.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItem { get; set; }
    }
}
