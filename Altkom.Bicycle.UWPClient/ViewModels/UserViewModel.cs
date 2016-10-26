using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User User { get; set; }

        private IUsersService UserService;

       
        public UserViewModel()
            : this(new MockUsersService())
        {
            Load();
        }

        public UserViewModel(IUsersService service)
        {
            this.UserService = service;
        }

        public override void Load()
        {

#warning Zamienic na pobranie 
            User = UserService.Get("12345");

        }
    }
}
