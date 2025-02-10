using Canvas.Models;
using Canvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.viewmodels
{
    public class StudentDialogueViewModel : INotifyPropertyChanged
    {
        private Student? student;
        public Student? Student => student;


        private StudentClassification selectedClassification;
        protected virtual void OnPropertyChanged(string propertyName)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


}

        public event PropertyChangedEventHandler? PropertyChanged;

        // Available classification options



        public ObservableCollection<StudentClassification> ClassificationOptions { get; set; }

        // Selected classification




        public StudentClassification SelectedClassification
        {
            get { return selectedClassification; }
            set
            {
                if (selectedClassification != value)
                {
                    selectedClassification = value;
                    OnPropertyChanged(nameof(SelectedClassification));
                }
            }
        }


        // Constructor



        //private string name;
        public string Name
        {
            get { return student?.Name ?? string.Empty; }
            set {
                if(student == null) student = new Student();
                student.Name = value;
            }

        }

        //private string id = string.Empty;
        public int Id
        {


            get { return student?.Id ?? 0; } // Return 0 as default value for int
            set
          {
                if (student == null) student = new Student();
                student.Id = value;
            }
        }


        public StudentDialogueViewModel(int sId) 
        {

            ClassificationOptions = new ObservableCollection<StudentClassification>
            {
                StudentClassification.Freshman,
                StudentClassification.Sophomore,
                StudentClassification.Junior,
                StudentClassification.Senior
            };

           
            if (sId == 0)
            {
                student = new Student();
                SelectedClassification = StudentClassification.Freshman; 
            }
            else
            {
                student = StudentService.Current.Get(sId) ?? new Student();
                SelectedClassification = student.Classification;
            }

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
                return StudentClassification.Freshman; 
            }
        }


        public void Add()
        {

            if (student != null && student.Name != null )
            {

                StudentService.Current.AddOrUpdate(student.Name, student.Id, student.Classification);
                
            }
            

        }



        public void Update()
        {
            if (student != null && student.Name != null)
            {
                // Update the existing student
                StudentService.Current.UpdateStudent(student.Id, student.Name, student.Classification);
            }
        }

    }
}
