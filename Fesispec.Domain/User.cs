using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Festispec.Domain
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }

    }
}
