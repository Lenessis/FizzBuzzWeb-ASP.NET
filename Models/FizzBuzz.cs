using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required (ErrorMessage = "Pole jest obowiązkowe") , Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")] //zwracanie komunikatów

        public int? number { get; set; }

        public bool IsDividableInto3()
        {
            if (number % 3 == 0)
                return true;
            
            else
                return false;
        }

        public bool IsDividableInto5() //  nazwy lepiej żeby dotycczyły tego co zwraca w tym wypadku buzz
        {
            if (number % 5 == 0)
                return true;

            else
                return false;
        }

        public string Check()
        {
            string x="";
            if(IsDividableInto3())
            {
                x = "Fizz";
                if(IsDividableInto5())
                    x += "Buzz";

            }
            else if(IsDividableInto5())
                x = "Buzz";

            else
            {
                x = "Liczba " + number + " nie spełnia kryteriów";
            }
            return x;
        }


    }
}
