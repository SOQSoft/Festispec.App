using System;

namespace Festispec.Domain
{
    public class IllnessReport
    {
        public int Id { get; set; }
        public DateTime IllDateTime { get; set; } = DateTime.Now;
        public DateTime BetterDateTime { get; set; } 
        public Employee Employee { get; set; }

    }
}