using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTravelling.Models
{
    class TripModel
    {
        public string Time { get; set; }

        public int NumberOfSeats { get; set; }

        public CarModel Car { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public bool Smoking { get; set; }

        public bool Eating { get; set; }

        public bool Drinking { get; set; }

        public IList<string> Passengers { get; set; }
    }
}
