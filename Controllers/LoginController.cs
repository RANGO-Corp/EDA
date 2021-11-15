using Alere.Helpers;
using Alere.Repositories;
using Alere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private IUserRepository _repo;

        public LoginController(ILogger<LoginController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index(string error)
        {
            if (error != null)
            {
                TempData["msg"] = error;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Validate(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var user = _repo.FindByCondition(c =>
                c.Email.Equals(loginViewModel.Username) && c.Password.Equals(loginViewModel.Password)
            );
            if (user == null)
            {
                return RedirectToAction("Index", new { error = "Usuário não existente ou credenciais inválidas." });
            }

            LoadToSession("user", user);
            return RedirectToAction("Index", "Food");
        }

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
            _repo.Store(registerViewModel.User);
            _repo.Commit();

            LoadToSession("user", registerViewModel.User);
            return RedirectToAction("Index", "Food");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public void LoadToSession(string key, object value)
        {
            SessionHelper.SetObjectToSession(HttpContext.Session, key, value);
        }
    }
}