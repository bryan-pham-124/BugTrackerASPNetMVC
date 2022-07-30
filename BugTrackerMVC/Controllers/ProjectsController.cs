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
            IEnumerable<Projects> projectList = _db.Projects;
            return View(projectList);
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
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
