using System;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models.Interfaces;

namespace MVCBasics.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectsRepository _projectsRepository;
        public PortfolioController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }
        [HttpGet]
        [Route("/")]
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