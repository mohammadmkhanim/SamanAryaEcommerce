using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Products;

public class LoginViewModel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    public string Username { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    public string Password { get; set; }
}
