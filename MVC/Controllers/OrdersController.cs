using System.Diagnostics;
using System.Security.Claims;
using Application.Orders;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Orders;
using MVC.Services;

namespace MVC.Controllers;

[Authorize(Roles = "Admin,SuperAdmin")]
public class OrdersController : BaseController<OrdersController>
{

    public OrdersController(
                              ILogger<OrdersController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrderViewModel order)
    {
        var command = _mapper.Map<Application.Orders.Create.Command>(order);
        command.UserId = _userId;
        var res = await _mediator.Send(command);
        if (res.IsSuccess)
        {
            return RedirectToAction("index", "home");
        }
        else
        {
            ModelState.AddModelError("", res.Error);
            return RedirectToAction("index", "home");
        }
    }

    public async Task<IActionResult> IndexAsync()
    {
        var result = await _mediator.Send(new List.Query());
        var orderViewModels = _mapper.Map<List<OrderViewModel>>(result.Value);
        return View(orderViewModels);
    }

    // public IActionResult Create()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public async Task<IActionResult> CreateAsync(CreateOrderViewModel order)
    // {
    //     var command = _mapper.Map<Application.Products.Create.Command>(product);
    //     command.ImageName = ImageService.SaveImageAndGetTheImageName(product.Image);
    //     var res = await _mediator.Send(command);
    //     if (res.IsSuccess)
    //     {
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         ModelState.AddModelError("", res.Error);
    //         return View();
    //     }
    // }

    // public async Task<IActionResult> EditAsync(int id)
    // {
    //     var res = await _mediator.Send(new Application.Products.Get.Query() { Id = id });
    //     var productViewModel = _mapper.Map<EditProductViewModel>(res.Value);
    //     return View(productViewModel);
    // }

    // [HttpPost]
    // public async Task<IActionResult> EditAsync(EditProductViewModel product)
    // {
    //     var command = _mapper.Map<Application.Products.Edit.Command>(product);
    //     if (product.Image != null)
    //     {
    //         command.ImageName = ImageService.SaveImageAndGetTheImageName(product.Image);
    //     }
    //     var res = await _mediator.Send(command);
    //     if (res.IsSuccess)
    //     {
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         ModelState.AddModelError("", res.Error);
    //         return View();
    //     }
    // }

    // public async Task<IActionResult> DeleteAsync(int id)
    // {
    //     var res = await _mediator.Send(new Application.Products.Get.Query() { Id = id });
    //     var productViewModel = _mapper.Map<ProductViewModel>(res.Value);
    //     return View(productViewModel);
    // }

    // public async Task<IActionResult> ConfirmDeleteAsync(int id)
    // {
    //     var res = await _mediator.Send(new Application.Products.Delete.Command() { Id = id });
    //     if (res.IsSuccess)
    //     {
    //         return RedirectToAction("Index");
    //     }
    //     else
    //     {
    //         ModelState.AddModelError("", res.Error);
    //         return View("Delete");
    //     }
    // }
}
