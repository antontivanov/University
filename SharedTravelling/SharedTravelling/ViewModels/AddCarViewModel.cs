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
    class AddCarViewModel : INotifyPropertyChanged
    {
        private string activeUser;
        private AccountFactory _accountFactory;

        private ICommand search;
        private ICommand addTrip;
        private ICommand addCar;
        private ICommand openMenu;

        private bool open;

        private ICommand addCarAction;
        private string brand;
        private string model;
        private string color;
        private string year;

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

        public ICommand AddCarAction
        {
            get
            {
                return addCarAction;
            }

            private set
            {
                addCarAction = value;
            }
        }
        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
                OnPropertyChange("Brand");
            }
        }
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;

                OnPropertyChange("Model");

            }
        }
        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;

                OnPropertyChange("Color");

            }
        }
        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;

                OnPropertyChange("Year");

            }
        }

        public AddCarViewModel()
        {
            _accountFactory = new AccountFactory();

            activeUser = _accountFactory.GetUser();

            Search = new RelayCommand(OpenSearchPage, () => true);
            AddTrip = new RelayCommand(OpenAddTripPage, () => true);
            AddCar = new RelayCommand(OpenAddCarPage, () => true);
            OpenMenu = new RelayCommand(OpenSideMenu, () => true);

            AddCarAction = new RelayCommand(AddCarToUser, () => true);

            Open = false;
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

        private void AddCarToUser()
        {
            var model = new CarModel();

            var shouldAddCar = CheckInputs();

            if(shouldAddCar)
            {
                model.Brand = Brand;
                model.Model = Model;
                model.Color = Color;
                model.Year = Year;
            }
            else
            {
                var dialog = new MessageDialog("Some of the fields are incorrect.");
                dialog.ShowAsync();
            }

            try
            {
                _accountFactory.AddCarToUser(activeUser, model);

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
            if(Brand.Length < 4 || Model.Length < 4 || Color.Length < 4 || Year.Length < 4)
            {
                return false;
            }

            return true;
        }
    }
}
