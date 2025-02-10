using Canvas.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.viewmodels
{
    public class AddAssignmentViewModel : ContentPage
    {

        public Course SelectedCourse { get; set; }


        public ObservableCollection<Assignment> Assignments { get; set; }



        public AddAssignmentViewModel(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
            Assignments = new ObservableCollection<Assignment>(SelectedCourse.Assignments);
        }



        public void AddAssignment(string name, string description, DateTime dueDate)
        {
            var newAssignment = new Assignment
            {
                Name = name,
                Description = description,
                DueDate = dueDate
            };



            // Add the assignment to the selected course
            SelectedCourse.AddAssignment(newAssignment);



            // Add the assignment to the Assignments collection to update the UI
            Assignments.Add(newAssignment);
        }
    }
}