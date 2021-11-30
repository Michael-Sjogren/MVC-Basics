using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;

namespace MVCBasics.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        
        
    }
}