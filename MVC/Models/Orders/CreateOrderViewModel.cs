using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Products;

public class CreateOrderViewModel
{
    [Required(ErrorMessage = "محصولات نمی تواند خالی باشد.")]
    public int[] ProductIds { get; set; }
}
