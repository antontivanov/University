using PasswordKeeper.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordKeeper.ViewModels
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        #region fields
        private string path;
        private ICommand save;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region properties
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;

                OnPropertyChange("Path");
            }
        }
        public ICommand Save
        {
            get
            {
                return save;
            }

            set
            {
                save = value;
            }
        }
        #endregion

        #region ctor
        public SettingsViewModel()
        {
            Save = new RelayCommand(SaveSettings);
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

        private void SaveSettings(object obj)
        {            
            string filePath = System.IO.Directory.GetCurrentDirectory() + @"\settings.txt";

            var fileExists = File.Exists(Path);

            if (fileExists)
            {
                System.IO.File.WriteAllText(filePath, Path);
            }
            else
            {
                MessageBox.Show("File doesn't exists!");
            }
        }
        #endregion
    }
}
