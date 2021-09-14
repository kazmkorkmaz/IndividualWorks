using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AjaxÖrnek.Models;
using AjaxÖrnek.Repository;

namespace AjaxÖrnek.Controllers
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
        public IActionResult DisplayCarsAndOwnersView()
        {
            List<Car> carList=DataProvider.GetAllCars();
            return View("PersonCarView",carList);
        }
        [HttpPost]
        public JsonResult GetCarOwners(int CarId)
        {
            List<Person> carOwners = DataProvider.GetPeople(CarId);



            return Json(carOwners);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
