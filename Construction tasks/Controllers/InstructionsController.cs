using Construction_tasks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Construction_tasks.Controllers
{
    public class InstructionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
