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
            var drawList = _context.Klirosis.ToList();
            return View(drawList);
        }


        public IActionResult LastTen()
        {
            var drawList = _context.Klirosis.ToList();
            return View(drawList);
        }
    }
}