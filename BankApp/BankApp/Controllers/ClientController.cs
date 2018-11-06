using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models;
using BankApp.Models.AccountViewModels;
using BankApp.Repository;
using BankApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly HomeRepository _homeRepository;

        public ClientController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IEmailSender emailSender,
           ILogger<AccountController> logger,
            HomeRepository homeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _homeRepository = homeRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var client = new ApplicationUser();
                    var loginView = new LoginBalanceViewModel();
                    client.Email = model.Email;
                    var client1 = new ApplicationUser();
                    
                    if (client.Email == model.Email)
                    {
                        client1 = _homeRepository.IsLoggedIn(client.Email);
                        loginView.ID = client1.Id;
                        loginView.Email = client1.Email;

                    }
                    return RedirectToAction("Balance", "Client", new { loginView.ID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult Balance(string ID)
        {
            var bal = _homeRepository.ClientBalance(ID);
            return View(bal);
        }


        public IActionResult Transfer(string ID)
        {
            var single = _homeRepository.GetClientandBalancesandMoneyTransferDetails(ID);
            return View(single);
        }

        [HttpPost]
        public IActionResult Transfer(ClientMoneyTranferViewModel money, string ID)
        {
            _homeRepository.Transfers(money, ID);
            return RedirectToAction("Balance", new { ID });
        }

        public IActionResult AddAccount(string ID)
        {
            var bal = _homeRepository.AddAccount(ID);
            return View(bal);
        }

        [HttpPost]
        public IActionResult AddAccount(string ID, ClientBalance clientBalance)
        {
            _homeRepository.AddAccount(ID, clientBalance);

            return RedirectToAction("Balance", new { ID });
        }
    }
}