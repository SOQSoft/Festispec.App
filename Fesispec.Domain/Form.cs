using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Festispec.Domain
{
    public partial class Form
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTemplate { get; set; }
        public string Comments { get; set; }
		public ICollection<Question> Question { get; set; } = new List<Question>();
    }
}
