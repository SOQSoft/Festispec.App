using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festispec.App.ViewModels
{
    public class IllnessReportViewModel
    {
        public DateTime IllDateTime { get; set; } = DateTime.Now;
        public DateTime BetterDateTime { get; set; }
        public Employee Employee { get; set; }
    }
}
