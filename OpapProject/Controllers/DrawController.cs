using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpapProject.Models;

namespace OpapProject.Controllers
{
    public class DrawController : Controller
    {
        private readonly DrawContext _context;

        public DrawController(DrawContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var DrawList = _context.Klirosis.ToList();
            return View(DrawList);
        }


        public IActionResult LastTen()
        {
            return View();
        }
    }
}