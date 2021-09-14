using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class FeaturedProducts:ViewComponent
    {
        private IProductRepository reposiitory;
        public FeaturedProducts(IProductRepository _reposiitory)
        {
            reposiitory = _reposiitory;
        }
        public IViewComponentResult Invoke()
        {
            return View(reposiitory.GetAll().Where(i=>i.IsFeatured && i.IsApproved).ToList());
        }

    }
}
