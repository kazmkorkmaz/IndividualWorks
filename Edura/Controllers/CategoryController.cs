using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategryRepository repository;
        public CategoryController(ICategryRepository categryRepository)
        {
            repository = categryRepository;
        }
        public IActionResult Index()
        {
            return View(repository.GetByName("Electronics"));
        }
    }
}
