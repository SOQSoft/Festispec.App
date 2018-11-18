using System;
using System.Collections.Generic;
using System.Text;

namespace Festispec.Domain
{
    public enum Roles
    {
        User,
        Admin,
    }

    public static class RolesExtention
    {
        public static Roles ToRoles(this string role)
        {
            return (Roles)Enum.Parse(typeof(Roles), role);
        }

        public static Role ToRole(this Roles role)
        {
            return new Role(role);
        }

    }
}
