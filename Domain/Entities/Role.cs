using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required]
        public string Name { get; set; }

        //relations
        public List<User> Users { get; set; }
    }
}