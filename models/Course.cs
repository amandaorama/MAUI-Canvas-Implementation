using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Canvas.Models
{
    public class Course : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public List<Module> Modules { get; set; } // Define list of Module objects

        public Course()
        {
            Modules = new List<Module>(); // Initialize the list in the constructor
        }


        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();


        public override string ToString()
        {
            return $"{CourseCode} - {CourseName}";
        }
       

   //     public void UpdateInformation(string newName, string newDescription)
   //     {
    //        Name = newName ?? string.Empty;
   //         Description = newDescription ?? string.Empty;
    //    }
         public void AddAssignment(Assignment assignment)
{
    
    if (assignment == null)
    {
        throw new ArgumentNullException(nameof(assignment), "Assignment cannot be null.");
    }

    
    if (Assignments.Contains(assignment))
    {
        throw new InvalidOperationException("Assignment already exists in the course.");
    }

    
    Assignments.Add(assignment);
}

    }
}
