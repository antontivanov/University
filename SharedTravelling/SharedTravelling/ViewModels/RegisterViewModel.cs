using AppUIBasics.Common;
using SharedTravelling.Factory;
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
    class RegisterViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private DateTime dateOfBirth;       

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
                return this.password;
            }

            set
            {
                this.password = value;

                OnPropertyChange("Password");

            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;

                OnPropertyChange("DateOfBirth");

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

        public RegisterViewModel()
        {
            _accountFactory = new AccountFactory();

            Register = new RelayCommand(RegisterUser, () => true);
        }

        private void OnPropertyChange(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void RegisterUser()
        {
            try
            {
                ValidateFields();

                _accountFactory.RegisterUser(Username, Password, DateOfBirth);

                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainPage));
            }
            catch(ArgumentException e)
            {
                var dialog = new MessageDialog("Some of the fields are incorrect!");
                dialog.ShowAsync();
            }
            catch(Exception e)
            {
                var dialog = new MessageDialog("Something happened... Please, try again!");
                dialog.ShowAsync();
            }
        }

        private void ValidateFields()
        {
            if(Username == null || Username == "")
            {
                throw new ArgumentException();
            }
            else if(Username.Length < 3)
            {
                throw new ArgumentException();

            }

            if(Password == null || Password.Equals(""))
            {
                throw new ArgumentException();

            }
            else if (Password.Length < 5)
            {
                throw new ArgumentException();
            }
        }
    }
}
