using Canvas.Models;
using Canvas.Services;
using Canvas.viewmodels;

namespace Canvas.dialogue;


[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentDialogue : ContentPage
{

    public int StudentId { get; set; }
	public StudentDialogue()
	{
		InitializeComponent();
        BindingContext = new StudentDialogueViewModel(0);
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentInformation");
    }

    private void OkClicked(object sender, EventArgs e)
    {

        (BindingContext as StudentDialogueViewModel)?.Add();
        Shell.Current.GoToAsync("//StudentInformation");
        
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
  {
       BindingContext = new StudentDialogueViewModel(StudentId);
   }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is Picker picker)
        {
            // Get the selected item
            StudentClassification selectedClassification = (StudentClassification)picker.SelectedItem;

            // Update the SelectedClassification property in the view model
            ((StudentDialogueViewModel)BindingContext).SelectedClassification = selectedClassification;
        }
    }



}