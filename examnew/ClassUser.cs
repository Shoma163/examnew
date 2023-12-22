using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examnew
{
    public class ClassUser
    {
        public ClassUser() { }
        public ClassUser(int id, string login, string password, string firstName, string lastName, string patronymic, string role)
        {
            Id = id;
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Role = role;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
    }
}
