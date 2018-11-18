using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Festispec.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int UserForeignKey { get; set; }
        public User User { get; set; }
        public List<IllnessReport> IllnessReports { get; set; }

    }
}
