﻿// Used in pseudo-code example.
#pragma warning disable CS0169
namespace Chapter02.Examples.Encapsulation
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
