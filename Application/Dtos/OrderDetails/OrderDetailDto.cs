using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Orders;
using Application.Dtos.Products;

namespace Application.Dtos.OrderDetails
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public List<ProductDto> Products { get; set; }

        //relations
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}