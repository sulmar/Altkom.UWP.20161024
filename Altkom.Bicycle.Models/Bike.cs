using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.Bicycle.Models
{
    public class Bike : Base
    {
        public int BikeId { get; set; }

        public string Number { get; set; }

        public BikeType BikeType { get; set; }

        public DateTime StartWorkDate { get; set; }
    }
}
