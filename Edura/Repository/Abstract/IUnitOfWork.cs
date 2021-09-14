﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICategryRepository Categories { get; }
        IOrderRepository Orders { get; }
        int SaveChanges();
    }
}