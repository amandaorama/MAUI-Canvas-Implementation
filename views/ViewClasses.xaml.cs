using Canvas.Models;
using Canvas.Services;
using Canvas.viewmodels;
namespace Canvas.views;

public partial class ViewClasses : ContentPage
{
	
    private readonly CourseViewModel _viewModel;

    public ViewClasses()
    {
        InitializeComponent();
        BindingContext = CourseViewModel.Instance;
    }



  

    protected override void OnAppearing()
    {
        base.OnAppearing();


        if (CourseViewModel.Instance.Courses == null || CourseViewModel.Instance.Courses.Count == 0)
        {
            // Display an alert if there are no courses
            DisplayAlert("No Courses", "No courses are available.", "OK");
        }
        else
        {
            // Set the ItemsSource of the ListView to the Courses collection
            coursesListView.ItemsSource = CourseViewModel.Instance.Courses;
        }

    }





    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }




    private async void OnCourseTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Course selectedCourse)
        {
            // Navigate to course information view, passing the selected course
            await Navigation.PushAsync(new CourseInformationView(selectedCourse));
        }
    }

    

}

