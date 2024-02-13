using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Products;

namespace MVC.Controllers;

public class HomeController : BaseController<HomeController>
{

    public HomeController(
                              ILogger<HomeController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    public async Task<IActionResult> IndexAsync()
    {
        var result = await _mediator.Send(new Application.Products.List.Query());
        var productViewModels = _mapper.Map<List<ProductViewModel>>(result.Value);
        ViewBag.products = productViewModels;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Test test)
    {
        var result = await _mediator.Send(new Application.Products.List.Query());
        var productViewModels = _mapper.Map<List<ProductViewModel>>(result.Value);
        ViewBag.products = productViewModels;
        return RedirectToAction("index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
