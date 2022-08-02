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
        public IActionResult Create(int projectId)
        {


            IEnumerable<Tickets> filteredProjects = _db.Tickets.Where(ticket => ticket.ProjectId == projectId).ToList();

            if(filteredProjects.Any())
            {
                return View(filteredProjects.First());
            }

            Tickets defaultTicket = new Tickets();
            defaultTicket.ProjectId = projectId;
           
            return View(defaultTicket);

            

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



        //GET
        public IActionResult Edit(int? ticketId)
        {
            if (ticketId == null || ticketId == 0)
            {
                return NotFound();
            }

            var ticketFromDb = _db.Tickets.Find(ticketId);

            if (ticketFromDb == null)
            {
                return NotFound();
            }

            return View(ticketFromDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Tickets obj, int? projectId, int ticketId)
        {

            obj.Id = ticketId;

            if (ModelState.IsValid)
            {
                _db.Tickets.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index", new { id = projectId });
            }

            return View(obj);
        }



        //DELETE
        //GET
        public IActionResult Delete(int? ticketId)
        {
            if (ticketId == null || ticketId == 0)
            {
                return NotFound();
            }

            //var ticketFromDb = _db.Tickets.Where(ticket => ticket.Id == ticketId).First();

            var ticketFromDb = _db.Tickets.Find(ticketId);


            if (ticketFromDb == null)
            {
                return NotFound();
            }

            return View(ticketFromDb);
        }



        //POST
        [HttpPost, ActionName("Delete")]
       
        [ValidateAntiForgeryToken]

        public IActionResult DeleteTicket(int? projectId, int? ticketId)
        {


            var obj = _db.Tickets.Find(ticketId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Tickets.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = projectId });



        }


    }
}
