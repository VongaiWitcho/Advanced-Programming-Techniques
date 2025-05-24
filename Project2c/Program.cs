using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public int Height { get; set; }
    public string? Allergies { get; set; }

    public Person(string firstName, string lastName, string city, int height, string? allergies)
    {
        FirstName = firstName;
        LastName = lastName;
        City = city;
        Height = height;
        Allergies = allergies;
    }
}

public class City
{
    public string Name { get; set; }
    public int Population { get; set; }

    public City(string name, int population)
    {
        Name = name;
        Population = population;
    }
}

class Program
{
    static void Main()
    {
        Person[] persons = {
            new Person("Cedric","Coltrane","Toronto",157,null),
            new Person("Hank","Spencer","Peterborough",158,"Sulfa, Penicillin"),
            new Person("Sara","di","29",145,null),
            new Person("Daphne ","Seabright","Ancaster",146,null),
            new Person("Rick","Bennett","Ancaster",220,null),
            new Person("Amy","Leela","Hamilton",172,"Penicillin"),
            new Person("Woody","Bashir","Barrie",153,null),
            new Person("Tom", "Halliwell","Hamilton",179,"Codeine, Sulfa"),
            new Person("Rachel ","Winterbourne","Hamilton",163,null),
            new Person("John","West","Oakville",138,null),
            new Person("Jon","Doggett","Hamilton",194,"Peanut Oil"),
            new Person("Angel","Edwards","Brantford",176,null),
            new Person("Brodie","Beck","Carlisle",157,null),
            new Person("Beanie","Foster","Ancaster",154,"Ragweed, Codeine"),
            new Person("Nino","Andrews","Hamilton",186,null),
            new Person("John","Farley","Hamilton",213,null),
            new Person("Nea","Kobayakawa","Toronto",147,null),
            new Person("Laura","Halliwell","Brantford",146,null),
            new Person("Lucille","Maureen","Hamilton",184,null),
            new Person("Jim","Thoma","Ottawa",173,null),
            new Person("Roderick","Payne","Halifax",58,null),
            new Person("Sam","Threep","Hamilton",199,null),
            new Person("Bertha","Crowley","Delhi",125,"Peanuts, Gluten"),
            new Person("Roland","Edge","Brantford",199,null),
            new Person("Don","Wiggum","Hamilton",189,null),
            new Person("Anthony","Maxwell","Oakville",92,null),
            new Person("James","Sullivan","Delhi",139,null),
            new Person("Anne","Marlowe","Pickering",165,"Peanut Oil"),
            new Person("Kelly","Hamilton","Stoney",84,null),
            new Person("Charles","Andonuts","Hamilton",62,null),
            new Person("Temple ","Russert","Hamilton",166,"Sulphur"),
            new Person("Don","Edwards","Hamilton",215,null),
            new Person("Alice","Donovan","Hamilton",167,null),
            new Person("Stone","Cutting","Hamilton",110,null),
            new Person("Neil","Allan","Cambridge",203,null),
            new Person("Cross","Gordon","Ancaster",125,null),
            new Person("Phoebe","Bigelow","Thunder",183,null),
            new Person("Harry","Kuramitsu","Hamilton",210,null)
        };

       
        XElement xml = new XElement("Persons",
            persons.Select(p =>
                new XElement("Person",
                    new XElement("FirstName", p.FirstName.Trim()),
                    new XElement("LastName", p.LastName.Trim()),
                    new XElement("City", p.City),
                    new XElement("Height", p.Height),
                    string.IsNullOrWhiteSpace(p.Allergies) ? null : new XElement("Allergies", p.Allergies)
                )
            )
        );

       
        Console.WriteLine(xml);
    }
}
