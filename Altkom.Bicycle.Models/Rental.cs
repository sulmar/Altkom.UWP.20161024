using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Models
{
    public class Rental : Base
    {
        public int RentalId { get; set; }

        public User User { get; set; }

        public Bike Bike { get; set; }

        public Station StationFrom { get; set; }

        public DateTime DateFrom { get; set; }

        public Station StationTo { get; set; }
        
        public DateTime? DateTo { get; set; }

        public decimal? Cost { get; set; }
    }
}
