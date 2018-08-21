using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserList()
        {
            List<ApplicationUser> listUsers = _db.Users.ToList();
            return View(listUsers);
        }

        public IActionResult editUser(string ID)
        {
            _db.Users.Find(ID);
            ApplicationUser user = _db.Users.FirstOrDefault(m => m.Id == ID);
            return View(user);
        }

        [HttpPost]
        public IActionResult editUser(ApplicationUser user)
        {
            _db.Entry(user).GetDatabaseValues();
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }
            return RedirectToAction("UserList");
        }

    }
}
