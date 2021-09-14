using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserForm.Common;
using UserForm.Data;
using UserForm.Models;
using UserForm.OverrideEntity;

namespace UserForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFormInfo _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(UserFormInfo context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: UserInfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInformation.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<int> Create(CreateUserModel createUser)
        {
           try
            {
                var uniqueFileName = GetUniqueFileName(createUser.FormFile.FileName);
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                createUser.Image = "/uploads/" + uniqueFileName;
                createUser.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                PasswordEncryption password = new PasswordEncryption();
                createUser.Password = password.Encode(createUser.Password.ToString());
                _context.Add(createUser);
                await _context.SaveChangesAsync();
                return Convert.ToInt32(ResponseTypes.Success);
            }
            catch (Exception ex)
            {
                return Convert.ToInt32(ResponseTypes.Error);

            }
        }
        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.UserInformation.FindAsync(id);
            PasswordEncryption password = new PasswordEncryption();
            user.Password = password.Decode(user.Password);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<int> Edit(int id, CreateUserModel createUser)
        {
            try
            {
                if (id != createUser.Id)
                {
                    return (int)ResponseTypes.Error;
                }
                var uniqueFileName = GetUniqueFileName(createUser.FormFile.FileName);
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                createUser.Image = "/uploads/" + uniqueFileName;
                createUser.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                PasswordEncryption password = new PasswordEncryption();
                createUser.Password = password.Encode(createUser.Password.ToString());
                _context.Update(createUser);
                await _context.SaveChangesAsync();
                return (int)ResponseTypes.Success;
            }
            catch (Exception)
            {

               return Convert.ToInt32(ResponseTypes.Error);
            }                   
                    
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.UserInformation.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.UserInformation.FindAsync(id);
            _context.UserInformation.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.UserInformation.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

    }
}
