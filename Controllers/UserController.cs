using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Alere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private IList<User> _repo = new List<User>();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _repo.ToList();

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
            _repo.Add(user);

            TempData["msg"] = "Usuário {user.Name} cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Profile(long id)
        {
            var user = _repo.Where(u => u.UserId == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            var userIndex = _repo.IndexOf(user);

            _repo.RemoveAt(userIndex);

            _repo.Add(user);

            return RedirectToAction("Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}