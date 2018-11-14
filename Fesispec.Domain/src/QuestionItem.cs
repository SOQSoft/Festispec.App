using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Festispec.Database.Models
{
    public partial class QuestionItem
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public int? QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
