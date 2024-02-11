using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        //relations
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}