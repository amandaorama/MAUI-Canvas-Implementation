using Canvas.Models;
using System.ComponentModel;
using Canvas.viewmodels;



namespace Canvas.views;

public partial class CourseView : ContentPage, INotifyPropertyChanged
{
    public CourseView()
    {
        InitializeComponent();
        BindingContext = new CourseViewModel();



    }





  

    private string newCourseName;
    public string NewCourseName
    {
        get { return newCourseName; }
        set
        {
            if (newCourseName != value)
            {
                newCourseName = value;
                OnPropertyChanged(nameof(NewCourseName));
            }
        }
    }




    private void AddCourse_Click(object sender, EventArgs e)
    {
        CourseViewModel viewModel = (CourseViewModel)BindingContext;

        string courseCode = txtCourseCode.Text;
        string courseName = txtCourseName.Text;
        string courseDescription = txtCourseDescription.Text;

        // Create a new course
        Course newCourse = new Course
        {
            CourseCode = courseCode,
            CourseName = courseName,
            CourseDescription = courseDescription
        };

        // Add the new course to the ViewModel
        viewModel.Courses.Add(newCourse);

        // Clear input fields
        txtCourseCode.Text = "";
        txtCourseName.Text = "";
        txtCourseDescription.Text = "";

        // Display a message with the course information
        string message = $"Course added:\nCode: {courseCode}\nName: {courseName}\nDescription: {courseDescription}";
        DisplayAlert("Course Added", message, "OK");



    }




    public async void AddStudentsToCourse_Clicked(object sender, EventArgs e)
    {
        CourseViewModel viewModel = (CourseViewModel)BindingContext;
        Course selectedCourse = viewModel.SelectedCourse;

        if (selectedCourse != null)
        {
            // Navigate to AddStudentToCourseView and pass the selected course as a parameter
            await Navigation.PushAsync(new AddStudentToCourseView(selectedCourse));
        }


    }

    public async void AddAssignmentToCourse_Clicked(object sender, EventArgs e)
    {
        CourseViewModel viewModel = (CourseViewModel)BindingContext;
        Course selectedCourse = viewModel.SelectedCourse;

        if (selectedCourse != null)
        {
            // Navigate to AddAssignmentToCourseView and pass the selected course as a parameter
            await Navigation.PushAsync(new AddAssignmentView(selectedCourse));
        }
    }





    public async void AddModule_Clicked(object sender, EventArgs e)
    {
        // Get the view model from the BindingContext
        var viewModel = (CourseViewModel)BindingContext;

        // Get the selected course
        var selectedCourse = viewModel.SelectedCourse;

        if (selectedCourse != null)
        {
            // Navigate to the AddModuleView and pass the selected course as a parameter
            await Navigation.PushAsync(new AddModuleView(selectedCourse));
        }
    }




    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
