using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserForm.Models;

namespace UserForm.OverrideEntity
{
    public class CreateUserModel:UserInformations
    {
        public IFormFile FormFile { get; set; }
    }
}
