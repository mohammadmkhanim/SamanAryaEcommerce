using System.ComponentModel.DataAnnotations;
using MVC.Models.Products;

namespace MVC.Models.OrderDetails;

public class OrderDetailViewModel
{
    public int Id { get; set; }

    [Display(Name = "تاریخ")]
    public DateTime DateTime { get; set; }

    //relations
    public List<ProductViewModel> Products { get; set; }
}
