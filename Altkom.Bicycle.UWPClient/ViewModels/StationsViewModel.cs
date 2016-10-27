using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using Altkom.Bicycle.UWPClient.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class StationsViewModel : BaseViewModel
    {
        private IList<Station> _Stations;
        public IList<Station> Stations { get { return _Stations; }
        set
            {
                _Stations = value;

                OnPropertyChanged();
            }
        }

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

        public async override void Load()
        {
            Stations = await StationsService.GetStationsAsync();

            // Stations = StationsService.GetStationsAsync();
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
            
    }
}
