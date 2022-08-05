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




        //GET
        public IActionResult Edit(int?  commentId)
        {
            if (commentId == null || commentId == 0)
            {
                return NotFound();
            }

            var commentFromDb = _db.Comments.Find(commentId);

            if (commentFromDb == null)
            {
                return NotFound();
            }

            return View(commentFromDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Comments obj, int commentId, int ticketId)
        {

            obj.Id = commentId;

            if (ModelState.IsValid)
            {
                _db.Comments.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index", new { id = ticketId });
            }

            return View(obj);
        }



        //GET
        public IActionResult Delete(int? commentId)
        {
            if (commentId == null || commentId == 0)
            {
                return NotFound();
            }

            var commentsFromDb = _db.Comments.Find(commentId);

            if (commentsFromDb == null)
            {
                return NotFound();
            }

            return View(commentsFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteComment(int? commentId, int? ticketId)
        {


            var obj = _db.Comments.Find(commentId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Comments.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", new {id = ticketId});

        }





    }
}
