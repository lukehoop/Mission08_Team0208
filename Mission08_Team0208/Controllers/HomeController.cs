using Microsoft.AspNetCore.Mvc;
using Mission08_Team0208.Models;
using System.Diagnostics;

namespace Mission08_Team0208.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult AddEdit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = _repo.Tasks
            .FirstOrDefault(t => t.TaskId == id);

            if (task != null)
            {
                task.Completed = true;
                _repo.SaveChanges();
            }

            return RedirectToAction("Quadrants");
        }
    }
}
