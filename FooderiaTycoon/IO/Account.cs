using System;
using System.Net.Mail;

namespace FooderiaTycoon
{
    public class Account
    {
        private byte _passwordToScramble;
        private string _name;
        private int _id;
        private byte _mailAddressToScramble;
        private bool _loggedIn;
        
        public Account(string username, string password)
        {
            throw new NotImplementedException();
        }
        
        public string Name => _name;
        public bool IsLoggedIn => _loggedIn;

        private byte TextToBinary(string input)
        {
            throw new NotImplementedException();
        }

        private void CreateAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int PasswordStrength(string password)
        {
            throw new NotImplementedException();
        }

        private string GetUserName()
        {
            throw new NotImplementedException();
        }

        private void SetNewUserName()
        {
            throw new NotImplementedException();
        }

        private bool LogIn(int hash)
        {
            throw new NotImplementedException();
        }

        private bool Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}