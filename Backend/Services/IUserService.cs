using Backend.Models;

namespace Backend.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
        string GenerateJwtToken(User user);
        User RegisterUser(string username, string password);
    }
}
