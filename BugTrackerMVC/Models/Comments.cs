using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerMVC.Models
{
    public class Comments
    {



        [Key]
        public int Id { get; set; }

       
        public string User{ get; set; }


        public int TicketId { get; set; }


        [Required]
        public string Description { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;




    }
}
