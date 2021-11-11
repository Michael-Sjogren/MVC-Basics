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

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Projects()
        {
            ViewBag.Projects = _projectsRepository.GetAllProjects();
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}