using BugTrackerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerMVC.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Projects> Projects { get; set; }


        public DbSet<Tickets> Tickets { get; set; }
        

        public DbSet<Comments> Comments { get; set; }


    }
}
