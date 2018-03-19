using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using opapProject.Models.Services;

namespace opapProject.Controllers
{
    public class MainMenuController : Controller
    {
        private IDrawRepository _repository;

        public MainMenuController(IDrawRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var listOfDraws = _repository.Draws.OrderByDescending(x=>x.DrawNumber).ToList();
            return View(listOfDraws);
        }

        public IActionResult DisplayFrequency()
        {
            var listOfDraws = _repository.Draws.ToList();
            return View(listOfDraws);
        }

        public IActionResult DelayFrequency()
        {
            var listOfDraws = _repository.Draws.OrderByDescending(x => x.DrawNumber).ToList();
            return View(listOfDraws);
        }

        public IActionResult SumOfFiveNums()
        {
            return View();
        }

        public IActionResult CombinationOfThree()
        {
            return View();
        }

        public IActionResult CombinationOfFour()
        {
            return View();
        }

        public IActionResult CombinationOfFive()
        {
            return View();
        }
    }
}