using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;

namespace MVCBasics.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                    {Id = 1, Name = "Michael Sjögren", PhoneNumber = "555-321-325", City = "Göteborg"},
                new Person
                    {Id = 2, Name = "Anna", PhoneNumber = "555-752-325", City = "Stockholm"},
                new Person
                    {Id = 3, Name = "Hamid", PhoneNumber = "555-233-325", City = "Oslo"},
                new Person
                    {Id = 4, Name = "Lena", PhoneNumber = "555-456-134", City = "Uppsala"},
                new Person
                    {Id = 5, Name = "Jens", PhoneNumber = "555-999-325", City = "Göteborg"},
            });
        }
    }
}