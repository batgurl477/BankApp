using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Data;
using BankApp.Repository;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository userRepository;

        public HomeController(UserRepository _userRepository)
        {
            userRepository = _userRepository;
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
            var listUsers = userRepository.ListAll();
            return View(listUsers);
        }

        public IActionResult editUser(string ID)
        {
            ApplicationUser user = userRepository.editUser(ID);
            return View(user);
        }

        [HttpPost]
        public IActionResult editUser(ApplicationUser user)
        {           
            if (ModelState.IsValid)
            {
                userRepository.editUser(user);
            }
            return RedirectToAction("UserList");
        }
        public IActionResult DeleteUserList()
        {
            var listUsers = userRepository.ListAll();
            return View(listUsers);
        }
        public IActionResult EditUserList()
        {
            var listUsers = userRepository.ListAll();
            return View(listUsers);
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult Details(string ID)
        {
            var user = userRepository.SingleUser(ID);
            return View(user);
        }

    }
}
