
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Canvas.Services;
using Canvas.Models;



namespace Canvas.viewmodels
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {


        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;





        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        public string? Query {  get; set; }




        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(studentSvc.Students);
            }
        }

     



        public void Remove()
        {
            if (SelectedStudent != null)
            {
                studentSvc.RemoveStudent(SelectedStudent);
            }
            else
            {
                return;
            }
                Refresh();
            
        }



        public void Refresh() 
        { 
            NotifyPropertyChanged(nameof(Students));
        }





        public StudentsViewModel()
        {
            studentSvc = StudentService.Current;
        }




        private Student? _selectedStudent;
        public Student? SelectedStudent
        {
            get 
            {
                return _selectedStudent; 
            }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStudent)));
                }
            }
            
        }


    }
}