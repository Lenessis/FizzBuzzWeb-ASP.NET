using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexYearModel : PageModel
    {
        public bool extra, gender;

        public bool hide = true;

        [BindProperty]
        public Year year { get; set; }

        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            
            if(ModelState.IsValid)
            {
                ViewData["extraY"] = year.year;
                ViewData["user"] = year.name;
                extra = year.ExtraYear();
                gender = year.Gender();
                hide = false;


                HttpContext.Session.SetString("Year", JsonConvert.SerializeObject(year));

            }

            return Page();
        }
    }
}
