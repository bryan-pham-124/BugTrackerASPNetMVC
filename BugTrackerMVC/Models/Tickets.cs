using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BugTrackerMVC.Models
{
    public class Tickets
    {


        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

 

        [Required]

        public string TicketTitle { get; set; }

        [Required]

        public string Description { get; set; }


        [Required]

        public string Status { get; set; }

        [Required]

        public string Priority { get; set; }


        [Required]

        public string Type { get; set; }


    }

    /* Table categories
     *
     * TicketTitle
     * Author
     * Description
     * status
     * priority
     * type
     */
}
