using Altkom.Bicycle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.Bicycle.Models;
using System.Net.Http;

namespace Altkom.Bicycle.UWPClient.RestServices
{
    public class RestStationsService : RestBaseService<Station>, IStationsService
    {
        public Station FindNearestStation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<Station> FindNearestStationAsync(Location location)
        {
            throw new NotImplementedException();
        }

        public IList<Station> GetStations()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Station>> GetStationsAsync()
        {
            return GetListAsync("http://localhost:54362/api/stations");
        }
    }
}
