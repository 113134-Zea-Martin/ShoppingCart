using WebApplication8.Dtos;
namespace WebApplication8.Services
{
    public interface ILoginService
    {
        Task<string> ValidateUserAsync(UserLoginDto userLoginDto);
    }
}
