using GoogleRecaptcha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleRecaptcha.Controllers
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
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> RecaptchaControl(string data)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://www.google.com/recaptcha/api/siteverify?secret=6Len6SkcAAAAAHUEf35ATYWA4YfKixc1PyMZRH_T&response="+data);
            var recaptchaResonse = JsonConvert.DeserializeObject<CaptchaModel>(response);
            if (recaptchaResonse.success == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
