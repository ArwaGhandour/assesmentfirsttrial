using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assesment.Models.Entities
{
    public class Taskk
    {
        public int id {  get; set; }
        [Required]
        public string Title {  get; set; }
        public string Description { get; set; }
        public string statues {  get; set; }
        public string Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectIDD {  get; set; }
        [ForeignKey("ProjectIDD")]
        public Project project { get; set; }
        public int Teammemberidd {  get; set; }
        [ForeignKey("Teammemberidd")]
        public TeamMember teammember { get; set; }
    }
}
