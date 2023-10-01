using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.hour = DateTime.Now.Hour;
            ViewBag.welcome = ViewBag.hour < 17 ? "dzien dobry" : "dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Nowak"},
                new Dane {Name = "Jan", Surname = "Nowak"},
                new Dane {Name = "MAteusz", Surname = "Kowalski"}
            };
            return View(osoby);
        }

        public IActionResult UrodzinyForm()
        {
            return View();
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.welcome = $"Witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";   
            return View(urodziny);
        }
        public IActionResult Calculator(Calculator calc)
        {
            
            if (calc.c == '*')
            {
                calc.wynik = calc.a * calc.b;
            }
            else if (calc.c == '/')
            {
                if (calc.b != 0)
                {
                    calc.wynik = calc.a/calc.b;
                }
                else
                {
                    calc.error = "nie mozna dzielic przez zero";
                }
                
            }
            else if (calc.c == '-')
            {
                calc.wynik = calc.a - calc.b;
            }
            else if (calc.c == '+')
            {
                calc.wynik = calc.a + calc.b;
            }
            else
            {
                calc.error = "Bledny znak";
            }
            return View(calc);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}