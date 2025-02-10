using Canvas.Models;
using Canvas.viewmodels;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Canvas.views;

public partial class AddStudentToCourseView : ContentPage
{


    public ObservableCollection<string> Students { get; set; } = new ObservableCollection<string>();
    public Course SelectedCourse { get; set; }





    public AddStudentToCourseView(Course courseName)
    {
        InitializeComponent();
        
        BindingContext = new AddStudentToCourseViewModel(courseName);
    
    }





    private void AddStudent_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtId.Text) &&
                !string.IsNullOrWhiteSpace(txtClassification.Text))
        {
            // Get the ViewModel from the BindingContext
            var viewModel = (AddStudentToCourseViewModel)BindingContext;

            if (int.TryParse(txtId.Text, out int id))
            {
                // Convert txtClassification.Text to a StudentClassification
                if (Enum.TryParse(txtClassification.Text, out StudentClassification classification))
                {
                    // Add the student to the ViewModel
                    viewModel.AddStudent(txtName.Text, id, classification);

                    // Clear input fields
                    txtName.Text = "";
                    txtId.Text = "";
                    txtClassification.Text = "";
                }
                else
                {

                    DisplayAlert("Incomplete Information", "Please fill in all fields correctly", "OK");
                }

            }

        }
    }

    
 

    private async void BackClicked(object sender, EventArgs e)
        {
        await Navigation.PopAsync();
    }
    
}




