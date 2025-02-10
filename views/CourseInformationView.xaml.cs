using Canvas.Models;
using Canvas.Services;
using Canvas.viewmodels;
using System.Diagnostics;


namespace Canvas.views;

public partial class CourseInformationView : ContentPage
{



    public CourseInformationView(Course selectedCourse)
    {
        InitializeComponent();
        BindingContext = selectedCourse;

    }



    private Assignment selectedAssignment;

    private void OnAssignmentTapped(object sender, ItemTappedEventArgs e)
    {
        // Set the selected assignment
        selectedAssignment = e.Item as Assignment;
    }



    private async void SubmitAssignment_Clicked(object sender, EventArgs e)
    {
        if (selectedAssignment != null)
        {
            // Open file picker
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a file"
            });

            if (file != null)
            {
                // Show confirmation
                await DisplayAlert("Success", "Assignment successfully submitted.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Please select an assignment first.", "OK");
        }

    }




    private async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}