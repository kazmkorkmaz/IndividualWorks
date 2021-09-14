using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface ICategryRepository:IGenericRepository<Category>
    {
        Category GetByName(string name);
        IEnumerable<CategoryModel> GetAllCategoriesWithCount();
    }
}
