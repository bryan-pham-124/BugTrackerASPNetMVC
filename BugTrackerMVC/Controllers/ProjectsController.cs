using BugTrackerMVC.Data;
using BugTrackerMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerMVC.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProjectsController(ApplicationDbContext db)
        {
            _db = db;
        }


       
        //Load a list of projects into index view
        public IActionResult Index()
        {


            IEnumerable<Tickets> totalTickets = _db.Tickets.ToList();
            IEnumerable<Projects> totalProjects = _db.Projects.ToList();

            int unfinishedTickets = _db.Tickets.Where(ticket => ticket.Status == "Unfinished").Count();
            int finishedTickets = _db.Tickets.Where(ticket => ticket.Status == "Finished").Count();
            int pendingTickets = _db.Tickets.Where(ticket => ticket.Status == "Pending").Count();


            MultipleModels combinedModel = new MultipleModels();

            combinedModel.Projects = totalProjects;
            combinedModel.Tickets = totalTickets;

            combinedModel.UnFinishedTickets = unfinishedTickets;
            combinedModel.FinishedTickets = finishedTickets;
            combinedModel.PendingTickets = pendingTickets;


            return View(combinedModel);

        }



        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create an entry into a database
        public IActionResult Create(Projects obj)
        {
            if (ModelState.IsValid)
            {
                _db.Projects.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
           
            return View(obj);
           
        }


        //GET

        //Edit an entry into a database
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var cateegoryFromDb = _db.Projects.Find(id);

            if (cateegoryFromDb == null)
            {
                return NotFound();
            }

            return View(cateegoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Projects obj)
        {

            if (ModelState.IsValid)
            {
                _db.Projects.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var projectsFromDb = _db.Projects.Find(id);

            if (projectsFromDb == null)
            {
                return NotFound();
            }

            return View(projectsFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePOST(int? id)
        {


            var obj = _db.Projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Projects.Remove(obj);
            _db.SaveChanges();
            //TempData["success"] = "Category deleted successfully";

            var objTickets = _db.Tickets.Where(ticket => ticket.ProjectId == id).ToList();

            foreach(var ticket in objTickets)
            {
                _db.Tickets.Remove(ticket);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }


    }
}
