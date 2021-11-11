using System.Collections.Generic;

namespace MVCBasics.Models.Interfaces
{
    public interface IProjectsRepository
    {
        public List<Project> Projects { get; set; }
        public List<Project> GetAllProjects();
        public Project GetProjectById(int Id);
    }
}