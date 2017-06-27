using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTravelling.Models
{
    class AccountModel
    {
        public AccountModel()
        {
            Cars = new List<CarModel>();
            Trips = new List<TripModel>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IList<CarModel> Cars { get; set; }

        public IList<TripModel> Trips { get; set; }

        public double Rating { get; set; }
    }
}
