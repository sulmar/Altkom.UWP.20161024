using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                _IsActive = value;

                OnPropertyChanged();
            }
        }



        public override void Load()
        {
        }
    }
}
