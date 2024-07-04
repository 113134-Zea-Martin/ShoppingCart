using WebApplication8.Dtos;

namespace WebApplication8.Repositories
{
    public interface ILoginRepository
    {
        Task<string> ValidateUserAsync(string username, string password);
    }
}