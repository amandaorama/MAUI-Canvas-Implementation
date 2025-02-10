using Canvas.Models;
using System.Collections.ObjectModel;

namespace Canvas.viewmodels;

public class AddStudentToCourseViewModel :  ContentPage
{
    
    
        public Course SelectedCourse { get; set; }
        public ObservableCollection<Student> Students { get; set; }



        public AddStudentToCourseViewModel(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
            Students = SelectedCourse.Students;
        }





        public void AddStudent(string name, int id, StudentClassification classification)
        {
            // Create a new student
            var newStudent = new Student
            {
                Name = name,
                Id = id,
                Classification = classification
            };

            // Add the student to the selected course
            SelectedCourse.Students.Add(newStudent);
        }




    }




