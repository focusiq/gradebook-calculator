using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var book = new Book("Scott");
            book.AddGrade(89.1);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"The average number is {stats.Average:N1}, the highest number is {stats.High} and the lowest number is {stats.Low}");



        }
    }
}
