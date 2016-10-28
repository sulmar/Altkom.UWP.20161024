using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using Altkom.Bicycle.UWPClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User User { get; set; }

        private IUsersService UserService;

        #region SaveUserCommand

        private ICommand _SaveUserCommand;

        public ICommand SaveUserCommand
        {
            get
            {
                if (_SaveUserCommand == null)
                    _SaveUserCommand = new RelayCommand(Save, CanSave);

                return _SaveUserCommand;
            }
        }

        #endregion


        #region CallCommand

        private ICommand _CallCommand;

        public ICommand CallCommand
        {
            get
            {
                if (_CallCommand == null)
                    _CallCommand = new RelayCommand(Call, CanCall);

                return _CallCommand;
            }

        }

        public void Call()
        {
            if (ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager"))
            {
                PhoneCallManager.ShowPhoneCallUI(User.PhoneNumber, User.FullName);
            }
        }


        public bool CanCall()
        {
            return ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");
        }

        #endregion


        #region GenerateIdentifierCommand

        private ICommand _GenerateIdentifierCommand;

        public ICommand GenerateIdentifierCommand
        {
            get
            {
                if (_GenerateIdentifierCommand == null)
                    _GenerateIdentifierCommand = new RelayCommand(GenerateIdentifier, CanGenerateIdentifier);

                return _GenerateIdentifierCommand;
            }
        }

        #endregion



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


        public void Save()
        {
            UserService.Add(User);

        }

        public bool CanSave() => true;


        public void GenerateIdentifier()
        {
            User.Identifier = Guid.NewGuid().ToString();
            User.FirstName = "Jan";
            User.LastName = "Nowak";

        }

        public bool CanGenerateIdentifier() => true;

    }
}
