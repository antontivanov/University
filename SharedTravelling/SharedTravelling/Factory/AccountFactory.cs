using Newtonsoft.Json;
using SharedTravelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTravelling.Factory
{
    class AccountFactory
    {
        private IList<AccountModel> accountModels;

        public IList<AccountModel> AccountModels
        {
            get
            {
                return accountModels;
            }

            set
            {
                accountModels = value;
            }
        }

        public AccountFactory()
        {
            AccountModels = GetData();
        }

        public bool RegisterUser(string username, string password, DateTime dateOfBirth)
        {
            bool isUsernameFree = CheckUsername(username);

            if (isUsernameFree)
            {
                return false;
            }


            var model = new AccountModel();

            model.Username = username;
            model.Password = password;
            model.DateOfBirth = dateOfBirth;

            model.Cars = new List<CarModel>();
            model.Rating = 0;
            model.Trips = new List<TripModel>();

            AccountModels.Add(model);

            SetData();

            return true;
        }

        private bool CheckUsername(string username)
        {
            var result = AccountModels.Where(x => x.Username.Equals(username)).ToList().Count <= 0;

            return result;
        }

        public IList<AccountModel> GetData()
        {
            var currentProjectDirectory = System.IO.Directory.GetCurrentDirectory();
            var filePath = currentProjectDirectory + @"\data.txt";


            AccountModels = new List<AccountModel>();

            string json = System.IO.File.ReadAllText(filePath);

            if (json != null)
            {
                AccountModels = JsonConvert.DeserializeObject<List<AccountModel>>(json);

                if (AccountModels == null)
                {
                    return new List<AccountModel>();
                }
            }

            return AccountModels;
        }

        public void SetData()
        {
            var currentProjectDirectory = System.IO.Directory.GetCurrentDirectory();
            var filePath = currentProjectDirectory + @"\data.txt";

            string json = JsonConvert.SerializeObject(AccountModels, Formatting.Indented);

            System.IO.File.WriteAllText(filePath, json);
        }

        public void SetUser(string user)
        {
            var currentProjectDirectory = System.IO.Directory.GetCurrentDirectory();
            var filePath = currentProjectDirectory + @"\user.txt";

            System.IO.File.WriteAllText(filePath, user);
        }

        public string GetUser()
        {
            var currentProjectDirectory = System.IO.Directory.GetCurrentDirectory();
            var filePath = currentProjectDirectory + @"\user.txt";            

            string user = System.IO.File.ReadAllText(filePath);

            return user;
        }

        public void AddCarToUser(string username, CarModel car)
        {
            AccountModels = GetData();

            AccountModels.FirstOrDefault(x => x.Username.Equals(username)).Cars.Add(car);

            SetData();
            AccountModels = GetData();
        }

        public void AddTripToUser(string username, TripModel trip)
        {
            AccountModels = GetData();

            AccountModels.FirstOrDefault(x => x.Username.Equals(username)).Trips.Add(trip);

            SetData();
            AccountModels = GetData();
        }
    }
}
