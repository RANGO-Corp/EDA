using Alere.Helpers;
using Alere.Models;
using Alere.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alere.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly ILogger<RequisitionController> _logger;

        private IRequisitionRepository _repo;

        public RequisitionController(ILogger<RequisitionController> logger, IRequisitionRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());
            var requisitions = _repo.FindAll();
            return View(requisitions);
        }

        [HttpPost]
        public IActionResult Create(Requisition requisition)
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Index", "Login", new { error = "Tempo de sessão expirado. Realize o acesso novamente." });
            }

            requisition.ReceiverId = sessionUser.UserId;

            _repo.Store(requisition);
            _repo.Commit();

            TempData["msg"] = "Solicitação criada com sucesso";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}