using Altkom.Bicycle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.Bicycle.Models;

namespace Altkom.Bicycle.MockServices
{
    public class MockBikesService : IBikesService
    {
        private static IList<Bike> _Bikes = new List<Bike>
        {
            new Bike { BikeId = 1, Number = "R001", BikeType = BikeType.City, StartWorkDate = DateTime.Parse("2015-01-04") },
            new Bike { BikeId = 2, Number = "R002", BikeType = BikeType.Kids, StartWorkDate = DateTime.Parse("2015-11-04") },
            new Bike { BikeId = 3, Number = "R003", BikeType = BikeType.Tandem, StartWorkDate = DateTime.Parse("2014-05-04") },
            new Bike { BikeId = 4, Number = "R004", BikeType = BikeType.City, StartWorkDate = DateTime.Parse("2016-02-24") },
            new Bike { BikeId = 5, Number = "R005", BikeType = BikeType.City, StartWorkDate = DateTime.Parse("2015-08-14") },
        };

        public Bike GetBike(int bikeId)
        {
            return _Bikes.SingleOrDefault(b => b.BikeId == bikeId);
        }

        public IList<Bike> GetBikes()
        {
            return _Bikes;
        }

        public Task<IList<Bike>> GetBikesAsync()
        {
            return Task<IList<Bike>>.Run(() => GetBikes());
        }

        public Task<Bike> GetBikesAsync(int bikeId)
        {
            return Task.Run(() => GetBike(bikeId));
        }
    }
}
