using AppUIBasics.Common;
using SharedTravelling.Factory;
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
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;

        private ICommand login;
        private ICommand register;

        private AccountFactory _accountFactory;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;

                OnPropertyChange("Username");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;

                OnPropertyChange("Password");
            }
        }

        public ICommand Login
        {
            get
            {
                return login;
            }

            private set
            {
                login = value;
            }
        }
        public ICommand Register
        {
            get
            {
                return register;
            }

            private set
            {
                register = value;
            }
        }

        public MainWindowViewModel()
        {
            _accountFactory = new AccountFactory();

            Login = new RelayCommand(LoginInApp, () => true);
            Register = new RelayCommand(RegisterAccount, () => true);
        }

        private void OnPropertyChange(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoginInApp()
        {
            bool userExists = _accountFactory.AccountModels.Where(x => x.Username.Equals(Username) && x.Password.Equals(Password)).ToList().Count > 0;

            if(userExists)
            {
                _accountFactory.SetUser(Username);

                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(SearchTrips));
            }
            else
            {
                var dialog = new MessageDialog("Wrong username or password.");
                dialog.ShowAsync();
            }
        }

        private void RegisterAccount()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Register));
        }
    }
}
