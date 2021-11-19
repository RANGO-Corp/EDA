using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Alere.TagHelpers;
using Alere.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(long? userId)
        {
            FoodViewModel viewModel = new FoodViewModel()
            {
                Foods = _repo.FindAllByCondition(c => (c.UserId == userId || userId == null) && !c.IsReserved)
            };

            if (userId != null)
            {
                ViewData["ActionMessage"] = "Que tal cadastrar sua primeira doação?";
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Login", "Home", new 
                {
                    error = "Tempo de sessão expirado. Realize o acesso novamente." 
                });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            // Setted EMPTY instead of WHITESPACE to permits tests without require image
            if (string.IsNullOrEmpty(food.UrlImage))
            {
                food.UrlImage = "/img/food-sample.jpg";
            }

            _repo.Store(food);
            _repo.Commit();

            TempData["msg"] = $"Alimento {food.Name} cadastrado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Login", "Home", new 
                {
                    error = "Tempo de sessão expirado. Realize o acesso novamente." 
                });
            }

            var food = _repo.FindByCondition(c => (c.FoodId == id && c.UserId == sessionUser.UserId));
            if (food == null)
            {
                TempData["msg"] = "Não é permitido alterar a doação de outro usuário.";
                TempData["severity"] = Severity.danger;
                return RedirectToAction("Index");
            }

            return View(food);
        }

        [HttpPost]
        public IActionResult Update(Food food)
        {
            // Setted EMPTY instead of WHITESPACE to permits tests without require image
            if (string.IsNullOrEmpty(food.UrlImage))
            {
                food.UrlImage = "/img/food-sample.jpg";
            }

            _repo.Update(food);
            _repo.Commit();

            TempData["msg"] = "Alimento atualizado";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}