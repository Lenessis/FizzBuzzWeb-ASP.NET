using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using FizzBuzzWeb.Models;



namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {

        public FizzBuzz FizzBuzz { get; set; }
        public Year yearModel { get; set; }

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data"); // odczyt sesji z nazwy sesji "Data"
            if (Data != null)
                FizzBuzz =
                JsonConvert.DeserializeObject<FizzBuzz>(Data); // konwertowanie na obiekt


            var YearData = HttpContext.Session.GetString("Year");
            if(YearData != null)
            {
                yearModel = JsonConvert.DeserializeObject<Year>(YearData);
            }
        }
    }
}
