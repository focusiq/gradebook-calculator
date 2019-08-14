using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Scott");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            // book.AddGrade(89.1);
            // book.AddGrade(77.5);



            var stats = book.GetStatistics();

            Console.WriteLine($"The name field is {book.Name}");
            Console.WriteLine($"The average number is {stats.Average:N1}");
            Console.WriteLine($"The highest number is {stats.High}");
            Console.WriteLine($"The lowest number is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");



        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*******");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
