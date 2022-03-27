using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWeb.Models; //używaj models

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {

        

        private readonly ILogger<IndexModel> _logger;
        //wszystkie pola tu doddane musza sie walidowac
        public bool hide = true;
        public bool alert;


        [BindProperty] // żeby wiedzial co ma walidowac - to będzie wysyłane przez posta
        public FizzBuzz FizzBuzz { get; set; } //używanie modelu fizzbuzz

        [BindProperty (SupportsGet = true)]
        public string? Name { get; set; } //name - nazwa str?
        //okre ślić, że moze być pusty, to dobrze jest dodać znak zapytania, żeby strona się nie wywalała od Geta i żeby się ładnie walidowało



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                // jeżeli jest pusty to nadaj mu default wartość
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            
            //zwraca typ danych
            if (ModelState.IsValid) //zle dane
            {
                /* Deklaracja temp Data i podpisanie pod niego wartości*/
                hide = false;
                              
                ViewData["result"] = FizzBuzz.Check();

                switch(ViewData["result"])
                {
                    case "Fizz":
                    case "Buzz":
                    case "FizzBuzz":
                        alert = false;
                        break;
                    default:
                        alert = true;
                        break;
                }

                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzz)); //wpisywanie obiektu na string (json)
               // return RedirectToPage("./SavedInSession"); // przekierowanie

            }

            return Page(); //przekierowanie na str z formularzem

            /*return RedirectToPage("./Privacy"); //przekierowanie na privacy; mozna dawać zwykły adres byle by było http:// lub https://*/
        }

    }
}
