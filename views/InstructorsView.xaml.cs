using Canvas.Models;
using Canvas.Services;
using Canvas.viewmodels;


namespace Canvas.views;

public partial class InstructorsView : ContentPage
{
	public InstructorsView()
	{
		InitializeComponent();
	}



    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }



    private async void ViewClasses_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewClasses());
    }



 
   

   
  

}