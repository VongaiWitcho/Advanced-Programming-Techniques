using System;
using System.Linq;
using project3; // 👈 This now works because of the namespace you added above

class Program
{
    static void Main()
    {
        using var db = new MyDatabaseContext();

        // Clear existing data (to avoid duplicates)
        db.Students.RemoveRange(db.Students);
        db.Classes.RemoveRange(db.Classes);
        db.SaveChanges();

        // Add classes
        var class1 = new Class { Name = "Math" };
        var class2 = new Class { Name = "History" };
        db.Classes.AddRange(class1, class2);

        // Add students
        var student1 = new Student { FirstName = "Alice", LastName = "Smith" };
        var student2 = new Student { FirstName = "Bob", LastName = "Johnson" };
        db.Students.AddRange(student1, student2);

        db.SaveChanges();

        // Print results
        PrintStudents(db);
        PrintClasses(db);
    }

    static void PrintStudents(MyDatabaseContext db)
    {
        Console.WriteLine("📘 Students:");
        foreach (var student in db.Students.ToList())
        {
            Console.WriteLine(student);
        }
    }

    static void PrintClasses(MyDatabaseContext db)
    {
        Console.WriteLine("\n🏫 Classes:");
        foreach (var cls in db.Classes.ToList())
        {
            Console.WriteLine(cls);
        }
    }
}
