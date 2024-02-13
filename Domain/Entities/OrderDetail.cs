using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "تاریخ")]
        [Required]
        public DateTime DateTime { get; set; }

        //relations
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public List<Product> Products { get; set; }
    }
}