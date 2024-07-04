namespace WebApplication8.Models.Login
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
