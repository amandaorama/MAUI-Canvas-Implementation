using System;
using Canvas.Helpers;
using Canvas.Services;

namespace Canvas
{
    internal class Program
    { 

        static void Main(string[] args)
        {
             bool exit = false;


             while (!exit){
            Console.WriteLine("Welcome to Canvas!");
            Console.WriteLine("1. Courses");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Assignments");
            Console.WriteLine("4. Modules");
            Console.WriteLine("5. Content Items");
            Console.WriteLine("0. Exit");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CourseHelper.HandleCourseOptions();
                    break;
                case "2":
                    StudentHelper.HandleStudentOptions();
                    break;
                case "3":
                    AssignmentHelper.HandleAssignmentOptions();
                    break;
                case "4":
                    ModuleHelper.HandleModuleOptions();
                    break;
                case "5":
                    ContentItemHelper.HandleContentItemOptions();
                    break;
                case "0":
                    Console.WriteLine("Exiting the program.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
    
             }
        }
        
    }
}
