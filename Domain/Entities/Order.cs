using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        //relations
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}