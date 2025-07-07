using FinanceFlow.API.Models;

namespace FinanceFlow.API.Services
{
    public interface IAuthService
    {
        Task<string> Register(User user, string password);
        Task<string> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
