using System.Collections.Generic;
using MVCBasics.Models.Interfaces;

namespace MVCBasics.Models
{
    public class ProjectsRepository : IProjectsRepository
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Project> GetAllProjects()
        {
            throw new System.NotImplementedException();
        }

        public Project GetProjectById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}