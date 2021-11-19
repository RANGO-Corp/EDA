using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Alere.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly ILogger<RequisitionController> _logger;

        private IRequisitionRepository _repo;

        private IFoodRepository _repoFood;

        public RequisitionController(ILogger<RequisitionController> logger, IRequisitionRepository repo, IFoodRepository repoFood)
        {
            _logger = logger;
            _repo = repo;
            _repoFood = repoFood;
        }

        public IActionResult Index()
        {
            var sessionUser = GetSessionUser();

            if (sessionUser == null)
            {
                return RedirectWithExpiredSession();
            }

            var requisitions = _repo.FindAllByCondition(c => c.DonorId == sessionUser.UserId);
            return View(requisitions);
        }

        [HttpPost]
        public IActionResult Create(Requisition requisition)
        {
            var sessionUser = GetSessionUser();

            if (sessionUser == null)
            {
                return RedirectWithExpiredSession();
            }

            requisition.ReceiverId = sessionUser.UserId;

            _repo.Store(requisition);
            _repo.Commit();

            TempData["msg"] = "Solicitação criada com sucesso";
            TempData["severity"] = Severity.success;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Approve(long id, long foodId)
        {
            var sessionUser = GetSessionUser();

            _repo.SetStatusByCondition(Status.APPROVED, c => (c.RequisitionId == id && c.DonorId == sessionUser.UserId));
            int lines = _repo.Commit();

            if (lines == 1)
            {
                _repo.SetStatusByCondition(Status.REFUSED, c =>
                    (c.DonorId == sessionUser.UserId && c.Status.Equals(Status.AWAITING))
                );

                var food = _repoFood.FindByCondition(c => (c.FoodId == foodId && c.UserId == sessionUser.UserId));

                if (food != null)
                {
                    food.IsReserved = true;
                    _repoFood.Update(food);
                }

                _repo.Commit();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deny(long id)
        {
            var sessionUser = GetSessionUser();

            _repo.SetStatusByCondition(Status.REFUSED, c => (c.RequisitionId == id && c.DonorId == sessionUser.UserId));
            _repo.Commit();

            return RedirectToAction("Index");
        }

        private IActionResult RedirectWithExpiredSession()
        {
            return RedirectToAction("Login", "Home", new
            {
                error = "Tempo de sessão expirado. Realize o acesso novamente."
            });
        }

        private User GetSessionUser()
        {
            return SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}