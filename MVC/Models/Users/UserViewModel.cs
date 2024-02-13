using System.ComponentModel.DataAnnotations;
using MVC.Models.Roles;

namespace MVC.Models.Users;

public class UserViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام کاربری")]
    public string Username { get; set; }

    //relations
    public List<RoleViewModel> Roles { get; set; }
}
