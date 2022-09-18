using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReturnOfTheCoder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnOfTheCoder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person person)
        {
            if(isValid(person))
            {
                int a = 1;
                int b = 1;
                int total = 0;
                double totalPersonA = 0;
                double totalPersonB = 0;
                double Average = 0;

                int nPersonA = person.YearOfDeath1 - person.AgeOfDeath1;
                int nPersonB = person.YearOfDeath2 - person.AgeOfDeath2;
                totalPersonA = JumlahDeret(a, b, nPersonA, total);
                totalPersonB = JumlahDeret(a, b, nPersonB, total);
                Average = (totalPersonA + totalPersonB) / 2;
                person.Result = Average;
                ViewData["Result"] = Average;
            }
            else
            {
                ViewData["Result"] = -1;
            }
            return View();
        }

        static long JumlahDeret(int a, int b, int n, int Sum)
        {
            if (n == 0) 
                return Sum;

            return JumlahDeret(b, a + b, n - 1, Sum + a);
        }
        static bool isValid(Person person)
        {
            if (person.AgeOfDeath1 > 0 && person.AgeOfDeath2 > 0 && person.YearOfDeath1 > 0 && person.YearOfDeath2 > 0)
            {
                if(((person.YearOfDeath1 - person.AgeOfDeath1)> 0) || ((person.YearOfDeath2 - person.AgeOfDeath2) > 0))
                    return true;
            }
            return false;
        }
    }
}
