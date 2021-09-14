using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserForm.Models;

namespace UserForm.Data
{
    public class UserFormInfo:DbContext
    {
        public UserFormInfo(DbContextOptions<UserFormInfo> options) : base(options) { }
        public DbSet<UserInformations> UserInformation { get; set; }
    }
}
