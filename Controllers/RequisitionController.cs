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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}