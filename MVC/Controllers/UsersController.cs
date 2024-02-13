using System.Diagnostics;
using System.Security.Claims;
using Application.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Users;
using MVC.Services;

namespace MVC.Controllers;

[Authorize(Roles = "SuperAdmin")]
public class UsersController : BaseController<UsersController>
{
    public UsersController(
                              ILogger<UsersController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    public async Task<IActionResult> IndexAsync()
    {
        var result = await _mediator.Send(new List.Query());
        var userViewModels = _mapper.Map<List<UserViewModel>>(result.Value);
        return View(userViewModels);
    }

    public async Task<IActionResult> RemoveAdminAsync(int id)
    {
        await _mediator.Send(new RemoveRole.Command() { UserId = id, Name = "Admin" });
        return RedirectToAction("index");
    }

    public async Task<IActionResult> AddAdminAsync(int id)
    {
        await _mediator.Send(new AddRole.Command() { UserId = id, Name = "Admin" });
        return RedirectToAction("index");
    }

}
