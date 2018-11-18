using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec.Domain
{
    public class Role
    {
        [Key]
        public string Name { get { return Roles.ToString(); } set { Roles = value.ToRoles(); } }

        public Role(Roles role)
        {
            Roles = role;
        }

        public Role() { }

        [NotMapped]
        public Roles Roles { get; set; } = Roles.User;

    }
}