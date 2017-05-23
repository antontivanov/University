using System.Web.Security;

namespace PasswordKeeper.Factories
{
    class PasswordFactory
    {
        public PasswordFactory()
        {

        }

        public string GeneratePassword(int length, int numberOfSpecialCharacters)
        {
            var password = Membership.GeneratePassword(length, numberOfSpecialCharacters);

            return password;
        }
    }
}
