using System;
using System.Collections.Generic;
using System.Text;

namespace Festispec.Domain
{
    public class Employee
    {
        public User User { get; set; }
        public List<IllnessReport> IllnessReports { get; set; }

    }
}
