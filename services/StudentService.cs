using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Models;


namespace Canvas.Services
{
    public class StudentService
    {
        private IList<Student> students;
        private static StudentService? instance;
        private static object _lock = new object();

        public static StudentService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }

                return instance;
            }
        }

        private StudentService()
        {
            students = new List<Student>
            {
            };
        }

       
        public Student? Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return students;
            }
        }

        public void AddStudent(string name, int id, StudentClassification classification)
        {
                var student = new Student
                {
                    Id = id,
                    Name = name,
                    Classification = classification
                };

            
               
                students.Add(student);
                
            
        }

        private StudentClassification ConvertToStudentClassification(string value)
        {
            if (Enum.TryParse(value, out StudentClassification classification))
            {
                return classification;
            }
            else
            {
                // Handle invalid value
                return StudentClassification.Freshman; // Or any default value
            }
        }

        public void AddOrUpdate(string name, int id, StudentClassification classification)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                // Update existing student
                existingStudent.Name = name;
                existingStudent.Classification = classification;
            }
            else
            {
                // Add new student
                var student = new Student
                {
                    Id = id,
                    Name = name,
                    Classification = classification
                };
                students.Add(student);
            }


        }

        public void UpdateStudent(int id, string newName, StudentClassification newClassification)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                student.UpdateInformation(newName, newClassification);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter Student Id to update: ");
            var idString = Console.ReadLine();

            if (int.TryParse(idString, out int id))
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    Console.Write("\n "); 
                    return;
                }

                Console.WriteLine("Enter new Student Name: ");
                var newName = Console.ReadLine();
                Console.WriteLine("Enter new Student Classification (Freshman, Sophomore, Junior, Senior): ");
                var classificationString = Console.ReadLine();

                if (Enum.TryParse(classificationString, out StudentClassification classification))
                {
                    student.UpdateInformation(newName ?? string.Empty, classification);
                    Console.WriteLine("Student information updated successfully!");
                    Console.Write("\n "); 
                }
                else
                {
                    Console.WriteLine("Invalid Classification. Please enter a valid classification.");
                    Console.Write("\n "); 
                }
            }
            else
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                Console.Write("\n "); 
            }
        }
        public void RemoveStudent(Student student)
        {
            var studentToDelete = students.FirstOrDefault(s => s.Id == student.Id);

            if (studentToDelete == null)
            {
                Console.WriteLine("Student not found."); // You can remove this line
                return;
            }

            students.Remove(studentToDelete);
            Console.WriteLine("Student deleted successfully!"); // You can remove this line
        }


        public void DeleteStudent()
        {
            Console.WriteLine("Enter Student Id to delete: ");
            var idString = Console.ReadLine();

            if (int.TryParse(idString, out int id))
            {
                var studentToDelete = students.FirstOrDefault(s => s.Id == id);

                if (studentToDelete == null)
                {
                    Console.WriteLine("Student not found.");
                    Console.Write("\n "); 
                    return;
                }

                students.Remove(studentToDelete);
                Console.WriteLine("Student deleted successfully!");
                Console.Write("\n "); 
            }
            else
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                Console.Write("\n "); 
            }
        }

        public void ListStudents()
        {
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.Name} - {student.Classification}");
            }
        }
        private StudentClassification ParseStudentClassification(string classificationStr)
        {
            if (Enum.TryParse(classificationStr, out StudentClassification classification))
            {
                return classification;
            }
            else
            {
                Console.WriteLine("Invalid Classification. Defaulting to Freshman.");
                return StudentClassification.Freshman;
            }
        }

   
    }
}
