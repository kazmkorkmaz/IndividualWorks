using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.Fake
{
    public static class FakeData
    {
        private static List<User> _user;

        public static List<User> GetUsers(int number)
        {
            if (_user==null)
            {
                _user = new Faker<User>()
                .RuleFor(u => u.UserId, f => f.IndexFaker + 1)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Address, f => f.Address.Locale)
                .Generate(number);
            }
            return _user;
        }
        
    }
}
