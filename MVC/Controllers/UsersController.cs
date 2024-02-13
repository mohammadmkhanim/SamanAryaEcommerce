using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers;

[Authorize(Roles = "Admin,SuperAdmin")]
public class UsersController : BaseController<UsersController>
{
    public UsersController(
                              ILogger<UsersController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    // public async Task<IActionResult> IndexAsync()
    // {
    //     var result = await _mediator.Send(new List.Query());
    //     var productViewModels = _mapper.Map<List<ProductViewModel>>(result.Value);
    //     return View(productViewModels);
    // }

    public IActionResult Create()
    {
        return View();
    }

}
