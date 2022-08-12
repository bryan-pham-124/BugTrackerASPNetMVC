namespace BugTrackerMVC.Models
{
    public class MultipleModels
    {
        public IEnumerable<Projects> Projects { get; set; }
        public IEnumerable<Tickets> Tickets { get; set; }
        public IEnumerable<Comments> Comments { get; set; }


        public int FinishedTickets { get; set; }

        public int UnFinishedTickets { get; set; }

        public int PendingTickets { get; set; }


    }
}
