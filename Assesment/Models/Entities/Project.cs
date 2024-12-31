using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public IEnumerable<Taskk> Tasks { get; set; }
    }
}
