using BugTrackerMVC.Data;
using BugTrackerMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerMVC.Controllers
{



    public class TicketsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public TicketsController(ApplicationDbContext db)
        {
            _db = db;
             
        }


        //GET
        public IActionResult Index(int? id)
        {


          
            IEnumerable<Tickets> filteredTickets = _db.Tickets.Where(ticket => ticket.ProjectId == id).ToList();
            IEnumerable<Projects> filteredProjects = _db.Projects.Where(project => project.Id == id).ToList();

            MultipleModels combinedModel = new MultipleModels();

            combinedModel.Projects = filteredProjects;
            combinedModel.Tickets = filteredTickets;

            return View(combinedModel);
            //return View(ticketList);
        }



        //GET
        public IActionResult IndexProjectName(string projectName)
        {

            IEnumerable<Tickets> filteredTickets = _db.Tickets.Where(ticket => ticket.ProjectName == projectName).ToList();
            IEnumerable<Projects> filteredProjects = _db.Projects.Where(project => project.ProjectName == projectName).ToList();

            MultipleModels combinedModel = new MultipleModels();

            combinedModel.Projects = filteredProjects;
            combinedModel.Tickets = filteredTickets;

            return View(combinedModel);
            //return View(ticketList);
        }


        //GET

   
        public IActionResult Create(int? projectId)
        {

            return View(_db.Tickets.Where(ticket => ticket.ProjectId == projectId).First());
        }
       



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Tickets obj, int? projectId)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new { id = projectId });
                //return View(obj);
            }

            return View(obj);

        }




    }
}
