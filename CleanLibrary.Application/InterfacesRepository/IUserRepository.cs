using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
        
    }
}
