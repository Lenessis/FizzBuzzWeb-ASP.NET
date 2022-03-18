using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class Year
    {
        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"), Range(1899, 2022, ErrorMessage = "Oczekiwany rok powinien być z zakresu {1} - {2}.")]
        public int year { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"), StringLength ( 100, ErrorMessage = "Oczekiwana {0} powinna zawierać do {1}  znaków.")] 
        public string name { get; set; }



        public bool ExtraYear()
        {
            if (year % 4 ==0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else 
                    return true;                
            }
            else
                return false;
            
        }

        public bool Gender()
        {
            //true = female
            //false = male
            string a = name.Substring(name.Length - 1, 1);
            if (a == "a")
                return true;
            
            else
                return false;
        }


    }
}
