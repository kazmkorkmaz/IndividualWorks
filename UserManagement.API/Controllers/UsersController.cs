using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Fake;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);
        
        [HttpGet]
        public List<User> Get() 
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(u=>u.UserId==id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var user_ = _users.FirstOrDefault(u => u.UserId == user.UserId);
            user_.FirstName = user.FirstName;
            user_.LastName = user.LastName;
            user_.Address = user.Address;
            return user;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(u=>u.UserId==id);
            _users.Remove(deletedUser);
            
        }
    }
}
