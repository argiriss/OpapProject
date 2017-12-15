using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpapProject.Controllers
{
    public class NumberController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Frequency()
        {
            return View();
        }
        public IActionResult Delay()
        {
            return View();
        }
    }
}