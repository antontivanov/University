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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SharedTravelling.ViewModels
{
    class SearchTripsViewModel : INotifyPropertyChanged
    {
        private AccountFactory _accountFactory;
        private string activeUsername;

        private ICommand search;
        private ICommand addTrip;
        private ICommand addCar;
        private ICommand openMenu;

        private bool open;

        private IList<TripsToShowModel> tripsToShow;

        private IList<string> searchItems;
        private string selectedSearchItem;

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

        public IList<TripsToShowModel> TripsToShow
        {
            get
            {
                return tripsToShow;
            }

            set
            {
                tripsToShow = value;

                OnPropertyChange("TripsToShow");
            }
        }

        public IList<string> SearchItems
        {
            get
            {
                return searchItems;
            }

            set
            {
                searchItems = value;

                OnPropertyChange("SearchItems");
            }
        }
        public string SelectedSearchItem
        {
            get
            {
                return selectedSearchItem;
            }

            set
            {
                selectedSearchItem = value;

                Filter();

                OnPropertyChange("SelectedSearchItem");
            }
        }

        public SearchTripsViewModel()
        {
            _accountFactory = new AccountFactory();
            activeUsername = _accountFactory.GetUser();

            Search = new RelayCommand(OpenSearchPage, () => true);
            AddTrip = new RelayCommand(OpenAddTripPage, () => true);
            AddCar = new RelayCommand(OpenAddCarPage, () => true);
            OpenMenu = new RelayCommand(OpenSideMenu, () => true);

            Open = false;

            TripsToShow = PopulateTripsToShow();

            PopuplateSearchItems();
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
            if(Open)
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

        private IList<TripsToShowModel> PopulateTripsToShow()
        {
            var accounts = _accountFactory.AccountModels.Where(x => !x.Username.Equals(activeUsername));

            var tripsToReturn = new List<TripsToShowModel>();

            if(accounts == null)
            {
                return tripsToReturn;
            }

            foreach(var account in accounts)
            {
                var trips = account.Trips;

                foreach(var trip in trips)
                {
                    var tripToShow = new TripsToShowModel();

                    tripToShow.Username = "Driver: " + account.Username;
                    tripToShow.Time = "Time: " + trip.Time;
                    tripToShow.Seats = "Seats: " + trip.NumberOfSeats.ToString();

                    tripToShow.From = trip.From;
                    tripToShow.To = trip.To;

                    if(trip.Smoking)
                    {
                        tripToShow.Smoking = Visibility.Visible;
                    }
                    else
                    {
                        tripToShow.Smoking = Visibility.Collapsed;
                    }

                    if (trip.Drinking)
                    {
                        tripToShow.Drinking = Visibility.Visible;
                    }
                    else
                    {
                        tripToShow.Drinking = Visibility.Collapsed;
                    }

                    if (trip.Eating)
                    {
                        tripToShow.Eating = Visibility.Visible;
                    }
                    else
                    {
                        tripToShow.Eating = Visibility.Collapsed;
                    }

                    tripsToReturn.Add(tripToShow);
                }
            }

            return tripsToReturn;
        }

        private void PopuplateSearchItems()
        {
            var itemsToSearch = new List<string>();

            itemsToSearch.Add("");

            foreach (var trips in TripsToShow)
            {
                var location = trips.From + " - " + trips.To;

                itemsToSearch.Add(location);
            }

            SearchItems = itemsToSearch;            
        }

        private void Filter()
        {
            TripsToShow = PopulateTripsToShow();

            if (selectedSearchItem.Equals(""))
            {

                return;
            }

            var array = selectedSearchItem.Split('-');

            var from = array[0].Trim();
            var to = array[1].Trim();

            TripsToShow = TripsToShow.Where(x => x.From.Equals(from) && x.To.Equals(to)).ToList();
        }
    }
}
