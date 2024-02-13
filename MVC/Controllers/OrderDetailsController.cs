using System.Diagnostics;
using System.Security.Claims;
using Application.OrderDetails;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.OrderDetails;
using MVC.Models.Products;
using MVC.Services;

namespace MVC.Controllers;

[Authorize]
public class OrderDetailsController : BaseController<OrderDetailsController>
{

    public OrderDetailsController(
                              ILogger<OrderDetailsController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    [HttpGet]
    public async Task<IActionResult> IndexAsync(int id)
    {
        var result = await _mediator.Send(new Get.Query() { Id = id });
        var orderDetailViewModel = _mapper.Map<OrderDetailViewModel>(result.Value);
        return View(orderDetailViewModel);
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
