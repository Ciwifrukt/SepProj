using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        /*
         Tack vare "Dependency Injection" så kommer detta ske:

            _pieRepository = new PieRepository()
        */

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel()
            {
                Pies = pies.ToList(),
                Title = "Welcome to Bethany's Pie Shop"
            };

            /*
             HomeViewModel är en "vymodell" (en klass) som innehåller både pajerna och en titel
             Denna vymodell skickas till vyn

             Den vyn som använd är "Views/Home/Index.cshtml"

             Vyn måste förvänta sig en vymodell av sorten HomeViewModel, annars kommer den protestera vilt
             
             */
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            /*
             Denna (och många andra) metoder returnerar typen "IActionResult".

             "IActionResult" är snällt och tolererar att flera olika saker returneras. 

              Både en vy och NotFound implementerar "IActionResult". Så båda är okej att returneras. 
             
             */
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

    }
}
