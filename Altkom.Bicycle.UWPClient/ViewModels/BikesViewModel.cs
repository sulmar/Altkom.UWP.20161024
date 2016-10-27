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

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class BikesViewModel : BaseViewModel
    {
        private readonly IBikesService Service;

        private IList<Bike> _Bikes;
        public IList<Bike> Bikes
        { get { return _Bikes; }
            set
            {
                _Bikes = value;

                OnPropertyChanged();
            }
        }

        public Bike SelectedBike { get; set; }

        private ICommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new RelayCommand(Load);
                }

                return _LoadCommand;
            }
        }

        public BikesViewModel()
            : this(new MockBikesService())
        {
            
        }

        public BikesViewModel(IBikesService service)
        {
            this.Service = service;

            // Load();
        }

        public override void Load()
        {
            Bikes = Service.GetBikes();
        }
    }
}
