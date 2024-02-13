using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;

        public UserRoleRepository(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
        }

        public async Task RemoveAsync(int userId, int roleId)
        {
            var userRole = await _dbContext.UserRoles.FirstOrDefaultAsync(u => u.RoleId == roleId && u.UserId == userId);
            _dbContext.UserRoles.Remove(userRole);
        }
    }
}