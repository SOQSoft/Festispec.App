using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain;

namespace Festispec.App.Repositories
{
    public class UserTestRepository : IUsersRepository
    {
        private static List<User> Users { get; set; } = new List<User>();
        private static bool init = false;

        public UserTestRepository()
        {
            InitialiseDate();
        }

        public void InitialiseDate()
        {
            if (init) { return; }
            else { init = true; }

            var adminRole = Roles.Admin.ToRole();
            var userRole = Roles.User.ToRole();


            User user = new User();
            user.Password = "Admin";
            user.Username = "Admin";
            user.Role = adminRole;
            user.Employee = new Employee();
            Users.Add(user);

            user = new User();
            user.Password = "User";
            user.Username = "User";
            user.Role = userRole;
            user.Employee = new Employee();
            Users.Add(user);

            user = new User();
            user.Password = "abcd";
            user.Username = "test2";
            user.Role = new Role();
            user.Employee = new Employee();
            Users.Add(user);

            user = new User();
            user.Password = "welkom1";
            user.Username = "test3";
            user.Role = new Role();
            user.Employee = new Employee();
            Users.Add(user);
        }

        public User GetUser(string username, string password)
        {
            return Users.FirstOrDefault(o => o.Username == username && o.Password == password);
        }
        public void Add(User user)
        {
            Users.Add(user);
        }

        public void Delete(User user)
        {
            Users.Remove(user);
        }

        public ICollection<User> GetAll()
        {
            ICollection<User> result = Users;
            return result;
        }

        public void Update(User user)
        {
            var u = Users.FirstOrDefault(o => o.Username == user.Username);
            u = user;
        }
    }
}
