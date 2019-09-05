using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    /*
     Syftet med vymodeller är att klumpa ihop information som ska skickas i ett svep till en viss vy

     Normalt sett är en viss vymodell kopplad till precis än vy

     Det är inte ovanligt att ett projekt innehåller en massa vymodeller.

     Det anses fint att använd vymodeller (lite mer cleancode). 
     Ett alternativ är att skippa vymodeller och använda "ViewBag" (alternativt "inject" i vyn)
     Lite smutsigare men det kan vara skönt att slippa alla klasser

    */
    public class HomeViewModel
    {
        public List<Pie> Pies { get; set; }
        public string Title { get; set; }

    }
}
