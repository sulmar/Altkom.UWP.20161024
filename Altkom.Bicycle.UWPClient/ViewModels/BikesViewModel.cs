using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using Altkom.Bicycle.UWPClient.Commands;
using Altkom.Bicycle.UWPClient.RestServices;
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

        #region LoadCommand

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

        #endregion

        public BikesViewModel()
            : this(new RestBikesService()) {}

        public BikesViewModel(IBikesService service)
        {
            this.Service = service;
        }

        public async override void Load()
        {
               Bikes = await Service.GetBikesAsync();
        }
    }
}
