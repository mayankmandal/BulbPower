using BulbPower.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BulbPower.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExperimentService _experimentService;

        public HomeController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        public IActionResult Index()
        {
            var existingExperiments = _experimentService.ShowAllExperiments();
            return View(existingExperiments);
        }

        [HttpPost]
        public IActionResult CreateExperiment(int numberOfPeople, int numberOfBulbs)
        {
            _experimentService.CreateExperiment(numberOfPeople, numberOfBulbs);
            return RedirectToAction("Index");
        }

    }
}