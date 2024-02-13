using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //relations
        // public List<User> Users { get; set; }
    }
}