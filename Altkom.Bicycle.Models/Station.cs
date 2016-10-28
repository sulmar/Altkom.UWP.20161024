using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Models
{
    public class Station : Base
    {
        public int StationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public short Capacity { get; set; }

        public Location Location { get; set; }

        public string City { get; set; }

        public IList<Bike> Bikes { get; set; }


        public override string ToString() => $"{Name} - {Address}";


    }
}
