using a;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebChatWithSignalR.Models;

namespace WebChatWithSignalR.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebchatContext _context;
        private readonly IDistributedCache _distributedCache;
        public HomeController(ILogger<HomeController> logger, WebchatContext context, IDistributedCache distributedCache)
        {
            _logger = logger;
            _context = context;
            _distributedCache = distributedCache;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<int> Register(Users user)
        {
            if (user!=null)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
       
        public IActionResult Chat(int id)
        {
            try
            {
                var userInfo = _distributedCache.GetString("User-"+ id);
                var user = JsonConvert.DeserializeObject<Users>(userInfo);
                return View(user);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public int Login(Users user)
        {
            var users =  _context.Users.FirstOrDefault(u=>u.Email==user.Email && u.Password==user.Password);
            var data = JsonConvert.SerializeObject(users);
            string redisKey = $"User-{users.Id}";
            _distributedCache.SetString(redisKey, data);
            if (users != null)
            {
                return users.Id;
            }
            return 0;
        }
        public IActionResult Logout(int id)
        {
            _distributedCache.Remove("User-" + id);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
