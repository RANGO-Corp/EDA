using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Alere.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private IUserRepository _repo;

        private IRequisitionRepository _repoRequisition;

        public UserController(ILogger<UserController> logger, IUserRepository repo, IRequisitionRepository repoRequisition)
        {
            _logger = logger;
            _repo = repo;
            _repoRequisition = repoRequisition;
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

            ViewData["FormActionButton.HasDangerAction"] = true;

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

            TempData["msg"] = "Informações atualizadas com sucesso.";
            TempData["severity"] = Severity.success;

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult Remove(long id)
        {
            User user = _repo.FindById(id);

            var hasActiveDonations = user.Foods.Count > 0;
            var hasActiveTransactions = _repoRequisition.FindAllByCondition(c => c.ReceiverId == user.UserId).Count > 0;

            if (hasActiveDonations || hasActiveTransactions)
            {
                TempData["msg"] = "Ação inválida. Não é possível realizar a exclusão tendo doações ativas. Por favor, contate o administrador.";
                TempData["severity"] = Severity.danger;

                return RedirectToAction("Index");
            }

            _repo.RemoveById(id);
            _repo.Commit();

            TempData["msg"] = "Volte novamente em breve.";
            TempData["severity"] = Severity.info;

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}