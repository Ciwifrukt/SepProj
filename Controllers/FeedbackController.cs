using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController: Controller
    {

        private readonly IFeedbackRepository _feedbackRepository;

        /*
         Tack vare "Dependency Injection" så kommer detta ske:

            _feedbackRepository = new FeedbackRepository()
        */

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
         Denna metod anropas när användaren skrivit in sina uppgifter i HTML-formuläret
         
         Med svart magi så fylls "feedback" med värden utifrån vad använden skrivit in. Detta kallas "modelbinding"
        */
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {

            /*
                "ModelState" sätts magiskt och innehåller info om hur modelbindingen gick
                Attributen som "Feedback" innehåller (t.ex Required och StringLength) sätter krav på användaren inmatade värden.
                Om något av fälten har felaktigt format så blir "ModelState" sur och "ModelState.IsValid" sätts till "false"
            */

            if (ModelState.IsValid)
            {
                // "feedback" innehåller vettiga värden så vi sparar feedbacken i databasen
                _feedbackRepository.AddFeedback(feedback);

                // Efter att den är sparad så avsluta denna metod och gå till actionmetoden "FeedbackComplete"
                return RedirectToAction("FeedbackComplete");
            }

            /*
              "feedback" har vissa värden som inte är okej (t.ex att meddelandet är större än 5000 tecken) så returnera vyn igen
              Vyn "Index.cshtml" kommer användas och vyn kommer veta att modellbiningen inte gick bra

              Taggarna:
                
              <div asp-validation-summary>
               
              och 
  
              <span asp-validation-for="....">

              ...fylls med info om vad som gick snett
             
             */
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }

    }
}
