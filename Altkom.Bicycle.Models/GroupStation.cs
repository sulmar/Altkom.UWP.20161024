using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Models
{
    public class GroupStation
    {
        public string City { get; set; }

        public IList<Station> Stations { get; set; }
    }
}
