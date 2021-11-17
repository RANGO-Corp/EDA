using System.Diagnostics;
using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Alere.TagHelpers;
using Alere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IUserRepository _repoUser;

        public HomeController(ILogger<HomeController> logger, IUserRepository repoUser)
        {
            _logger = logger;
            _repoUser = repoUser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string error)
        {
            if (error != null)
            {
                TempData["msg"] = error;
                TempData["severity"] = Severity.danger;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _repoUser.FindByCondition(c =>
                c.Email.Equals(loginViewModel.Username) &&
                c.Password.Equals(loginViewModel.Password)
            );
            if (user == null)
            {
                return RedirectToAction("Login", new
                {
                    error = "Usuário não existente ou credenciais inválidas."
                });
            }

            LoadToSession(SessionKeys.USER_KEY.ToString(), user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // GET Password from view and SET into User
            registerViewModel.User.Password = registerViewModel.Password;

            if(string.IsNullOrEmpty(registerViewModel.User.Photo))
            {
                registerViewModel.User.Photo = "/img/avatar.svg";
            }

            _repoUser.Store(registerViewModel.User);
            _repoUser.Commit();

            LoadToSession(SessionKeys.USER_KEY.ToString(), registerViewModel.User);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKeys.USER_KEY.ToString());

            return RedirectToAction("Index");
        }

        private void LoadToSession(string key, object value)
        {
            SessionHelper.SetObjectToSession(HttpContext.Session, key, value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
