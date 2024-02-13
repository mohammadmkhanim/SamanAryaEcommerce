using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.OrderDetails;
using Application.Dtos.Users;

namespace Application.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }

        //relations
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public OrderDetailDto OrderDetail { get; set; }
    }
}