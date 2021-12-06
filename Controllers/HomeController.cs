using System;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectsRepository _projectsRepository;
        public HomeController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(About));
        }
        
        [HttpGet]
        [Route("/About")]
        public ViewResult About()
        {
            return View();
        }
        [HttpGet]
        [Route("/Projects/")]
        public ViewResult Projects()
        {
            ViewBag.Projects = _projectsRepository.GetAllProjects();
            return View();
        }
        [HttpGet]
        [Route("/Contact/")]
        public ViewResult Contact()
        {
            return View();
        }
    }
}