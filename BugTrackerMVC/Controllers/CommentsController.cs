using BugTrackerMVC.Data;
using BugTrackerMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerMVC.Controllers
{
    public class CommentsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CommentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {

            IEnumerable<Tickets> filteredTickets = _db.Tickets.Where(ticket => ticket.Id == id).ToList();
            IEnumerable<Comments> filteredComments = _db.Comments.Where(comment => comment.TicketId == id).ToList();

            MultipleModels combinedModel = new MultipleModels();

            combinedModel.Comments = filteredComments;
            combinedModel.Tickets = filteredTickets;

            return View(combinedModel);


        }


        //GET
        public IActionResult Create(int ticketId)   
        {


            IEnumerable<Comments> filteredTickets = _db.Comments.Where(comment => comment.TicketId == ticketId).ToList();

            if (filteredTickets.Any())
            {
                return View(filteredTickets.First());
            }

            Comments defaultComment = new Comments();
            defaultComment.TicketId = ticketId;

            return View(defaultComment);


        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Comments obj, int? ticketId)
        {
            if (ModelState.IsValid)
            {
                _db.Comments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new { id = ticketId });
                //return View(obj);
            }

            return View(obj);

        }



    }
}
