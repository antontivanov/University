using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SharedTravelling.Models
{
    class TripsToShowModel
    {
        public string Username { get; set; }

        public string Time { get; set; }

        public string Seats { get; set; }

        public string Car { get; set; }

        public Visibility Smoking { get; set; }

        public Visibility Drinking { get; set; }

        public Visibility Eating { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
