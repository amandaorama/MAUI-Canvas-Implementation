using System;
using Canvas.Services;


namespace Canvas.Helpers
{
    public static class CourseHelper
    {
        private static CourseService courseService = CourseService.Current;

        public static void HandleCourseOptions()
        {
            Console.WriteLine("A. Add a Course");
            Console.WriteLine("U. Update a Course");
            Console.WriteLine("D. Delete a Course");
            Console.WriteLine("L. List all Courses");

            string? choice = Console.ReadLine();

            switch (choice?.ToUpper())
            {
                case "A":
                    courseService.AddCourse();
                    break;
                case "U":
                    courseService.UpdateCourse();
                    break;
                case "D":
                    courseService.DeleteCourse();
                    break;
                case "L":
                courseService.ListCourses();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            
        }
    }
}

