using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required]
        public string Password { get; set; }

        //relations
        public List<Role> Roles { get; set; }
    }
}