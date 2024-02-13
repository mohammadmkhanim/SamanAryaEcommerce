using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "قیمت")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "عکس")]
        [Required]
        public string ImageName { get; set; }

        //relations
        public List<OrderDetail> OrderDetails { get; set; }
    }
}