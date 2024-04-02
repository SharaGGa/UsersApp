using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UsersApp
{
    class User
    {
        public int id {  get; set; }
        private string login, pass, email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }
        public User() { }
        public User(string login, string password, string email)
        {
            this.login = login;
            this.pass = password;
            this.email = email;
        }
        public override string ToString()
        {
            return "льзователь: " + login + ". Email: " + Email;
        }
    }
}
