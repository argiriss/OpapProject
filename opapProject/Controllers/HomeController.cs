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
using opapProject.Models.Services;
using System.Text.RegularExpressions;

namespace opapProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebApiFetch _webApiFetch;
        private IDrawRepository _drawRepository;

        public HomeController(IWebApiFetch webApiFetch, IDrawRepository drawRepository)
        {
            _webApiFetch = webApiFetch;
            _drawRepository = drawRepository;
        }

        public async Task<IActionResult> Index()
        {
            DrawData draws = await ApiOpapFetch();
            var lastDrawInDatabase=_drawRepository.Draws.LastOrDefault();
            var drawDifference = draws.drawNo - lastDrawInDatabase.DrawNumber;
            if (drawDifference !=0)
            {
                for (var i = 1; i <= drawDifference; i++)
                {
                    DrawData drawToSave = await ApiOpapFetch(lastDrawInDatabase.DrawNumber + i);
                    await AddToDataBase(drawToSave);
                }
            }
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

        public async Task<DrawData> ApiOpapFetch()
        {
            var sendDraws = await _webApiFetch.WebApiFetchAsync("http://applications.opap.gr/DrawsRestServices/joker/last.json");
            //{"draw":{"drawTime":"22-03-2018T22:00:00","drawNo":1898,"results":[4,11,23,34,22,12]}}
            var stringLength = sendDraws.Length - 9;
            var temp = sendDraws.Substring(8, stringLength);
            //After substring we take this json
            //{"drawTime":"22-03-2018T22:00:00","drawNo":1898,"results":[4,11,23,34,22,12]}
            //better for model biding
            return JsonConvert.DeserializeObject<DrawData>(temp);
        }

        public async Task<DrawData> ApiOpapFetch(int drawNumber)
        {
            var sendDraws = await _webApiFetch.WebApiFetchAsync($"http://applications.opap.gr/DrawsRestServices/joker/{drawNumber}.json");
            //{"draw":{"drawTime":"22-03-2018T22:00:00","drawNo":1898,"results":[4,11,23,34,22,12]}}
            var stringLength = sendDraws.Length - 9;
            var temp = sendDraws.Substring(8, stringLength);
            //After substring we take this json
            //{"drawTime":"22-03-2018T22:00:00","drawNo":1898,"results":[4,11,23,34,22,12]}
            //better for model biding
            return JsonConvert.DeserializeObject<DrawData>(temp);
        }

        public async Task AddToDataBase(DrawData draws)
        {
            //New array without joker inside so as to sort it
            int[] drawWithoutJokerArray = new int[] { draws.results[0], draws.results[1], draws.results[2], draws.results[3], draws.results[4] };
            //sort the new array from min to max
            //Array.Sort internally use Quicksort algorithm.
            Array.Sort(drawWithoutJokerArray);
            //extract date from the json string "drawTime":"22-03-2018T22:00:00" like this "22-03-2018"
            string pattern = @"\d{2}-\d{2}-\d{4}";
            Match result = Regex.Match(draws.drawTime, pattern);
            //If we have a match then 
            if (result.Success)
            {
                var newDraw = new Draw
                {
                    DrawDate = DateTime.Parse(result.Value),
                    DrawNumber = draws.drawNo,
                    Number1 = drawWithoutJokerArray[0],
                    Number2 = drawWithoutJokerArray[1],
                    Number3 = drawWithoutJokerArray[2],
                    Number4 = drawWithoutJokerArray[3],
                    Number5 = drawWithoutJokerArray[4],
                    Joker = draws.results[5],
                };
                //Add to database
                await _drawRepository.AddDraw(newDraw);
            }
        }
    }
}
