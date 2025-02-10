using Canvas.Models;
using Canvas.viewmodels;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Canvas.views;

public partial class AddAssignmentView : ContentPage
{

    public ObservableCollection<string> Assignment { get; set; } = new ObservableCollection<string>();
    public Course SelectedCourse { get; set; }



    public AddAssignmentView(Course courseName)
        {
            InitializeComponent();
            BindingContext = new AddAssignmentViewModel(courseName);
        }






        private void AddAssignment_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAssignmentName.Text) &&
                dpDueDate.Date != null &&
                !string.IsNullOrWhiteSpace(txtAssignmentDescription.Text))
            {
                var viewModel = (AddAssignmentViewModel)BindingContext;

                // Create a new assignment
                var newAssignment = new Assignment
                {
                    Name = txtAssignmentName.Text,
                    DueDate = dpDueDate.Date,
                    Description = txtAssignmentDescription.Text
                };

            // Add the assignment to the view model
            viewModel.AddAssignment(txtAssignmentName.Text, txtAssignmentDescription.Text, dpDueDate.Date);

            // Clear input fields
            txtAssignmentName.Text = "";
                dpDueDate.Date = DateTime.Today;
                txtAssignmentDescription.Text = "";
            
        }
            else
            {
                DisplayAlert("Incomplete Information", "Please fill in all fields", "OK");
            }
        }






    private async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

