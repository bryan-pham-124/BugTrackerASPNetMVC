using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerMVC.Models
{


    public class Projects
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Project Name")]

        public string ProjectName { get; set; }

        [Required]
      
        public string Description { get; set; }

        [Required]
        [DisplayName("Team Members")]

        public string TeamMembers { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public int UnsolvedTicketCount { get; set; }


    }
}
