using System.Linq;
using Alere.Models;
using Alere.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private FactoryContext _repo;

        public UserController(ILogger<UserController> logger, FactoryContext repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var users = _repo.Users.ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _repo.Users.Add(user);

            TempData["msg"] = $"Usuário {user.Name} cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Profile(long id)
        {
            var user = _repo.Users.Where(u => u.UserId == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            var userIndex = _repo.Users.Update(user);

            return RedirectToAction("Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}