using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;

        public OrderRepository(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.Include(o => o.User).Include(o => o.OrderDetail).ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
        }
    }
}