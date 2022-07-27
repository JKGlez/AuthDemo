using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthDemoServer.Models
{
    public class User
    {
        //Definition of fields for the model class
        private int id;
        private string name;
        private string email;
        private string password;
        private string roleDescription;
        private int role;

        ////Deefenition of the properties (get and set)
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string RoleDescription { get => roleDescription; set => roleDescription = value; }
        public int Role { get => role; set => role = value; }

        public User(int id, string name, string email, string password, string roleDescription)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.RoleDescription = roleDescription;
        }

        public User(int id, string name, string email, string password, int role)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role= role;
        }
    }
}