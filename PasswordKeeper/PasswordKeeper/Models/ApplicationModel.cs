using System.Collections.Generic;
using PasswordKeeper.Enums;
using PasswordKeeper.Entities;

namespace PasswordKeeper.Models
{
    class ApplicationModel
    {
        public ApplicationModel()
        {
            Accounts = new List<AccountModel>();
        }

        public ApplicationType Type { get; set; }

        public string URL { get; set; }

        public string Name { get; set; }

        public string OperatingSystem { get; set; }

        public IList<AccountModel> Accounts { get; set; }
    }
}
