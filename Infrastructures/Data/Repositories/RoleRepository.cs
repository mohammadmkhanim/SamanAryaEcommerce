using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;

        public RoleRepository(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
        }

        public async Task<bool> ExistAny()
        {
            return await _dbContext.Roles.AnyAsync();
        }

        // public async Task DeleteAsync(int id)
        // {
        //     var product = await GetByIdAsync(id);
        //     if (product != null)
        //     {
        //         _dbContext.Products.Remove(product);
        //     }
        // }

        // public async Task<List<Product>> GetAllAsync()
        // {
        //     return await _dbContext.Products.ToListAsync();
        // }

        // public async Task<List<Product>> GetAllAsync(int[] ids)
        // {
        //     var products = await _dbContext.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        //     return products;
        // }

        // public async Task<Product> GetByIdAsync(int id)
        // {
        //     var product = await _dbContext.Products.FindAsync(id);
        //     _dbContext.Entry(product).State = EntityState.Detached;
        //     return product;
        // }

        // public void Update(Product product)
        // {
        //     _dbContext.Products.Update(product);
        // }
    }
}