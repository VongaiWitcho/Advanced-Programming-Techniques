using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLinqExample
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Height { get; set; }
        public string City { get; set; }
        public string? Allergies { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Height = 180, City = "Helsinki", Allergies = "Peanuts, Pollen" },
                new Person { FirstName = "Jane", LastName = "Smith", Height = 165, City = "Berlin", Allergies = "Dust" },
                new Person { FirstName = "Alice", LastName = "Brown", Height = 165, City = "Oslo", Allergies = null },
                new Person { FirstName = "Bob", LastName = "White", Height = 170, City = "Paris", Allergies = "Peanuts, Dust" },
                new Person { FirstName = "Tom", LastName = "Green", Height = 180, City = "Hamburg", Allergies = "Cats" }
            };

            var cities = new List<City>
            {
                new City { Name = "Berlin", Population = 3600000 },
                new City { Name = "Paris", Population = 2148000 },
                new City { Name = "Helsinki", Population = 631695 },
                new City { Name = "Oslo", Population = 634293 },
                new City { Name = "Hamburg", Population = 1841000 },
                new City { Name = "Reykjavik", Population = 131136 }
            };

            
            Console.WriteLine("a. Persons with height 165:");
            var heightQuery = from person in people
                              where person.Height == 165
                              select person;

            foreach (var p in heightQuery)
                Console.WriteLine($"{p.FirstName} {p.LastName}");

            
            Console.WriteLine("\nb. Formatted names:");
            var formattedNames = people.Select(p => $"{p.FirstName[0]}. {p.LastName}");
            foreach (var name in formattedNames)
                Console.WriteLine(name);

            
            Console.WriteLine("\nc. Distinct allergies:");
            var distinctAllergies = people
                .Where(p => !string.IsNullOrWhiteSpace(p.Allergies))
                .SelectMany(p => p.Allergies.Split(','))
                .Select(a => a.Trim())
                .Distinct();

            foreach (var allergy in distinctAllergies)
                Console.WriteLine(allergy);

            
            var hCitiesCount = cities.Count(c => c.Name.StartsWith("H", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nd. Number of cities starting with 'H': {hCitiesCount}");

            
            Console.WriteLine("\ne. Persons from cities with population > 100000:");
            var personsFromBigCities = people
                .Join(cities,
                      person => person.City,
                      city => city.Name,
                      (person, city) => new { person, city })
                .Where(pc => pc.city.Population > 100000)
                .Select(pc => pc.person);

            foreach (var p in personsFromBigCities)
                Console.WriteLine($"{p.FirstName} from {p.City}");

           
            var selectedCities = new List<string> { "Berlin", "Paris", "Helsinki" };

            var inSelectedCities = people.Where(p => selectedCities.Contains(p.City));
            var notInSelectedCities = people.Where(p => !selectedCities.Contains(p.City));

            Console.WriteLine("\nf. Persons in selected cities:");
            foreach (var p in inSelectedCities)
                Console.WriteLine($"{p.FirstName} from {p.City}");

            Console.WriteLine("\nPersons NOT in selected cities:");
            foreach (var p in notInSelectedCities)
                Console.WriteLine($"{p.FirstName} from {p.City}");
        }
    }
}
