using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Models;
using Canvas.Services; 


namespace Canvas.Services
{
    public class AssignmentService
    {
        private IList<Assignment> assignments;
        private static AssignmentService? instance;
        private static object _lock = new object();

        public static AssignmentService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new AssignmentService();
                    }
                }

                return instance;
            }
        }

        private AssignmentService()
        {
            assignments = new List<Assignment>();
        }

        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return assignments;
            }
        }


        public void AddAssignment(string courseCode)
        {


            
    Console.WriteLine("Enter Assignment Name: ");
    var name = Console.ReadLine();
    Console.WriteLine("Enter Total Available Points: ");
    var totalAvailablePoints = Console.ReadLine();
    Console.WriteLine("Enter Assignment Description: ");
    var description = Console.ReadLine();
    Console.WriteLine("Enter Due Date (MM/dd/yyyy): ");
    var dueDateString = Console.ReadLine();

    if (DateTime.TryParseExact(dueDateString, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
    {
        var assignment = new Assignment
        {
            Name = name,
            TotalAvailablePoints = totalAvailablePoints,
            Description = description,
            DueDate = dueDate
        };

        //var course = CourseService.Current.GetByCode(courseCode);

       // if (course != null)
       // {
        //    course.AddAssignment(assignment);
        
         //   Console.WriteLine("Assignment added successfully to the course!");
      //  }
      //  else
       // {
      //      Console.WriteLine($"Course with code {courseCode} not found. Assignment not added.");
      //  }
    }
    else
    {
        Console.WriteLine("Invalid Due Date. Please enter a valid date (MM/dd/yyyy).");
    }
        }

        public void UpdateAssignment()
        {
            Console.WriteLine("Enter Assignment Name to update: ");
            var assignmentName = Console.ReadLine();

            var assignment = assignments.FirstOrDefault(a => a.Name == assignmentName);

            if (assignment == null)
            {
                Console.WriteLine("Assignment not found.");
                Console.Write("\n "); 
                return;
            }

            Console.WriteLine("Enter new Assignment Name: ");
            var newName = Console.ReadLine();
            Console.WriteLine("Enter new Total Available Points: ");
            var newTotalAvailablePoints = Console.ReadLine();
            Console.WriteLine("Enter new Assignment Description: ");
            var newDescription = Console.ReadLine();
            Console.WriteLine("Enter new Due Date (MM/dd/yyyy): ");
            var newDueDateString = Console.ReadLine();

            if (DateTime.TryParseExact(newDueDateString, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime newDueDate))
            {
                assignment.UpdateInformation(newName ?? string.Empty, newTotalAvailablePoints ?? string.Empty, newDescription ?? string.Empty, newDueDate);
                Console.WriteLine("Assignment information updated successfully!");
                Console.Write("\n "); 
            }
            else
            {
                Console.WriteLine("Invalid Due Date. Please enter a valid date (MM/dd/yyyy).");
            }
        }

        public void DeleteAssignment()
        {
            Console.WriteLine("Enter Assignment Name to delete: ");
            var assignmentName = Console.ReadLine();

            var assignmentToDelete = assignments.FirstOrDefault(a => a.Name == assignmentName);

            if (assignmentToDelete == null)
            {
                Console.WriteLine("Assignment not found.");
                Console.Write("\n "); 
                return;
            }

            assignments.Remove(assignmentToDelete);
            Console.WriteLine("Assignment deleted successfully!");
            Console.Write("\n "); 
        }

      //  public void ListAllAssignments()
      //  {
      //      
      //  {
     //       Console.WriteLine("All Assignments:");
      //    foreach (var course in CourseService.Current.Courses)
     //   {
      //  foreach (var assignment in course.Assignments)
      //  {
     //       Console.WriteLine($"{assignment.Name} - Course: {course.Name}");
     //   }
     //   }
     //   }

        }
    }

