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
        public List<Year> list = new List<Year>();

        

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

                //list.Add(year);

                if (HttpContext.Session.GetString("YearList") == null)
                {
                    list.Add(year);
                    HttpContext.Session.SetString("YearList", JsonConvert.SerializeObject(list));
                }
                    
                else
                {
                    var sessionList = HttpContext.Session.GetString("YearList");
                    list = JsonConvert.DeserializeObject<List<Year>>(sessionList);
                    list.Add(year);
                    HttpContext.Session.SetString("YearList", JsonConvert.SerializeObject(list));
                }
                    
            }

            return Page();
        }
    }
}
