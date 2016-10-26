using Altkom.Bicycle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.Bicycle.Models;

namespace Altkom.Bicycle.MockServices
{
    public class MockUsersService : IUsersService
    {
        private static IList<User> _Users = new List<User>
        {
            new User {
                UserId = 1,
                FirstName = "Marcin",
                LastName = "Sulecki",
                Identifier = "12345",
                IsActive = true,
                }
        };

        public void Add(User user)
        {
            _Users.Add(user);
        }

        public User Get(string identifier)
        {
            return _Users.SingleOrDefault(u => u.Identifier == identifier);
        }

        public User Get(int userId)
        {
            return _Users.SingleOrDefault(u => u.UserId == userId);
        }

        public void Remove(int userId)
        {
            var user = Get(userId);

            if (user != null)
                _Users.Remove(user);
            else
                throw new KeyNotFoundException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
