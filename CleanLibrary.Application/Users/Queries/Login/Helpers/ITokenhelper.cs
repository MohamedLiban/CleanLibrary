using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Users.Login.Helpers
{
    public interface ITokenHelper
    {
        string GenerateToken(User user);
    }
}
