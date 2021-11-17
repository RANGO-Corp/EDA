using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private IUserRepository _repo;

        public UserController(ILogger<UserController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var users = _repo.FindAll();

            return View(users);
        }

        [HttpGet]
        public IActionResult Profile(long id)
        {
            var user = _repo.FindById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = SessionHelper
                    .GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString())
                    .Password;
            }

            _repo.Update(user);
            _repo.Commit();

            SessionHelper.SetObjectToSession(HttpContext.Session, SessionKeys.USER_KEY.ToString(), user);

            return RedirectToAction("Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}