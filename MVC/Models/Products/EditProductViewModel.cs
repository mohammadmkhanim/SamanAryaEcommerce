using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Products;

public class EditProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} نمی تواند خالی باشد.")]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} نمی تواند خالی باشد.")]
    public double Price { get; set; }

    [Display(Name = "عکس")]
    public IFormFile? Image { get; set; }
}
