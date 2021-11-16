using Alere.Helpers;
using Alere.Models;
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

        private void LoadUsersSelect()
        {
            var users = _repoUser.FindAll();
            ViewBag.users = new SelectList(users, "UserId", "Name");
        }

        public IActionResult Index()
        {
            var foods = _repo.FindAll();
            return View(foods);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadUsersSelect();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            // Setted EMPTY instead of WHITESPACE to permits tests without require image
            if (string.IsNullOrEmpty(food.UrlImage))
            {
                food.UrlImage = "https://dummyimage.com/700x350/dee2e6/6c757d.jpg";
            }

            _repo.Store(food);
            _repo.Commit();

            TempData["msg"] = $"Alimento {food.Name} cadastrado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var food = _repo.FindById(id);
            LoadUsersSelect();
            return View(food);
        }

        [HttpPost]
        public IActionResult Update(Food food)
        {
            // Setted EMPTY instead of WHITESPACE to permits tests without require image
            if (string.IsNullOrEmpty(food.UrlImage))
            {
                food.UrlImage = "https://dummyimage.com/700x350/dee2e6/6c757d.jpg";
            }

            _repo.Update(food);
            _repo.Commit();

            TempData["msg"] = $"Alimento {food.Name} atualizado";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Requisition(Requisition requisition)
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Index", "Login", new { error = "Tempo de sessão expirado. Realize o acesso novamente." });
            }

            return RedirectToAction("Create", "Requisition", new { requisition = requisition });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}