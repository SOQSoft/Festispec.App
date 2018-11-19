using System.ComponentModel.DataAnnotations;

namespace Festispec.Domain
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}