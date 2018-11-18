using System.Collections.Generic;
using Festispec.Domain;

namespace Festispec.App.Repositories
{
    public interface IUsersRepository
    {
        void Add(User user);
        void Delete(User user);
        ICollection<User> GetAll();
        User GetUser(string username, string password);
        void InitialiseDate();
        void Update(User user);
    }
}