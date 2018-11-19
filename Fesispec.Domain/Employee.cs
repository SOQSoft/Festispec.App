using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Festispec.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public char HouseNumberSuffix { get; set; }
        public List<IllnessReport> IllnessReports { get; set; }

    }
}
