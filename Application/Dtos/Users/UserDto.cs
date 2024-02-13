using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Roles;
using Domain.Entities;

namespace Application.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        // public string Password { get; set; }

        //relations
        public List<RoleDto> Roles { get; set; }
    }
}