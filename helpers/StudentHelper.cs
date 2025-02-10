using System;
using Canvas.Models;
using Canvas.Services;

namespace Canvas.Helpers
{
    public static class StudentHelper
    {
        private static StudentService studentService = StudentService.Current;

        public static void HandleStudentOptions()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("A. Add a Student");
                Console.WriteLine("U. Update a Student");
                Console.WriteLine("D. Delete a Student");
                Console.WriteLine("L. List all Students");
                Console.WriteLine("0. Back");

                string? choice = Console.ReadLine();

                switch (choice?.ToUpper())
                {
                    case "A":
                        Console.WriteLine("Enter Student Name: ");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Enter Student ID: ");
                        int id;
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid ID. Please enter a valid integer.");
                            break;
                        }
                        Console.WriteLine("Enter Student Classification (Freshman, Sophomore, Junior, Senior): ");
                        string? classificationStr = Console.ReadLine();
                        if (!Enum.TryParse(classificationStr, out StudentClassification classification))
                        {
                            Console.WriteLine("Invalid Classification. Please enter a valid classification.");
                            break;
                        }
                        // Call AddStudent method with the provided parameters
                        studentService.AddStudent(name ?? "", id, classification);
                        break;
                    case "U":
                        studentService.Update();
                        break;
                    case "D":
                        studentService.DeleteStudent();
                        break;
                    case "L":
                        studentService.ListStudents();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Returning to the main menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}