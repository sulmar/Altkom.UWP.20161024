using Altkom.Bicycle.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.Bicycle.Models;
using System.Net.Http;
using System.Xml.Linq;
using System.Globalization;

namespace Altkom.Bicycle.MockServices
{
    public class XmlStationsService : IStationsService
    {

        private const string uri = "https://nextbike.net/maps/nextbike-official.xml";

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

        public async Task<IList<Station>> GetStationsAsync()
        {
            string country = "Poland";
            string city = "Warszawa";

            var client = new HttpClient();


            var content = await client.GetStringAsync(uri);

            // Linq To Xml


            var doc = XDocument.Parse(content)
                .Root
                .Descendants("country")
                .Where(item => item.Attribute("country_name").Value == country)
                .Descendants("city")
                .Where(item => item.Attribute("name").Value == city)
                .Descendants("place")
                .Select(item => new
                {
                    Id = item.Attribute("uid").Value,
                    Number = item.Attribute("number")?.Value,
                    Name = item.Attribute("name")?.Value,
                    Latitude = item.Attribute("lat").Value,
                    Longitude = item.Attribute("lng").Value,
                    Capacity = item.Attribute("bike_racks").Value,
                });


            var stations = doc.Select(s => new Station
            {
                StationId = int.Parse(s.Id, CultureInfo.InvariantCulture),
                Name = s.Name,
                Address = s.Name,
                Capacity = short.Parse(s.Capacity, CultureInfo.InvariantCulture),
                Location = new Location
                {
                    Latitude = double.Parse(s.Latitude, CultureInfo.InvariantCulture),
                    Longitude = double.Parse(s.Longitude, CultureInfo.InvariantCulture),
                },
                
            });


            return stations.ToList();

        }
    }
}
