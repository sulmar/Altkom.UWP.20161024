using Altkom.Bicycle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Altkom.Bicycle.Models;
using System.Threading.Tasks;

namespace Altkom.Bicycle.MockServices
{

    public class MockStationsService : IStationsService
    {
        private static IList<Station> _Stations = new List<Station>
        {
            new Station {
                StationId = 1,
                Name = "ST001",
                Address = "ul. Chlodna 51",
                Capacity = 10,
                Location = new Location { Latitude = 52.01, Longitude = 27.01 },
            },

            new Station {
                StationId = 2,
                Name = "ST002",
                Address = "Dworzec Centralny",
                Capacity = 30,
                Location = new Location { Latitude = 52.08, Longitude = 27.54 },
            },

            new Station {
                StationId = 1,
                Name = "ST003",
                Address = "Dworzec Zachodni",
                Capacity = 5,
                Location = new Location { Latitude = 52.51, Longitude = 27.81 },
            },

             new Station {
                StationId = 4,
                Name = "ST004",
                Address = "Poznan",
                Capacity = 14,
                Location = new Location { Latitude = 51.51, Longitude = 27.81 },
            },
        };

        public Station FindNearestStation(Location location)
        {
            return _Stations.First();
        }

        public Task<Station> FindNearestStationAsync(Location location)
        {
            return Task.Run(() => FindNearestStation(location));
        }

        public IList<Station> GetStations()
        {
            return _Stations;
        }

        public Task<IList<Station>> GetStationsAsync()
        {
            return Task.Run(() => GetStations());
        }

        public Station GetStation(int id)
        {
            return _Stations.SingleOrDefault(s => s.StationId == id);
        }
    }
}
