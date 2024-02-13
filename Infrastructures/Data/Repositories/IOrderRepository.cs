using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructures.Data.Repositories
{
    public interface IOrderRepository
    {
        // Task<Product> GetByIdAsync(int id);
        // Task<List<Product>> GetAllAsync();
        // Task<List<Product>> GetAllAsync(int[] ids);
        Task AddAsync(Order order);
        // void Update(Product product);
        // Task DeleteAsync(int id);
    }
}