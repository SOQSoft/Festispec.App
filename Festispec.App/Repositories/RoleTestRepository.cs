using Festispec.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.Repositories
{
    public class RoleTestRepository:IRoleRepository
    {
        private static List<Role> Roles { get; set; } = new List<Role>();
        private static bool init = false;

        public RoleTestRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            if (init) { return; }
            else { init = true; }

            foreach (Roles role in (Roles[])Enum.GetValues(typeof(Roles)))
            {
                Roles.Add(role.ToRole());
            }
        }

        public ICollection<Role> GetAll()
        {
            return Roles;
        }
    }
}
