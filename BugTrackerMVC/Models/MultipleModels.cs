namespace BugTrackerMVC.Models
{
    public class MultipleModels
    {
        public IEnumerable<Projects> Projects { get; set; }
        public IEnumerable<Tickets> Tickets { get; set; }

        public IEnumerable<Comments> Comments { get; set; }

    }
}
