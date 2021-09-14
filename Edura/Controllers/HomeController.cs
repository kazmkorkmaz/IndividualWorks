using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork _unitOfWork, IProductRepository _repository)
        {
            unitOfWork = _unitOfWork;
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.Products.GetAll().Where(i=>i.IsApproved && i.IsHome).ToList());
        }
        public IActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

    }
}
