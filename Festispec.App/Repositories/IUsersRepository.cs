using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festispec.Domain;

namespace Festispec.App.Repositories
{
    public interface IUsersRepository
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        ICollection<User> GetAll();
    }
}
