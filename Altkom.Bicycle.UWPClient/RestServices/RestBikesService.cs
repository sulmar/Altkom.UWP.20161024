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
    public class RestBikesService : RestBaseService<Bike>, IBikesService
    {
        public Bike GetBike(int bikeId)
        {
            throw new NotImplementedException();
        }

        public IList<Bike> GetBikes()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Bike>> GetBikesAsync()
        {
            return this.GetListAsync("http://localhost:54362/api/bikes");
        }



        //public async Task<IList<Bike>> GetBikesAsync()
        //{

        //    RestBaseService client = new  

        //    using (var client = new HttpClient())
        //    {
        //        var request = "http://localhost:54362/api/bikes";

        //        var response = await client.GetAsync(request);

        //        // var content = await response.Content.ReadAsStringAsync();

        //        var result = await response.Content.ReadAsAsync<IList<Bike>>();

        //        return result;

        //    }
        //}

        public async Task<Bike> GetBikesAsync(int bikeId)
        {
            using (var client = new HttpClient())
            {
                var request = $"http://localhost:54362/api/bikes/{bikeId}";

                var response = await client.GetAsync(request);

                var bike = await response.Content.ReadAsAsync<Bike>();

                return bike;

            }
        }
    }
}
