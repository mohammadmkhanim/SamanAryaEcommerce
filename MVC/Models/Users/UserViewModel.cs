using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Users;

public class UserViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام کاربری")]
    public string Username { get; set; }
}
