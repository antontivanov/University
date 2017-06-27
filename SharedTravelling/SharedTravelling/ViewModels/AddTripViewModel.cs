using AppUIBasics.Common;
using SharedTravelling.Factory;
using SharedTravelling.Models;
using SharedTravelling.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SharedTravelling.ViewModels
{
    class AddTripViewModel : INotifyPropertyChanged
    {
        private string activeUser;
        private AccountFactory _accountFactory;

        private ICommand search;
        private ICommand addTrip;
        private ICommand addCar;
        private ICommand openMenu;

        private bool open;

        private ICommand addTripAction;
        private string time;
        private string seats;
        private string car;
        private bool smoking;
        private bool drinking;
        private bool eating;
        private string from;
        private string to;

        private IList<string> carsToShow;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Search
        {
            get
            {
                return search;
            }

            private set
            {
                search = value;
            }
        }
        public ICommand AddTrip
        {
            get
            {
                return addTrip;
            }

            private set
            {
                addTrip = value;
            }
        }
        public ICommand AddCar
        {
            get
            {
                return addCar;
            }

            private set
            {
                addCar = value;
            }
        }
        public ICommand OpenMenu
        {
            get
            {
                return openMenu;
            }

            set
            {
                openMenu = value;
            }
        }

        public Boolean Open
        {
            get
            {
                return open;
            }

            set
            {
                open = value;

                OnPropertyChange("Open");
            }
        }

        public ICommand AddTripAction
        {
            get
            {
                return addTripAction;
            }

            private set
            {
                addTripAction = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;

                OnPropertyChange("Time");
            }
        }
        public string Seats
        {
            get
            {
                return seats;
            }

            set
            {
                seats = value;

                OnPropertyChange("Seats");
            }
        }
        public string Car
        {
            get
            {
                return car;
            }

            set
            {
                car = value;

                OnPropertyChange("Car");
            }
        }
        public bool Smoking
        {
            get
            {
                return smoking;
            }

            set
            {
                smoking = value;

                OnPropertyChange("Smoking");
            }
        }
        public bool Drinking
        {
            get
            {
                return drinking;
            }

            set
            {
                drinking = value;

                OnPropertyChange("Drinking");
            }
        }
        public bool Eating
        {
            get
            {
                return eating;
            }

            set
            {
                eating = value;

                OnPropertyChange("Eating");
            }
        }

        public IList<string> CarsToShow
        {
            get
            {
                return carsToShow;
            }

            set
            {
                carsToShow = value;

                OnPropertyChange("CarsToShow");
            }
        }

        public string From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;

                OnPropertyChange("From");
            }
        }
        public string To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;

                OnPropertyChange("To");
            }
        }

        public AddTripViewModel()
        {
            _accountFactory = new AccountFactory();

            activeUser = _accountFactory.GetUser();

            Search = new RelayCommand(OpenSearchPage, () => true);
            AddTrip = new RelayCommand(OpenAddTripPage, () => true);
            AddCar = new RelayCommand(OpenAddCarPage, () => true);
            OpenMenu = new RelayCommand(OpenSideMenu, () => true);

            AddTripAction = new RelayCommand(AddTripToUser, () => true);

            Open = false;
            Smoking = false;
            Drinking = false;
            Eating = false;

            PopulateCars();
        }

        private void OnPropertyChange(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OpenSideMenu()
        {
            if (Open)
            {
                Open = false;
            }
            else
            {
                Open = true;
            }
        }

        private void OpenSearchPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(SearchTrips));
        }

        private void OpenAddTripPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AddTrip));
        }

        private void OpenAddCarPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AddCar));
        }

        private void AddTripToUser()
        {
            var model = new TripModel();

            var shouldAddCar = CheckInputs();

            CarModel carToSafe = null;

            if (shouldAddCar)
            {
                model.Time = Time;
                int numberOfSeats = 0;

                if(Int32.TryParse(Seats, out numberOfSeats))
                {
                    model.NumberOfSeats = numberOfSeats;
                }
                else
                {
                    var dialog = new MessageDialog("Seats field is incorrect.");
                    dialog.ShowAsync();

                    return;
                }

                var selectedCar = GetSelectedCar();

                if(selectedCar == null)
                {
                    var dialog = new MessageDialog("Car selected is  incorrect.");
                    dialog.ShowAsync();

                    return;
                }

                string carBrand = selectedCar.Brand;
                string carModel = selectedCar.Model;

                carToSafe = _accountFactory.AccountModels.FirstOrDefault(x => x.Username.Equals(activeUser)).Cars.FirstOrDefault(c => c.Brand.Equals(carBrand) && c.Model.Equals(carModel));

                if (carToSafe != null)
                {
                    model.Car = carToSafe;
                }

                model.Smoking = Smoking;
                model.Eating = Eating;
                model.Drinking = Drinking;

                model.From = From;
                model.To = To;

                model.Passengers = new List<string>();
            }
            else
            {
                var dialog = new MessageDialog("Some of the fields are incorrect.");
                dialog.ShowAsync();

                return;
            }

            try
            {
                if (model != null)
                {
                    _accountFactory.AddTripToUser(activeUser, model);
                }

                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(SearchTrips));
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog("Something happened!");
                dialog.ShowAsync();
            }
        }

        private bool CheckInputs()
        {
            if (Time.Length < 4 || Car.Length == 0 || From.Length < 4 || To.Length < 4)
            {
                return false;
            }

            int seatsNumber;
            if(!Int32.TryParse(Seats, out seatsNumber))
            {
                return false;
            }

            return true;
        }

        private void PopulateCars()
        {
            var userAccount = _accountFactory.AccountModels.FirstOrDefault(x => x.Username.Equals(activeUser));

            if(userAccount == null)
            {
                return;
            }

            var cars = userAccount.Cars;

            if(cars.Count == 0)
            {
                var dialog = new MessageDialog("Please add car first!");
                dialog.ShowAsync();

                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(AddCar));
            }

            var carNames = new List<string>();

            foreach(var car in cars)
            {
                var carName = car.Brand + "," + car.Model;

                carNames.Add(carName);
            }

            CarsToShow = carNames;
        }

        private CarModel GetSelectedCar()
        {
            var cars = _accountFactory.AccountModels.FirstOrDefault(x => x.Username.Equals(activeUser)).Cars;

            var selectedCarProperties = Car.Split(',');

            var brand = selectedCarProperties[0];
            var model = selectedCarProperties[1];

            var selectedCar = cars.FirstOrDefault(x => x.Brand.Equals(brand) && x.Model.Equals(model));

            return selectedCar;
        }
    }
}
