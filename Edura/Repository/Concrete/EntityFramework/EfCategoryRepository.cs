using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategryRepository
    {
        public EfCategoryRepository(EduraContext context):base(context)
        {
            
        }

        public EduraContext EduraContext
        {
            get { return contex as EduraContext; }
        }

        public IEnumerable<CategoryModel> GetAllCategoriesWithCount()
        {
            return GetAll().Select(i => new CategoryModel()
            {
                CategoryId = i.CategoryId,
                CategoryName=i.CategoryName,
                Count=i.ProductCategories.Count()
            });         
        }

        public Category GetByName(string name)
        {
            return EduraContext.Categories.Where(i => i.CategoryName == name).FirstOrDefault();
        }
    }
}
