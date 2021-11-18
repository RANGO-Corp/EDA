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

        public RequisitionController(ILogger<RequisitionController> logger, IRequisitionRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Login", "Home", new 
                {
                    error = "Tempo de sessão expirado. Realize o acesso novamente." 
                });
            }

            var requisitions = _repo.FindAllByCondition(c => c.DonorId == sessionUser.UserId);
            return View(requisitions);
        }

        [HttpPost]
        public IActionResult Create(Requisition requisition)
        {
            var sessionUser = SessionHelper.GetObjectFromSession<User>(HttpContext.Session, SessionKeys.USER_KEY.ToString());

            if (sessionUser == null)
            {
                return RedirectToAction("Login", "Home", new 
                {
                    error = "Tempo de sessão expirado. Realize o acesso novamente." 
                });
            }

            requisition.ReceiverId = sessionUser.UserId;

            _repo.Store(requisition);
            _repo.Commit();

            TempData["msg"] = "Solicitação criada com sucesso";
            TempData["severity"] = Severity.success;

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}