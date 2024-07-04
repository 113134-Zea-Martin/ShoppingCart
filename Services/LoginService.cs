using WebApplication8.Dtos;
using WebApplication8.Repositories;

namespace WebApplication8.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<string> ValidateUserAsync(UserLoginDto userLoginDto)
        {
            return await _loginRepository.ValidateUserAsync(userLoginDto.Email, userLoginDto.PasswordHash);
        }
    }
}
