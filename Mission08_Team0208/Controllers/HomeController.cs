using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0208.Models;
using System.Diagnostics;

namespace Mission08_Team0208.Controllers
{
    public class HomeController : Controller
    {
        // Repository for database operations (Repository Pattern)
        private readonly ITaskRepository _repo;

        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // Default: redirect to Quadrants view
        public IActionResult Index()
        {
            return RedirectToAction("Quadrants");
        }

        // Quadrants view: list all incomplete tasks in four quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repo.GetAllTasks();
            return View(tasks);
        }

        // Add new task (GET)
        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "CategoryId", "CategoryName");
            return View(new Mission08_Team0208.Models.Task());
        }

        // Edit existing task (GET) - reuse AddEdit view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null)
                return RedirectToAction("Quadrants");
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "CategoryId", "CategoryName");
            return View("AddEdit", task);
        }

        // Save task (POST) - add or update
        [HttpPost]
        public IActionResult AddEdit(Mission08_Team0208.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                    _repo.AddTask(task);
                else
                    _repo.UpdateTask(task);
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "CategoryId", "CategoryName");
            return View(task);
        }

        // Confirm delete (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null)
                return RedirectToAction("Quadrants");
            return View(task);
        }

        // Delete task (POST)
        [HttpPost]
        public IActionResult Delete(Mission08_Team0208.Models.Task task)
        {
            _repo.DeleteTask(task.TaskId);
            return RedirectToAction("Quadrants");
        }

        // Mark task as completed (POST)
        [HttpPost]
        public IActionResult Complete(int id)
        {
            _repo.MarkCompleted(id);
            return RedirectToAction("Quadrants");
        }

        // Error page for non-development exception handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
