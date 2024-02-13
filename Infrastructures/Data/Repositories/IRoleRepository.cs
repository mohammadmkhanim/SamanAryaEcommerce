using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructures.Data.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetByNameAsync(string name);
        // Task<List<Product>> GetAllAsync();
        // Task<List<Product>> GetAllAsync(int[] ids);
        Task AddAsync(Role role);
        Task<bool> ExistAny();
        // void Update(Product product);
        // Task DeleteAsync(int id);
    }
}