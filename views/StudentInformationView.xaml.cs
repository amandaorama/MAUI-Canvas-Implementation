using Canvas.viewmodels;

namespace Canvas.views;

public partial class StudentInformationView : ContentPage
{
	public StudentInformationView()
	{
		InitializeComponent();
        BindingContext = new StudentsViewModel();

    }

    private void AddClicked(object sender, EventArgs e)
    {

        Shell.Current.GoToAsync($"//StudentDetail??studentId= 0");

    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentsViewModel)?.Remove();

    }

    private void UpdateClicked(object sender, EventArgs e)
    {

        var studentId = (BindingContext as StudentsViewModel)?.SelectedStudent?.Id;

        if (studentId != null && studentId != 0)
        {
            Shell.Current.GoToAsync($"//StudentDetail?studentId={studentId}");
        }
    }

        private void BackClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Student");
        }


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentsViewModel)?.Refresh();
    }


}
