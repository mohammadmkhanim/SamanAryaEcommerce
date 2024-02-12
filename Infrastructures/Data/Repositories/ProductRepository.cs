using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;

        public ProductRepository(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Entry(product).State = EntityState.Detached;
            return product;
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
        }
    }
}