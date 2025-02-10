

using global::Canvas.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Canvas.viewmodels
{
    public class CourseViewModel : INotifyPropertyChanged
    {



        private static CourseViewModel _instance;

        public static CourseViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseViewModel();
                }
                return _instance;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private   ObservableCollection<Course> _courses;
        public  ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }







        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
            }
        }





        public CourseViewModel()
        {

            Courses = new ObservableCollection<Course>();
            

        }


       
         public void AddCourse(Course course)
        {
            Courses.Add(course);
        }






        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }

}