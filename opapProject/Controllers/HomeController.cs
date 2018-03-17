using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using opapProject.Models;
using opapProject.Services;
using opapProject.Services.DrawDataObj;

namespace opapProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebApiFetch _webApiFetch;

        public HomeController(IWebApiFetch webApiFetch)
        {
            _webApiFetch = webApiFetch;
        }

        public async Task<IActionResult> Index()
        {
            var sendDraws = await _webApiFetch.WebApiFetchAsync("http://applications.opap.gr/DrawsRestServices/joker/last.json");
            DrawData draws = JsonConvert.DeserializeObject<DrawData>(sendDraws);

            return View(draws);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
