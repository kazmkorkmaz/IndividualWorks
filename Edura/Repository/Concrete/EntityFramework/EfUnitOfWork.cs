using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EduraContext dbContext;
        public EfUnitOfWork(EduraContext eduraContext)
        {
            dbContext = eduraContext ?? throw new ArgumentNullException("DbContext can not be null");
        }

        private IProductRepository _products;
        private ICategryRepository _categories;
        private IOrderRepository _orders;

        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EfProductRepository(dbContext));
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                return _orders ?? (_orders = new EfOrderRepository(dbContext));
            }
        }



        public ICategryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(dbContext));
            }
        }



        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                 dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        //public void Dispose()
        //{
        //    dbContext.SaveChanges();
        //}


    }
}
