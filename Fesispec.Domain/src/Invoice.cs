using System;

namespace Festispec.Domain
{
    public class Invoice
    {
        public  Inspection Inspection { get; set; }
        public Decimal  Cost { get; set; }
        public bool Paid { get; set; }
    }
}