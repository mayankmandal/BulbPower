﻿using BulbPower.Business.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BulbPower.Web.Controllers
{
    public class ExperimentController : Controller
    {
        private readonly IExperimentService _experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        public IActionResult Details(int id)
        {
            var experimentVm = _experimentService.GetExperimentVM(id);
            if (experimentVm == null)
            {
                return NotFound();
            }

            return View(experimentVm);
        }

        public IActionResult SendNextPerson(int id)
        {
            _experimentService.SendNextPerson(id);
            return RedirectToAction("Details", new { id });
        }

        public IActionResult ResetExperiment(int id)
        {
            _experimentService.ResetExperiment(id);
            return RedirectToAction("Details", new { id });
        }
    }
}
