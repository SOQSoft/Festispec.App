using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.Repositories
{
    class RoleRepository
    {
        private static List<Role> Roles { get; set; } = new List<Role>();
        private static bool init = false;

        public RoleRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            if (init) { return; }
            else { init = true; }

            //TODO: 
        }

        public ICollection<Role> GetAll()
        {
            return Roles;
        }
    }
}
