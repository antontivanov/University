using PasswordKeeper.Commands;
using PasswordKeeper.Enums;
using PasswordKeeper.Factories;
using PasswordKeeper.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordKeeper.ViewModels
{
    class CreateNewPasswordViewModel : INotifyPropertyChanged
    {
        #region fields
        private readonly PasswordFactory _passwordFactory;
        private readonly AccountFactory _accountFactory;

        private Visibility webSiteSelected;
        private Visibility applicationSelected;
        private Visibility showAccountFields;

        private Visibility showUsernameTextbox;
        private Visibility showUsernameSelector;

        private string appType;

        private ICommand existingUsernameClicked;
        private bool isExistingUsernameChecked;

        private ICommand increasePasswordLength;
        private ICommand decreasePasswordLength;
        private string passwordLength;

        private ICommand increaseMandatorySymbols;
        private ICommand decreaseMandatorySymbols;
        private string mandatorySymbols;

        private ICommand generatePassword;
        private string password;

        private ICommand save;
        private string username;
        private string url;
        private string name;
        private string operatingSystem;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region properties
        public Visibility WebSiteSelected
        {
            get
            {
                return webSiteSelected;
            }

            set
            {
                webSiteSelected = value;

                OnPropertyChange("WebSiteSelected");
            }
        }
        public Visibility ApplicationSelected
        {
            get
            {
                return applicationSelected;
            }

            set
            {
                applicationSelected = value;

                OnPropertyChange("ApplicationSelected");
            }
        }
        public Visibility ShowAccountFields
        {
            get
            {
                return showAccountFields;
            }

            set
            {
                showAccountFields = value;

                OnPropertyChange("ShowAccountFields");
            }
        }

        public Visibility ShowUsernameTextbox
        {
            get
            {
                return showUsernameTextbox;
            }

            set
            {
                showUsernameTextbox = value;

                OnPropertyChange("ShowUsernameTextbox");
            }
        }
        public Visibility ShowUsernameSelector
        {
            get
            {
                return showUsernameSelector;
            }

            set
            {
                showUsernameSelector = value;

                OnPropertyChange("ShowUsernameSelector");
            }
        }

        public string AppType
        {
            get
            {
                return appType;
            }

            set
            {
                appType = value;

                OnPropertyChange("AppType");

                ApplicationTypeChange(null);
            }
        }

        public ICommand ExistingUsernameClicked
        {
            get
            {
                return existingUsernameClicked;
            }

            set
            {
                existingUsernameClicked = value;


            }
        }

        public ICommand IncreasePasswordLength
        {
            get
            {
                return increasePasswordLength;
            }

            private set
            {
                increasePasswordLength = value;
            }
        }
        public ICommand DecreasePasswordLength
        {
            get
            {
                return decreasePasswordLength;
            }

            private set
            {
                decreasePasswordLength = value;
            }
        }
        public string PasswordLength
        {
            get
            {
                return passwordLength;
            }

            set
            {
                if (Int32.Parse(value) > 0)
                {
                    if (MandatorySymbols == null || Int32.Parse(value) > Int32.Parse(MandatorySymbols))
                    {
                        passwordLength = value;
                    }
                }
                else
                {
                    passwordLength = "0";
                }

                OnPropertyChange("PasswordLength");
            }
        }

        public ICommand IncreaseMandatorySymbols
        {
            get
            {
                return increaseMandatorySymbols;
            }

            private set
            {
                increaseMandatorySymbols = value;
            }
        }
        public ICommand DecreaseMandatorySymbols
        {
            get
            {
                return decreaseMandatorySymbols;
            }

            private set
            {
                decreaseMandatorySymbols = value;
            }
        }
        public string MandatorySymbols
        {
            get
            {
                return mandatorySymbols;
            }

            set
            {
                if (Int32.Parse(value) >= 0)
                {
                    if (PasswordLength == null || Int32.Parse(value) < Int32.Parse(PasswordLength))
                    {
                        mandatorySymbols = value;
                    }
                }
                else
                {
                    mandatorySymbols = "0";
                }

                OnPropertyChange("MandatorySymbols");
            }
        }

        public ICommand GeneratePassword
        {
            get
            {
                return generatePassword;
            }

            private set
            {
                generatePassword = value;
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

        public ICommand Save
        {
            get
            {
                return save;
            }

            private set
            {
                save = value;
            }
        }
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
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;

                OnPropertyChange("Url");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;

                OnPropertyChange("Name");
            }
        }
        public string OperatingSystem
        {
            get
            {
                return operatingSystem;
            }

            set
            {
                operatingSystem = value;

                OnPropertyChange("OperatingSystem");
            }
        }
        #endregion

        #region ctor
        public CreateNewPasswordViewModel()
        {
            _passwordFactory = new PasswordFactory();
            _accountFactory = new AccountFactory();

            isExistingUsernameChecked = false;

            WebSiteSelected = Visibility.Hidden;
            ApplicationSelected = Visibility.Hidden;
            ShowAccountFields = Visibility.Hidden;

            ShowUsernameTextbox = Visibility.Hidden;
            ShowUsernameSelector = Visibility.Hidden;

            ExistingUsernameClicked = new RelayCommand(ToggleExistingUsername);

            IncreasePasswordLength = new RelayCommand(ToggleIncreasePasswordLength);
            DecreasePasswordLength = new RelayCommand(ToggleDecreasePasswordLength);

            PasswordLength = "8";

            IncreaseMandatorySymbols = new RelayCommand(ToggleIncreaseMandatorySymbols);
            DecreaseMandatorySymbols = new RelayCommand(ToggleDecreaseMandatorySymbols);

            MandatorySymbols = "1";

            GeneratePassword = new RelayCommand(GenerateRandomPassword);
            Save = new RelayCommand(SaveAccount);
        }
        #endregion

        #region methods
        private void OnPropertyChange(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ApplicationTypeChange(object obj)
        {
            if (AppType == ApplicationType.WebSite.ToString())
            {
                WebSiteSelected = Visibility.Visible;
                ShowUsernameTextbox = Visibility.Visible;
                ShowAccountFields = Visibility.Visible;

                ApplicationSelected = Visibility.Hidden;
            }
            else if (AppType == ApplicationType.MobileApplication.ToString() || AppType == ApplicationType.DesktopApplication.ToString())
            {
                ApplicationSelected = Visibility.Visible;
                ShowUsernameTextbox = Visibility.Visible;
                ShowAccountFields = Visibility.Visible;

                WebSiteSelected = Visibility.Hidden;
            }
            else if (AppType == ApplicationType.None.ToString())
            {
                WebSiteSelected = Visibility.Hidden;
                ApplicationSelected = Visibility.Hidden;
                ShowAccountFields = Visibility.Hidden;

                ShowUsernameTextbox = Visibility.Hidden;
                ShowUsernameSelector = Visibility.Hidden;
            }
        }

        private void ToggleExistingUsername(object obj)
        {
            if (isExistingUsernameChecked)
            {
                ShowUsernameTextbox = Visibility.Visible;
                ShowUsernameSelector = Visibility.Hidden;

                isExistingUsernameChecked = false;
            }
            else
            {
                ShowUsernameTextbox = Visibility.Hidden;
                ShowUsernameSelector = Visibility.Visible;

                isExistingUsernameChecked = true;
            }
        }

        private void ToggleIncreasePasswordLength(object obj)
        {
            int numberOfPasswordCharacters = Int32.Parse(PasswordLength);

            numberOfPasswordCharacters++;

            PasswordLength = numberOfPasswordCharacters.ToString();
        }

        private void ToggleDecreasePasswordLength(object obj)
        {
            int numberOfPasswordCharacters = Int32.Parse(PasswordLength);

            numberOfPasswordCharacters--;

            PasswordLength = numberOfPasswordCharacters.ToString();
        }

        private void ToggleIncreaseMandatorySymbols(object obj)
        {
            int numberOfMandatorySymbols = Int32.Parse(MandatorySymbols);

            numberOfMandatorySymbols++;

            MandatorySymbols = numberOfMandatorySymbols.ToString();
        }

        private void ToggleDecreaseMandatorySymbols(object obj)
        {
            int numberOfMandatorySymbols = Int32.Parse(MandatorySymbols);

            numberOfMandatorySymbols--;

            MandatorySymbols = numberOfMandatorySymbols.ToString();
        }

        private void GenerateRandomPassword(object obj)
        {
            var password = _passwordFactory.GeneratePassword(Int32.Parse(PasswordLength), Int32.Parse(MandatorySymbols));

            Password = password;
        }

        private void SaveAccount(object obj)
        {
            bool errorHappened = false;

            try
            {
                VerifyData();

                var accountModel = _accountFactory.PrepareAccountModel(Username, Password);

                var applicationModel = _accountFactory.PrepareApplicationModel(AppType, accountModel, Url, Name, OperatingSystem);

                if(applicationModel.Type == ApplicationType.WebSite)
                {
                    applicationModel.Name = "";
                    applicationModel.OperatingSystem = "";
                }
                else
                {
                    applicationModel.URL = "";
                }

                _accountFactory.AddOrUpdateApplication(applicationModel);
                _accountFactory.SetData();
            }
            catch(Exception e)
            {
                MessageBox.Show("Something happened! Please, try again!");
                errorHappened = true;
            }

            if (!errorHappened)
            {
                MessageBox.Show("Saved succesfully!");
            }
        }

        private void VerifyData()
        {
            if (AppType.Equals("None") || AppType == null)
            {
                MessageBox.Show("Please choose an Application Type!");
            }
            else if (AppType.Equals("WebSite"))
            {
                if (Url == null || Url.Length < 4)
                {
                    MessageBox.Show("URL must be atleast 4 characters long!");
                }
                else
                {

                    string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
                    Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    if (!reg.IsMatch(Url))
                    {
                        MessageBox.Show("Url should be in the correct format!");
                    }
                }

                VerifyAccountData();
            }
            else
            {
                if (Name == null || Name.Length < 3 || OperatingSystem == null || OperatingSystem.Length < 3)
                {
                    MessageBox.Show("Name and OS should be atleast 3 characters long!");
                }

                VerifyAccountData();
            }
        }

        private void VerifyAccountData()
        {
            if (Username == null || Username.Length < 3)
            {
                MessageBox.Show("Username should be atleast 3 characters long!");
            }

            if (Password == null || Password.Length < 1)
            {
                MessageBox.Show("Password should be atleast 1 character long!");
            }
        }
        #endregion
    }
}
