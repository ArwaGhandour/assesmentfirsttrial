using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public IEnumerable<Taskk> Tasks { get; set; }
    }
}
