using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Interfaces
{
    public interface IUsersService
    {
        User Get(int userId);

        User Get(string identifier);

        void Add(User user);

        void Update(User user);

        void Remove(int userId);

        
    }
}
