using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using thewall.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace thewall.Controllers
{
    public class LoginController : Controller
    {
        private WallContext dbContext;
        public LoginController(WallContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User NewUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.users.Any(u => u.Email == NewUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("index");
                }
                PasswordHasher<User> hasher= new PasswordHasher<User>();
                User newUser = new User
                {
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName,
                    Email = NewUser.Email,
                    Password = hasher.HashPassword(NewUser, NewUser.Password)
                };
                dbContext.users.Add(newUser);
                dbContext.SaveChanges();
                var currentuser = dbContext.users.FirstOrDefault(u => u.Email == NewUser.Email);
                
                HttpContext.Session.SetInt32("CurrentUser", currentuser.UserId);
                System.Console.WriteLine("########################");
                System.Console.WriteLine(currentuser.UserId);
                return RedirectToAction("WallView", "Wall");
            }
            return View("index");
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login user)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.users.FirstOrDefault( u => u.Email == user.LogEmail);

                if(userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("index");
                }
                var hasher = new PasswordHasher<Login>();

                var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LogPassword", "Incorrect Password");
                    return View("index");
                }
                HttpContext.Session.SetInt32("CurrentUser", userInDb.UserId);
                return RedirectToAction("WallView", "Wall");
            }
            return View("index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}
