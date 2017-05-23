using Newtonsoft.Json;
using PasswordKeeper.Entities;
using PasswordKeeper.Enums;
using PasswordKeeper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Services
{
    class AccountFactory
    {
        private string currentProjectDirectory;
        private IList<ApplicationModel> applicationModels;

        public AccountFactory()
        {
            currentProjectDirectory = System.IO.Directory.GetCurrentDirectory();

            ApplicationModels = GetData();
        }

        public IList<ApplicationModel> ApplicationModels
        {
            get
            {
                return applicationModels;
            }

            set
            {
                applicationModels = value;
            }
        }

        #region methods
        public ApplicationModel PrepareApplicationModel(string applicationType, AccountModel account, string url, string name, string operatingSystem)
        {
            var model = new ApplicationModel();

            ApplicationType appType;
            ApplicationType.TryParse(applicationType, out appType);

            model.Type = appType;

            if (applicationType.Equals(ApplicationType.None.ToString()))
            {
                throw new ArgumentException("Application cannot be of type None!");
            }
            else if(applicationType.Equals(ApplicationType.WebSite.ToString()))
            {
                model.URL = url;
                model.Accounts.Add(account);
            }
            else
            {
                model.Name = name;
                model.OperatingSystem = operatingSystem;
                model.Accounts.Add(account);
            }            
            
            return model;
        }

        public AccountModel PrepareAccountModel(string username, string password)
        {
            var model = new AccountModel();

            model.Username = username;
            model.Password = password;
            
            return model;
        }

        public void SetData()
        {
            string filePath = GetPath();

            if (filePath == "")
            {
                filePath = currentProjectDirectory + @"\data.txt";
            }

            string json = JsonConvert.SerializeObject(ApplicationModels, Formatting.Indented);

            System.IO.File.WriteAllText(filePath, json);
        }

        public void AddOrUpdateApplication(ApplicationModel application)
        {
            if (application.Type == ApplicationType.WebSite)
            {

                var currentApplication = ApplicationModels.FirstOrDefault(x => x.URL.Equals(application.URL));

                if(currentApplication != null)
                {
                    var currentAccount = currentApplication.Accounts.FirstOrDefault(x => x.Username.Equals(application.Accounts[0].Username));

                    if(currentAccount != null)
                    {
                        currentApplication.Accounts.Remove(currentAccount);                        
                        ApplicationModels.Remove(currentApplication);

                        currentApplication.Accounts.Add(application.Accounts[0]);
                        ApplicationModels.Add(currentApplication);
                    }
                    else
                    {
                        ApplicationModels.Remove(currentApplication);

                        currentApplication.Accounts.Add(application.Accounts[0]);
                        ApplicationModels.Add(currentApplication);
                    }
                }
                else
                {
                    ApplicationModels.Add(application);
                }
            }
            else
            {
                var currentApplication = ApplicationModels.FirstOrDefault(x => x.Name.Equals(application.Name) && x.OperatingSystem.Equals(application.OperatingSystem) && x.Type == application.Type);

                if (currentApplication != null)
                {
                    var currentAccount = currentApplication.Accounts.FirstOrDefault(x => x.Username.Equals(application.Accounts[0].Username));

                    if (currentAccount != null)
                    {
                        currentApplication.Accounts.Remove(currentAccount);
                        ApplicationModels.Remove(currentApplication);

                        currentApplication.Accounts.Add(application.Accounts[0]);
                        ApplicationModels.Add(currentApplication);
                    }
                    else
                    {
                        ApplicationModels.Remove(currentApplication);

                        currentApplication.Accounts.Add(application.Accounts[0]);
                        ApplicationModels.Add(currentApplication);
                    }
                }
                else
                {
                    ApplicationModels.Add(application);
                }
            }
        }

        public IList<ApplicationModel> GetData()
        {
            string filePath = GetPath();

            if (filePath == "")
            {
                filePath = currentProjectDirectory + @"\data.txt";
            }

            string json = System.IO.File.ReadAllText(filePath);

            if(json == null)
            {
                ApplicationModels = new List<ApplicationModel>();
            }

            ApplicationModels = JsonConvert.DeserializeObject<List<ApplicationModel>>(json);

            if(ApplicationModels == null)
            {
                return new List<ApplicationModel>();
            }

            return ApplicationModels;
        }


        private string GetPath()
        {
            string settingsFilePath = currentProjectDirectory + @"\settings.txt";

            string dataFilePath;
            if (File.Exists(settingsFilePath))
            {
                dataFilePath = System.IO.File.ReadAllText(settingsFilePath);
            }
            else
            {

                return "";
            }

            bool fileExists = File.Exists(dataFilePath);
            if (fileExists)
            {
                return dataFilePath;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
