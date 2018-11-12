using System.Collections.Generic;
using Festispec.Database.Models;

namespace Festispec.App.Repositories
{
    public interface IFormsRepository
    {
        void Add(Form form);
        void Delete(Form form);
        void Update(Form form);
        ICollection<Form> GetAll();
    }
}