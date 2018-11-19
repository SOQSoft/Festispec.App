using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Festispec.Domain;

namespace Festispec.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }
        public int? FormId { get; set; }
        public int OrderNr { get; set; }
        public Form Form { get; set; }
        public ICollection<QuestionItem> QuestionItem { get; set; } = new List<QuestionItem>();
    }
}
