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
        private readonly HomeRepository homeRepository;

        public HomeController(HomeRepository _homeRepository)
        {
            homeRepository = _homeRepository;
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
            var listUsers = homeRepository.ListAll();
            return View(listUsers);
        }

        public IActionResult editUser(string ID)
        {
            ApplicationUser user = homeRepository.editUser(ID);
            return View(user);
        }

        [HttpPost]
        public IActionResult editUser(ApplicationUser user)
        {           
            if (ModelState.IsValid)
            {
                homeRepository.editUser(user);
            }
            return RedirectToAction("UserList");
        }
        public IActionResult DeleteUserList()
        {
            var listUsers = homeRepository.ListAll();
            return View(listUsers);
        }
        public IActionResult EditUserList()
        {
            var listUsers = homeRepository.ListAll();
            return View(listUsers);
        }

        public IActionResult Details(string ID)
        {
            var user = homeRepository.SingleUser(ID);
            return View(user);
        }

        public IActionResult AdminMain()
        {
            return View();
        }
    }
}
