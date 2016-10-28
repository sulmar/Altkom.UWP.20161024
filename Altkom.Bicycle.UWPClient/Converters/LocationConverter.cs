using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Data;

namespace Altkom.Bicycle.UWPClient.Converters
{
    public class LocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var location = value as Location;

            if (location != null)
            {
                var position = new BasicGeoposition
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                };

                return new Geopoint(position);
            }
            else
                return new Geopoint(new BasicGeoposition());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
