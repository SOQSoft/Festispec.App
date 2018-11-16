using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.Repositories
{
    class RoleRepository:IRoleRepository
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

            //Guus and Darryll will add te proper roles and permission system
            Roles.Add(new Role() { Name = "Role1" });
            Roles.Add(new Role() { Name = "Role2" });
            Roles.Add(new Role() { Name = "Role3" });
        }

        public ICollection<Role> GetAll()
        {
            return Roles;
        }
    }
}
