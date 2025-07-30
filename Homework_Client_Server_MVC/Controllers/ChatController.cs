using Microsoft.AspNetCore.Mvc;

namespace Homework_Client_Server_MVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index(string username)
        {
            ViewBag.Username = username;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            return RedirectToAction("Index", new { username = username });      //returns to the Index action with the username as a parameter
        }
    }
}
