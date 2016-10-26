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
    public class BikesViewModel : BaseViewModel
    {
        private readonly IBikesService Service;

        public IList<Bike> Bikes { get; set; }

        public Bike SelectedBike { get; set; }

        public BikesViewModel()
            : this(new MockBikesService())
        {
            
        }

        public BikesViewModel(IBikesService service)
        {
            this.Service = service;

            Load();
        }

        public override void Load()
        {
            Bikes = Service.GetBikes();
        }
    }
}
