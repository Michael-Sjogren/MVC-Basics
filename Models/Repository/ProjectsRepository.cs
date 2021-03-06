using System.Collections.Generic;
using MVCBasics.Models.Interfaces;
using System.Linq;

namespace MVCBasics.Models
{
    public class ProjectsRepository : IProjectsRepository
    {
        public List<Project> Projects { get; set; }

        public ProjectsRepository()
        {
            Projects = new List<Project>{
                new Project {Name = "MVC-Basics", Link = "https://github.com/Michael-Sjogren/MVC-Basics" , Description = "The assignment is for learning about ASP .NET MVC Fundamentals."},
                new Project {Name = "LexikonJavaScriptSokoBan" , Link = "https://github.com/Michael-Sjogren/LexikonJavaScriptSokoBan" , Description = "JavaScript game, based on the game called ”Sokoban”."},
                new Project {Name = "Lexicon-HTML-CSS-Fundamentals" , Link = "https://github.com/Michael-Sjogren/Lexicon-HTML-CSS-Fundamentals" , Description = "Fundamentals in html and css. Assignment for my education as .NET Dev "},
                new Project {Name = "C-Sharp-Hangman" , Link = "https://github.com/Michael-Sjogren/C-Sharp-Hangman" , Description = "Hangman game is a console application guessing game for two or more players."},
                new Project {Name = "test-calculator" , Link = "https://github.com/Michael-Sjogren/test-calculator" , Description = "Your assignment for this week is to test the previously created calculator. You shall also overload your addition(+) and subtract(-) method with versions that takes a array as input parameter."},
                new Project {Name = "LexiconVendingMachine", Link = "https://github.com/Michael-Sjogren/LexiconVendingMachine", Description = "Console application , vending machine with tests in Xunit."},
            };
        }


        public List<Project> GetAllProjects()
        {
            return Projects;
        }

        public Project GetProjectById(int Id)
        {
            return Projects.First<Project>( (e) => e.Id == Id );
        }
    }
}