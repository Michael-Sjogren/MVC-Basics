using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;

namespace MVCBasics.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasKey(e => new {e.PersonId, e.LanguageId});
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder builder)
        {
            // languages
            var french = new Language {Id = 1, Name = "French"};
            var german = new Language {Id = 2, Name = "German"};
            var swedish = new Language {Id = 3, Name = "Swedish"};
            var norwegian = new Language {Id = 4, Name = "Norwegian"};
            var japanese = new Language {Id = 5, Name = "Japanese"};
            var english = new Language{Id = 6, Name = "English"};

            builder.Entity<Language>().HasData(new List<Language>
            {
                french,german,swedish,norwegian,japanese,english
            });
            // Cities
            var swedishCities = new List<City>
            {
                new City() {Id = 1, Name = "Göteborg", People = null , CountryId = 1},
                new City() {Id = 2, Name = "Stockholm", People = null , CountryId = 1},
                new City() {Id = 3, Name = "Malmö", People = null, CountryId = 1},
                new City() {Id = 4, Name = "Kiruna", People = null, CountryId = 1},
                new City() {Id = 5, Name = "Helsingborg", People = null, CountryId = 1},
                new City() {Id = 6, Name = "Uppsala", People = null, CountryId = 1},
                new City() {Id = 7, Name = "Karlstad", People = null, CountryId = 1}
            };
            // Countries

            builder.Entity<Country>().HasData(new Country() {Id = 1, Name = "Sweden"});
            builder.Entity<City>().HasData(swedishCities);
            // random for picking a city id
            var rn = new Random();
            var maxRange = swedishCities.Count+1;
            var min = 1;
            // add people
            builder.Entity<Person>().HasData(new List<Person>
            {
                new Person()
                {
                    Id = 1, Name = "Michael Sjögren", CityId = rn.Next(min, maxRange),
                    PhoneNumber = "555-322-31"
                },
                new Person()
                    {Id = 2, Name = "Anders", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-324"},
                new Person()
                    {Id = 3, Name = "Sten", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-468"},
                new Person()
                    {Id = 4, Name = "Leonard", CityId = rn.Next(min, maxRange), PhoneNumber = "555-897-321"},
                new Person()
                    {Id = 5, Name = "Amir", CityId = rn.Next(min, maxRange), PhoneNumber = "555-893-321"},
                new Person()
                    {Id = 6, Name = "Lena", CityId = rn.Next(min, maxRange), PhoneNumber = "555-893-321"},
                new Person()
                    {Id = 7, Name = "Lisbeth", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-567"},
                new Person()
                    {Id = 8, Name = "Niklas", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-324"},
                new Person()
                    {Id = 9, Name = "Stefan", CityId = rn.Next(min, maxRange), PhoneNumber = "555-783-321"},
                new Person()
                    {Id = 10, Name = "Lina", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-645"},
                new Person()
                    {Id = 11, Name = "Eva", CityId = rn.Next(min, maxRange), PhoneNumber = "555-321-555"},
                new Person()
                    {Id = 12, Name = "Hamid", CityId = rn.Next(min, maxRange), PhoneNumber = "555-873-321"}
            });
            
            // connect people with languages
            builder.Entity<PersonLanguage>().HasData(
                new List<PersonLanguage>
                {
                 new PersonLanguage{LanguageId = french.Id , PersonId = 1},
                 new PersonLanguage{LanguageId = swedish.Id , PersonId = 1},   
                 new PersonLanguage{LanguageId = english.Id , PersonId = 1},   

                 new PersonLanguage{LanguageId = swedish.Id , PersonId = 2},
                 new PersonLanguage{LanguageId = japanese.Id , PersonId = 3},   
                 new PersonLanguage{LanguageId = french.Id , PersonId = 4},   
                 new PersonLanguage{LanguageId = swedish.Id , PersonId = 5},
                 new PersonLanguage{LanguageId = japanese.Id , PersonId = 6},
                 new PersonLanguage{LanguageId = french.Id , PersonId = 7},   
                 new PersonLanguage{LanguageId = norwegian.Id , PersonId = 8},
                 new PersonLanguage{LanguageId = swedish.Id , PersonId = 9}, 
                 new PersonLanguage{LanguageId = french.Id , PersonId = 10},   
                 new PersonLanguage{LanguageId = norwegian.Id , PersonId = 11},
                 
                 new PersonLanguage{LanguageId = german.Id , PersonId = 12},
                 new PersonLanguage{LanguageId = english.Id , PersonId = 12},
                });
        }
    }
}