using System;

namespace Festispec.Domain
{
    public class Inspection
    {
        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }
    }
}
