using Canvas.Models;
using Canvas.Services;
using Canvas.viewmodels;

namespace Canvas.views;

public partial class StudentsView : ContentPage
{
   
    
    public StudentsView()
	{
        InitializeComponent();
        
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

   
 

    private void NavigateToStudentsView(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StudentInformationView());
    }

    


    private void NavigateToCoursesView(object sender, EventArgs e)
    {
        CourseView courseView = new CourseView();

        // Set the BindingContext to the existing CourseViewModel instance
        courseView.BindingContext = CourseViewModel.Instance;

        Navigation.PushAsync(courseView);
    }

}