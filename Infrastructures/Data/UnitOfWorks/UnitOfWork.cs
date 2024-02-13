using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Context;
using Infrastructures.Data.Repositories;

namespace Infrastructures.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SamanAryaEcommerceDbContext _dbContext;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;
        private OrderDetailsRepository _orderDetailsRepository;
        private IUserRoleRepository _userRoleRepository;
        
        public UnitOfWork(SamanAryaEcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRoleRepository UserRoleRepository
        {
            get { return _userRoleRepository ??= new UserRoleRepository(_dbContext); }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository ??= new ProductRepository(_dbContext); }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get { return _orderDetailsRepository ??= new OrderDetailsRepository(_dbContext); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_dbContext); }
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(_dbContext); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ??= new RoleRepository(_dbContext); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}