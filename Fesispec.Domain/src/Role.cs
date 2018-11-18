using System.ComponentModel.DataAnnotations;

namespace Festispec.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}