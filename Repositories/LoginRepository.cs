using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication8.Context;

namespace WebApplication8.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ShoppingContext _shoppingContext;

        public LoginRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        public async Task<string> ValidateUserAsync(string username, string password)
        {
            var user = await _shoppingContext.Users.FirstOrDefaultAsync(x =>
                        x.Email == username &&
                        x.PasswordHash == password);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            // encontré el usuario por ende genero jwt token
            var tokenDescription = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("asdasdasdasdasdsadasdXCXCweqeqweqweewqe")
                    ),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescription);

            return token;
        }
    }
}
