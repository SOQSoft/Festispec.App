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
        public UserTestRepository()
        {
            InitialiseDate();
        }

        public void InitialiseDate()
        {
            User user = new User();
            user.Password = "test";
            user.Username = "test1";
            user.Role = new Role();
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
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            var u = Users.FirstOrDefault(o => o.Username == user.Username);
            u = user;
        }
    }
}
