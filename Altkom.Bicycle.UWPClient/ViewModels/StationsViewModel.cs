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
    public class StationsViewModel : BaseViewModel
    {
        public IList<Station> Stations { get; set; }

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
            : this(new MockStationsService())
        {

        }

        public StationsViewModel(IStationsService service)
        {
            this.StationsService = service;

            Load();

            // SelectedStation = Stations.Last();
        }

        public override void Load()
        {
            Stations = StationsService.GetStations();
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
