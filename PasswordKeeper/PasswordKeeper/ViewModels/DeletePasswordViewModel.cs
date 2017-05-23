using PasswordKeeper.Commands;
using PasswordKeeper.Entities;
using PasswordKeeper.Enums;
using PasswordKeeper.Models;
using PasswordKeeper.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PasswordKeeper.ViewModels
{
    class DeletePasswordViewModel : INotifyPropertyChanged
    {
        #region fields
        private Visibility isTypeApp;
        private Visibility isTypeWebsite;
        private Visibility showViewButton;
        private Visibility showAccountFields;

        private AccountFactory _accountFactory;

        private string appType;
        private IList<string> application;
        private string selectedApplication;
        private string selectedApplicationName;
        private IList<ApplicationModel> applicationsToShow;
        private IList<string> account;
        private string selectedAccountUsername;

        private ICommand view;
        private List<ViewPasswordModel> filteredAccounts;

        private ICommand deleteAllButton;
        private ICommand deleteSelectedButton;
        #endregion

        #region properties
        public Visibility IsTypeApp
        {
            get
            {
                return isTypeApp;
            }

            set
            {
                isTypeApp = value;
                OnPropertyChange("IsTypeApp");
            }
        }
        public Visibility IsTypeWebsite
        {
            get
            {
                return isTypeWebsite;
            }

            set
            {
                isTypeWebsite = value;
                OnPropertyChange("IsTypeWebsite");
            }
        }
        public Visibility ShowViewButton
        {
            get
            {
                return showViewButton;
            }

            set
            {
                showViewButton = value;
                OnPropertyChange("ShowViewButton");
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

                _accountFactory.ApplicationModels = _accountFactory.GetData();
                ApplicationTypeChange(null);

                applicationsToShow = _accountFactory.ApplicationModels.Where(x => x.Type.ToString().Equals(AppType)).ToList();

                Application = new List<string>();

                ApplicationType applicationType;
                ApplicationType.TryParse(value, out applicationType);

                PopulateApplication(applicationType);

            }
        }
        public IList<string> Application
        {
            get
            {
                return application;
            }

            set
            {
                application = value;

                OnPropertyChange("Application");
            }
        }
        public string SelectedApplication
        {
            get
            {
                return selectedApplication;
            }

            set
            {
                selectedApplication = value;

                OnPropertyChange("SelectedApplication");

                Account = new List<string>();

                ShowAccountFields = Visibility.Visible;

                OnSelectedUrlChange(SelectedApplication);
            }
        }
        public string SelectedApplicationName
        {
            get
            {
                return selectedApplicationName;
            }

            set
            {
                selectedApplicationName = value;

                OnPropertyChange("SelectedApplicationName");

                Account = new List<string>();

                ShowAccountFields = Visibility.Visible;

                OnSelectedNameChange(SelectedApplicationName);
            }
        }
        public IList<string> Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;

                OnPropertyChange("Account");
            }
        }
        public string SelectedAccountUsername
        {
            get
            {
                return selectedAccountUsername;
            }

            set
            {
                selectedAccountUsername = value;

                OnPropertyChange("SelectedAccountUsername");
            }
        }

        public ICommand View
        {
            get
            {
                return view;
            }

            private set
            {
                view = value;
            }
        }
        public List<ViewPasswordModel> FilteredAccounts
        {
            get
            {
                return filteredAccounts;
            }

            set
            {
                filteredAccounts = value;

                OnPropertyChange("FilteredAccounts");
            }
        }
        
        public ICommand DeleteAllButton
        {
            get
            {
                return deleteAllButton;
            }

            private set
            {
                deleteAllButton = value;
            }
        }
        public ICommand DeleteSelectedButton
        {
            get
            {
                return deleteSelectedButton;
            }

            private set
            {
                deleteSelectedButton = value;
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region ctor
        public DeletePasswordViewModel()
        {            
            _accountFactory = new AccountFactory();

            View = new RelayCommand(ViewAccounts);

            IsTypeApp = Visibility.Hidden;
            IsTypeWebsite = Visibility.Hidden;
            ShowViewButton = Visibility.Hidden;
            ShowAccountFields = Visibility.Hidden;

            DeleteAllButton = new RelayCommand(DeleteAll);
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
                IsTypeApp = Visibility.Hidden;

                IsTypeWebsite = Visibility.Visible;
                ShowViewButton = Visibility.Visible;
                ShowAccountFields = Visibility.Hidden;
            }
            else if (AppType == ApplicationType.MobileApplication.ToString() || AppType == ApplicationType.DesktopApplication.ToString())
            {
                IsTypeWebsite = Visibility.Hidden;

                IsTypeApp = Visibility.Visible;
                ShowViewButton = Visibility.Visible;
                ShowAccountFields = Visibility.Hidden;
            }
            else if (AppType == ApplicationType.None.ToString())
            {
                IsTypeApp = Visibility.Hidden;
                IsTypeWebsite = Visibility.Hidden;
                ShowViewButton = Visibility.Hidden;
                ShowAccountFields = Visibility.Hidden;
            }
        }

        private void PopulateApplication(ApplicationType appType)
        {
            IList<string> applicationNames = new List<string>();

            if (appType == ApplicationType.WebSite)
            {
                foreach (var app in applicationsToShow)
                {
                    applicationNames.Add(app.URL);
                }
            }
            else
            {
                foreach (var app in applicationsToShow)
                {
                    applicationNames.Add(app.Name);
                }
            }

            Application = applicationNames;
        }

        private void OnSelectedUrlChange(string url)
        {
            if (Application.Count == 0)
            {
                ShowAccountFields = Visibility.Hidden;
                return;
            }

            IList<string> accountNames = new List<string>();

            var accountsToShow = _accountFactory.ApplicationModels.FirstOrDefault(x => x.Type.ToString().Equals(AppType) && x.URL.Equals(url)).Accounts;

            foreach (var account in accountsToShow)
            {
                accountNames.Add(account.Username);
            }

            Account = accountNames;
        }

        private void OnSelectedNameChange(string name)
        {
            if (Application.Count == 0)
            {
                ShowAccountFields = Visibility.Hidden;
                return;
            }

            IList<string> accountNames = new List<string>();

            var accountsToShow = _accountFactory.ApplicationModels.FirstOrDefault(x => x.Type.ToString().Equals(AppType) && x.Name.Equals(name)).Accounts;

            foreach (var account in accountsToShow)
            {
                accountNames.Add(account.Username);
            }

            Account = accountNames;
        }

        private void ViewAccounts(object obj)
        {
            var accounts = new List<ViewPasswordModel>();

            ApplicationType filteredApplicationType;
            ApplicationType.TryParse(AppType, out filteredApplicationType);

            IList<ApplicationModel> filteredApplication = _accountFactory.ApplicationModels;

            if (filteredApplicationType == ApplicationType.WebSite)
            {
                if (AppType != null || !AppType.Equals(""))
                {
                    filteredApplication = filteredApplication.Where(x => x.Type == filteredApplicationType).ToList();
                }

                if (SelectedApplication != null)
                {
                    if (!SelectedApplication.Equals(""))
                    {
                        filteredApplication = filteredApplication.Where(x => x.URL.Equals(SelectedApplication)).ToList();
                    }
                }
            }
            else
            {
                if (AppType != null || !AppType.Equals(""))
                {
                    filteredApplication = filteredApplication.Where(x => x.Type == filteredApplicationType).ToList();
                }

                if (SelectedApplicationName != null)
                {
                    if (!SelectedApplicationName.Equals(""))
                    {
                        filteredApplication = filteredApplication.Where(x => x.Name.Equals(SelectedApplicationName)).ToList();
                    }
                }
            }

            IList<AccountModel> temporaryAccountList;
            bool shouldShowAllAccounts = true;

            if (SelectedAccountUsername != null)
            {
                if (SelectedAccountUsername.Equals(""))
                {
                    shouldShowAllAccounts = false;

                    foreach (var application in filteredApplication)
                    {
                        temporaryAccountList = application.Accounts.Where(x => x.Username.Equals(SelectedAccountUsername)).ToList();

                        foreach (var account in temporaryAccountList)
                        {
                            var accountToShowInList = new ViewPasswordModel();

                            accountToShowInList.Username = account.Username;
                            accountToShowInList.Password = account.Password;
                            accountToShowInList.OperatingSystem = application.OperatingSystem;

                            accounts.Add(accountToShowInList);
                        }
                    }
                }
            }

            if (shouldShowAllAccounts)
            {
                foreach (var application in filteredApplication)
                {
                    temporaryAccountList = application.Accounts;

                    foreach (var account in temporaryAccountList)
                    {
                        var accountToShowInList = new ViewPasswordModel();

                        accountToShowInList.Username = account.Username;
                        accountToShowInList.Password = account.Password;
                        accountToShowInList.OperatingSystem = application.OperatingSystem;

                        accounts.Add(accountToShowInList);
                    }
                }
            }

            FilteredAccounts = accounts;
        }

        private void Delete(string operatingSystem, string username)
        {
            try
            {
                var selectedApplication = _accountFactory.ApplicationModels.FirstOrDefault(x => x.OperatingSystem.Equals(operatingSystem));

                var selectedAccount = selectedApplication.Accounts.FirstOrDefault(x => x.Username.Equals(username));

                _accountFactory.ApplicationModels.Remove(selectedApplication);
                selectedApplication.Accounts.Remove(selectedAccount);

                if (selectedApplication.Accounts.Count > 0)
                {
                    _accountFactory.ApplicationModels.Add(selectedApplication);
                }

                _accountFactory.SetData();

                _accountFactory.ApplicationModels = _accountFactory.GetData();


                MessageBox.Show("Deleted accounts successfuly!");
            }
            catch(Exception e)
            {
                MessageBox.Show("Something Happened! Please try again!");
            }
        }

        private void DeleteAll(object obj)
        {
            foreach(var account in FilteredAccounts)
            {
                Delete(account.OperatingSystem, account.Username);
            }
        }
        #endregion
    }
}
