using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Interfaces
{
    public interface IBikesService
    {
        IList<Bike> GetBikes();

        Task<IList<Bike>> GetBikesAsync();

        Bike GetBike(int bikeId);

        Task<Bike> GetBikesAsync(int bikeId);
    }
}
