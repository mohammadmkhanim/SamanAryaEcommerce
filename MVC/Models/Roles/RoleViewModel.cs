using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Roles;

public class RoleViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام")]
    public string Name { get; set; }
}
