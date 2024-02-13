using System.Diagnostics;
using System.Security.Claims;
using Application.Products;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Products;
using MVC.Services;

namespace MVC.Controllers;

public class AuthController : BaseController<AuthController>
{

    public AuthController(
                              ILogger<AuthController> logger,
                              IMediator mediator,
                              IMapper mapper
                              ) : base(logger, mediator, mapper) { }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
    {
        var command = _mapper.Map<Application.Users.Create.Command>(user);
        var res = await _mediator.Send(command);
        if (res.IsSuccess)
        {
            LoginUser(res.Value.Username, res.Value.Id, res.Value.Roles.Select(r => r.Name).ToList());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", res.Error);
            return View();
        }
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginViewModel user)
    {
        var command = _mapper.Map<Application.Users.Get.Query>(user);
        var res = await _mediator.Send(command);
        if (res.IsSuccess)
        {
            LoginUser(res.Value.Username, res.Value.Id, res.Value.Roles.Select(r => r.Name).ToList());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", res.Error);
            return View();
        }
    }

    private async void LoginUser(string name, int id, List<string> roles)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
                                      CookieAuthenticationDefaults.AuthenticationScheme,
                                      new ClaimsPrincipal(claimsIdentity),
                                      new AuthenticationProperties
                                      {
                                          IsPersistent = true,
                                          IssuedUtc = DateTimeOffset.UtcNow,
                                          ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                                      });
    }
}
