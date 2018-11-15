using System;
using System.Collections.Generic;
using System.Text;

namespace Festispec.Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }

    }
}
