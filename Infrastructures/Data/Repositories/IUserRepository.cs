using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructures.Data.Repositories
{
    public interface IUserRepository
    {
        // Task<Product> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        // Task<List<Product>> GetAllAsync(int[] ids);
        Task AddAsync(User user);
        Task<bool> ExistUsernameAsync(string username);
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);
        // void Update(Product product);
        // Task DeleteAsync(int id);
    }
}