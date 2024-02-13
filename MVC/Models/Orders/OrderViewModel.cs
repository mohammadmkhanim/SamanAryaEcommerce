using System.ComponentModel.DataAnnotations;
using MVC.Models.OrderDetails;
using MVC.Models.Users;

namespace MVC.Models.Orders;

public class OrderViewModel
{
    public int Id { get; set; }

    //relations
    public int UserId { get; set; }
    public UserViewModel User { get; set; }

    public OrderDetailViewModel OrderDetail { get; set; }
}
