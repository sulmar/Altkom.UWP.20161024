using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using Altkom.Bicycle.UWPClient.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Linq;


namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class StationsViewModel : BaseViewModel
    {

        #region IsBusy

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Stations

        private IList<Station> _Stations;
        public IList<Station> Stations
        {
            get
            {
                return _Stations;
            }
            set
            {
                _Stations = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region SelectedStation

        private Station _SelectedStation;
        public Station SelectedStation
        {
            get { return _SelectedStation; }
            set
            {
                _SelectedStation = value;                

                DisplayMapCommand.OnCanExecuteChanged();
            }
        }

        #endregion

        #region CurrentLocation

        private Location _CurrentLocation;
        public Location CurrentLocation
        {
            get { return _CurrentLocation; }

            set
            {
                _CurrentLocation = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region GroupStations

        private IList<GroupStation> _GroupStation;

        public IList<GroupStation> GroupStations
        {
            get { return _GroupStation; }
            set {
                _GroupStation = value;
                OnPropertyChanged();
            }
        }

        #endregion


        private IList<string> _Cities;

        public IList<string> Cities
        {
            get { return _Cities; }
            set
            {
                _Cities = value;
                OnPropertyChanged();
            }
        }



        private readonly IStationsService StationsService;

        public StationsViewModel()
            : this(new XmlStationsService())
        {

        }

        public StationsViewModel(IStationsService service)
        {
            this.StationsService = service;

            // Load();
            // SelectedStation = Stations.Last();
        }

        #region LoadCommand

        private ICommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand==null)
                {
                    _LoadCommand = new RelayCommand(Load);
                }

                return _LoadCommand;
            }
        }


      

        #endregion

        public async override void Load()
        {
            IsBusy = true;
           
            Stations = await StationsService.GetStationsAsync();

            GetGroupStations();
            GetCities();

            await Find();

            IsBusy = false;
        }

        #region DisplayMapCommand

        private IRelayCommand _DisplayMapCommand;

        public IRelayCommand DisplayMapCommand
        {
            get
            {
                if (_DisplayMapCommand == null)
                {
                    _DisplayMapCommand = new RelayCommand(DisplayMap, CanDisplayMap);
                }

                return _DisplayMapCommand;
            }
        }

        #endregion

        public void DisplayMap()
        {
            // TODO: Display map

        }

        public bool CanDisplayMap()
        {
           return SelectedStation != null;
        }

        public async Task Find()
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator();
            var position = await geolocator.GetGeopositionAsync();

            CurrentLocation = new Location
            {
                Latitude = position.Coordinate.Point.Position.Latitude,
                Longitude = position.Coordinate.Point.Position.Longitude,
            };
        }


        public void GetGroupStations()
        {
            GroupStations = Stations
                .GroupBy(s => s.City)
                .Select(g => new GroupStation
                    {
                        City = g.Key,
                        Stations = g.ToList()
                })
                .ToList();

        }

        public void GetCities()
        {
            Cities = GroupStations.Select(s => s.City).ToList();
        }


    }
}
