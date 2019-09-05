using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmProj.Models;
using FilmProj.Models.ViewModels;

namespace FilmProj.Controllers
{
    public class HomeController : Controller
    {
    //    private readonly AuthService _auth;

    //    public HomeController(AuthService auth)
    //    {
    //        this._auth = auth;
    //    }
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }

    //    public IActionResult Movies()
    //    {
    //        return View();
    //    }

    //    public IActionResult UserMovies()
    //    {
    //        return View();
    //    }

    //    [HttpGet("AddRoleForUser")]
    //    public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
    //    {

    //        if (!ModelState.IsValid)
    //            return View("Index");

    //        bool userExist = await _auth.UserExist(addrole.Email);

    //        if (!userExist)
    //        {
    //            ModelState.AddModelError("UserDontExist", $"User with email {addrole.Email} doesn't exist");
    //            return View("Index");
    //        }

    //        bool alreadyInRole = await _auth.IsInRoleAsync(addrole.Email, addrole.RoleName);

    //        if (alreadyInRole)
    //        {
    //            ModelState.AddModelError("UserAlreadyInrole", $"{addrole.Email} already belongs to role {addrole.RoleName}");
    //            return View("Index");
    //        }

    //        bool roleExist = await _auth.RoleExistsAsync(addrole.RoleName);

    //        if (!roleExist)
    //            await _auth.CreateRoleAsync(addrole.RoleName); // todo: hantera oväntat fel

    //        await _auth.AddToRoleAsync(addrole.Email, addrole.RoleName);

    //        return View("SuccessAddRole", addrole);

    //    }
    }
}
