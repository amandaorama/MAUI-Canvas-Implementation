using System;
using Canvas.Services;


namespace Canvas.Helpers
{
    public static class AssignmentHelper
    {
        private static AssignmentService assignmentService = AssignmentService.Current;

        public static void HandleAssignmentOptions()
        {
            Console.WriteLine("A. Add an Assignment");
            Console.WriteLine("U. Update an Assignment");
            Console.WriteLine("D. Delete an Assignment");
            Console.WriteLine("L. List all Assignments");

            string? choice = Console.ReadLine();

            switch (choice?.ToUpper())
            {
                case "A":
                   Console.WriteLine("Enter Course Code: ");
                    var courseCode = Console.ReadLine();
                    if (courseCode != null)
                    {
                    assignmentService.AddAssignment(courseCode);
                    }
                     else
                    {
                     Console.WriteLine("Invalid course code. Please enter a valid course code.");
                    }
                    break;
                case "U":
                    assignmentService.UpdateAssignment();
                    break;
                case "D":
                    assignmentService.DeleteAssignment();
                    break;
                    case "L":
                 //   assignmentService.ListAllAssignments();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            
        }
        
    }
}
