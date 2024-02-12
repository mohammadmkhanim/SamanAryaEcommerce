using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام")]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    public double Price { get; set; }

    [Display(Name = "عکس")]
    public string ImageName { get; set; }
}
