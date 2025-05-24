using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace project3 // 👈 Add this namespace (it matches your migrations namespace)
{
    public class MyDatabaseContext : DbContext
    {
        public string DbPath { get; }

        public MyDatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mydatabase.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}";
        }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
