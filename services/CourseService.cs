using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic; // for List<Course>
using Canvas.Models;


namespace Canvas.Services
{
    public class CourseService
    {
        private IList<Course> courses;
        private static CourseService? instance;
        private static object _lock = new object();

        public static CourseService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }

                return instance;
            }
        }

        private CourseService()
        {
            courses = new List<Course>();
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                return courses;
            }
        }
    // public Course? GetByCode(string courseCode)
       // {
       //     return courses.FirstOrDefault(c => c.Code == courseCode);
      //  }

        public void AddCourse()
        {
            Console.WriteLine("Enter Course Code: ");
            var code = Console.ReadLine();
            Console.WriteLine("Enter Course Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Course Description: ");
            var description = Console.ReadLine();

            var course = new Course
            {
               // Code = code,
               // Name = name,
               // Description = description
            };

            courses.Add(course);
            Console.WriteLine("Course added successfully!");
            Console.Write("\n "); 
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Enter Course Code to update: ");
            var courseCode = Console.ReadLine();

            //var course = courses.FirstOrDefault(c => c.Code == courseCode);

           // if (course == null)
           // {
             //   Console.WriteLine("Course not found.");
              //  Console.Write("\n "); 
               // return;
           // }

            Console.WriteLine("Enter new Course Name: ");
            var newName = Console.ReadLine();
            Console.WriteLine("Enter new Course Description: ");
            var newDescription = Console.ReadLine();

           // course.UpdateInformation(newName ?? string.Empty, newDescription ?? string.Empty);

            Console.WriteLine("Course information updated successfully!");
            Console.Write("\n "); 
        }

        public void DeleteCourse()
        {
            Console.WriteLine("Enter Course Code to delete: ");
            var courseCode = Console.ReadLine();

          //  var courseToDelete = courses.FirstOrDefault(c => c.Code == courseCode);

          //  if (courseToDelete == null)
          //  {
          //      Console.WriteLine("Course not found.");
          //      Console.Write("\n "); 
          //      return;
          //  }

           // courses.Remove(courseToDelete);
            Console.WriteLine("Course deleted successfully!");
            Console.Write("\n "); 
        }

        public void ListCourses()
        {
            Console.WriteLine("All Courses:");
          //  foreach (var course in courses)
          //  {
           //     Console.WriteLine($"{course.Code} - {course.Name}");
           // }
        }
    }
}

