using System.Collections.Generic;

namespace MVCBasics.Models.Interfaces
{
    public interface IProjectsRepository
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectById(int Id);
    }
}