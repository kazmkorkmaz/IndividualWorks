using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class CategoryMenu:ViewComponent
    {
        private ICategryRepository repository;
        public CategoryMenu(ICategryRepository _repository)
        {
            repository = _repository;
        }
        public IViewComponentResult Invoke() 
        {
            return View(repository.GetAllCategoriesWithCount());
        }
    }
}
