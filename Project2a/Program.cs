using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        List<int> numbers = new List<int> { 95, 42, 67, 88, 100, 23, 81, 77, 45, 90, 120, 85 };

        
        var greaterThan80_Query = from num in numbers
                                  where num > 80
                                  select num;

        var greaterThan80_Method = numbers.Where(num => num > 80);

        Console.WriteLine("Numbers > 80 (Query Syntax): " + string.Join(", ", greaterThan80_Query));
        Console.WriteLine("Numbers > 80 (Method Syntax): " + string.Join(", ", greaterThan80_Method));

        var descending_Query = from num in numbers
                               orderby num descending
                               select num;

        var descending_Method = numbers.OrderByDescending(num => num);

        Console.WriteLine("Numbers Descending (Query Syntax): " + string.Join(", ", descending_Query));
        Console.WriteLine("Numbers Descending (Method Syntax): " + string.Join(", ", descending_Method));

      
        var transformed_Query = from num in numbers
                                select $"Have number {num}";

        var transformed_Method = numbers.Select(num => $"Have number {num}");

        Console.WriteLine("Transformed (Query Syntax): " + string.Join(" | ", transformed_Query));
        Console.WriteLine("Transformed (Method Syntax): " + string.Join(" | ", transformed_Method));

        var range_Query = from num in numbers
                          where num > 70 && num < 100
                          select num;

        int count_Method = range_Query.Count();

        Console.WriteLine("Count of numbers between 70 and 100: " + count_Method);
    }
}
