using Alere.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;

        private IFoodRepository _repo;
        private IUserRepository _repoUser;

        public FoodController(ILogger<FoodController> logger, IFoodRepository repo, IUserRepository repoUser)
        {
            _logger = logger;
            _repo = repo;
            _repoUser = repoUser;
        }

        public IActionResult Index()
        {
            var foods = _repo.FindAll();
            return View(foods);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var users = _repoUser.FindAll();
            ViewBag.users = new SelectList(users, "UserId", "Name");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}