using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Data.Repositories;

namespace Infrastructures.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        Task<int> SaveChangesAsync(); 
    }
}