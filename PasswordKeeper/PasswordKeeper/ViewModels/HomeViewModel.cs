using System.ComponentModel;
using PasswordKeeper.Enums;
using System.Windows.Input;
using PasswordKeeper.Commands;
using System.Windows;

namespace PasswordKeeper.ViewModels
{
    public class HomeViewModel :INotifyPropertyChanged
    {
        #region fields
        private Visibility showCreateNewPassword;
        private Visibility showViewPasswords;
        private Visibility showDeletePassword;
        private Visibility showSettings;

        private ICommand isCreateNewPasswordChosen;
        private ICommand isViewPasswordsChosen;
        private ICommand isShowDeletePasswordChosen;
        private ICommand isShowSettingsChosen;

        private bool canExecute = true;
        private PageType pageType;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region properties
        public Visibility ShowCreateNewPassword
        {
            get
            {
                return this.showCreateNewPassword;
            }
            set
            {
                this.showCreateNewPassword = value;

                OnPropertyChange("ShowCreateNewPassword");
            }
        }
        public Visibility ShowViewPasswords
        {
            get
            {
                return this.showViewPasswords;
            }
            set
            {
                this.showViewPasswords = value;

                OnPropertyChange("ShowViewPasswords");
            }
        }        
        public Visibility ShowDeletePasswords
        {
            get
            {
                return this.showDeletePassword;
            }
            set
            {
                this.showDeletePassword = value;

                OnPropertyChange("ShowDeletePasswords");
            }
        }
        public Visibility ShowSettings
        {
            get
            {
                return this.showSettings;
            }
            set
            {
                this.showSettings = value;

                OnPropertyChange("ShowSettings");
            }
        }

        public ICommand IsCreateNewPasswordChosen
        {
            get
            {
                return this.isCreateNewPasswordChosen;
            }
            private set
            {
                this.isCreateNewPasswordChosen = value;
            }
        }
        public ICommand IsViewPasswordsChosen
        {
            get
            {
                return this.isViewPasswordsChosen;
            }
            private set
            {
                this.isViewPasswordsChosen = value;
            }
        }
        public ICommand IsShowDeletePasswordChosen
        {
            get
            {
                return this.isShowDeletePasswordChosen;
            }
            private set
            {
                this.isShowDeletePasswordChosen = value;
            }
        }
        public ICommand IsShowSettingsChosen
        {
            get
            {
                return this.isShowSettingsChosen;
            }
            private set
            {
                this.isShowSettingsChosen = value;
            }
        }

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }
        #endregion

        #region ctor
        public HomeViewModel()
        {
            ShowCreateNewPassword = Visibility.Collapsed;
            ShowViewPasswords = Visibility.Hidden;
            ShowDeletePasswords = Visibility.Hidden;
            ShowSettings = Visibility.Hidden;

            IsCreateNewPasswordChosen = new RelayCommand(ShowCreateNewPasswordInMainPanel);
            IsViewPasswordsChosen = new RelayCommand(ShowViewPasswordsInMainPanel);
            IsShowDeletePasswordChosen = new RelayCommand(ShowDeletePasswordInMainPanel);
            IsShowSettingsChosen = new RelayCommand(ShowSettingsInMainPanel);
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
        
        public void ShowCreateNewPasswordInMainPanel(object obj)
        {
            ShowCreateNewPassword = Visibility.Hidden;
            ShowViewPasswords = Visibility.Hidden;
            ShowDeletePasswords = Visibility.Hidden;
            ShowSettings = Visibility.Hidden;

            ShowCreateNewPassword = Visibility.Visible;
        }

        public void ShowViewPasswordsInMainPanel(object obj)
        {
            ShowCreateNewPassword = Visibility.Hidden;
            ShowViewPasswords = Visibility.Hidden;
            ShowDeletePasswords = Visibility.Hidden;
            ShowSettings = Visibility.Hidden;

            ShowViewPasswords = Visibility.Visible;
        }

        public void ShowDeletePasswordInMainPanel(object obj)
        {
            ShowCreateNewPassword = Visibility.Hidden;
            ShowViewPasswords = Visibility.Hidden;
            ShowDeletePasswords = Visibility.Hidden;
            ShowSettings = Visibility.Hidden;

            ShowDeletePasswords = Visibility.Visible;
        }

        public void ShowSettingsInMainPanel(object obj)
        {
            ShowCreateNewPassword = Visibility.Hidden;
            ShowViewPasswords = Visibility.Hidden;
            ShowDeletePasswords = Visibility.Hidden;
            ShowSettings = Visibility.Hidden;

            ShowSettings = Visibility.Visible;
        }
        #endregion
    }
}