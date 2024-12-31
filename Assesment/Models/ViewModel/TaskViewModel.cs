using Assesment.Models.Entities;

namespace Assesment.Models.ViewModel
{
    public class TaskViewModel
    {
        public int tvmId { get; set; }
        public int projectidd {  get; set; }
        public IEnumerable<Project>projects { get; set; }
        public int teammembIDD {  get; set; }
        public IEnumerable<TeamMember> teammembers { get; set; }
        public string title {  get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }

    }
}
