using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Interfaces
{
    public interface IStationsService
    {
        IList<Station> GetStations();

        Task<IList<Station>> GetStationsAsync();

        Station FindNearestStation(Location location);

        Task<Station> FindNearestStationAsync(Location location);


    }
}
