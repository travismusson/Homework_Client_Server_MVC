using Homework_Client_Server_MVC.Data;
using Homework_Client_Server_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Client_Server_MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(UserModel model)        //this is if values are being passed through, we are overloading i think?, gonna need a db
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password); //check if user exists in the database
            if (user != null) //if user exists
            {
                TempData["Notification"] = "Login Successful";
                return RedirectToAction("Index", "Chat", new { username = user.Username }); //redirect to the chat page with the username as a parameter
            }
            else
            {
                ViewBag.Error = "Invalid username or password"; //if user does not exist, add an error to the viewbag  -- not sure if this is best prac
                return View(); //return the view with the error message
            }
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if(dbContext.Users.Any(u => u.Username == model.Username)) //check if user already exists
            {
                ViewBag.Error = "Username already exists"; //if user exists, add an error to the viewbag
                return View(); //return the view with the error message
            }

            //else add new user to the database
            dbContext.Users.Add(model); //add the user to the database
            dbContext.SaveChanges(); //save the changes to the database
            //notify user registration is successful
            TempData["Notification"] = "Registration Successful";        //https://gist.github.com/mykeels/59d1774b94248ded2dfe34daa45e8381?permalink_comment_id=2189381
            return RedirectToAction("Login"); //redirect to the login page
        }

    }
}
