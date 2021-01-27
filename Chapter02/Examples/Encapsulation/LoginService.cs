using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples
{
    public class LoginService
    {
        // Could be a dictionary, but we use a simplified example.
        private string[] _usernames;
        private string[] _passwords;

        public bool Login(string username, string password)
        {
            // Do a password lookup based on username
            bool isLoggedIn = true;
            return isLoggedIn;
        }
    }
}
