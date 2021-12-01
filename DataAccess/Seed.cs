using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using MVCBasics.Models;

namespace MVCBasics.DataAccess
{
    public static class Seed
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            if (context != null)
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>() ??
                         throw new InvalidOperationException());
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Countries.Any())
            {
                Console.WriteLine("Seeding data...");
                var swedishCities = new List<City>
                {
                    new City() {Name = "Göteborg", People = null},
                    new City() {Name = "Stockholm", People = null},
                    new City() {Name = "Malmö", People = null},
                    new City() {Name = "Kiruna", People = null},
                    new City() {Name = "Helsingborg", People = null},
                    new City() {Name = "Uppsala", People = null},
                    new City() {Name = "Karlstad", People = null}
                };

                var sweden = new Country() {Name = "Sweden", Cities = swedishCities};
                context.Countries.AddRange(
                    sweden
                );

                Random rn = new Random();
                int maxRange = swedishCities.Count;
                context.People.AddRange(
                    new Person()
                    {
                        Name = "Michael Sjögren", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-322-31"
                    },
                    new Person()
                        {Name = "Anders", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-324"},
                    new Person()
                        {Name = "Sten", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-468"},
                    new Person()
                        {Name = "Leonard", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-897-321"},
                    new Person()
                        {Name = "Amir", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-893-321"},
                    new Person()
                        {Name = "Lena", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-893-321"},
                    new Person()
                        {Name = "Lisbeth", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-567"},
                    new Person()
                        {Name = "Niklas", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-324"},
                    new Person()
                        {Name = "Stefan", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-783-321"},
                    new Person()
                        {Name = "Lina", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-645"},
                    new Person()
                        {Name = "Eva", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-321-555"},
                    new Person()
                        {Name = "Hamid", City = swedishCities[rn.Next(0, maxRange)], PhoneNumber = "555-873-321"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exist");
            }
        }
    }
}