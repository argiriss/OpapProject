using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpapProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult FullRandom()
        {
            return View();
        }
        public IActionResult FiveWithoutJoker()
        {
            return View();
        }
        public IActionResult FourWithoutJoker()
        {
            return View();
        }
        public IActionResult ThreeWithoutJoker()
        {
            return View();
        }
        public IActionResult TwoWithoutJoker()
        {
            return View();
        }
    }
}