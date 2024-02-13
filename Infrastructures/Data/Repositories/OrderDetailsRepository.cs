using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;

        public OrderDetailsRepository(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await _dbContext.OrderDetails.Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}