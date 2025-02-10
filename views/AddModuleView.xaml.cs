using Canvas.Models;
using Canvas.viewmodels;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Canvas.views;

public partial class AddModuleView : ContentPage
{
    
    
        public ObservableCollection<Module> Modules { get; set; } = new ObservableCollection<Module>();
        public Course SelectedCourse { get; set; }





        public AddModuleView(Course selectedCourse)
        {
            InitializeComponent();
            BindingContext = new AddModuleViewModel(selectedCourse);
            SelectedCourse = selectedCourse;
        }






    private void AddContentItem_Clicked(object sender, EventArgs e)
    {
        var newItemEntry = new Entry { Placeholder = "Content Item" };
        contentItemsLayout.Children.Add(newItemEntry);
    }

  



    private void AddModule_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtModuleName.Text) && !string.IsNullOrWhiteSpace(txtModuleDescription.Text))
            {
                var viewModel = (AddModuleViewModel)BindingContext;

            var contentItems = new List<ContentItem>();

            foreach (var child in contentItemsLayout.Children)
            {
                if (child is Entry entry && !string.IsNullOrWhiteSpace(entry.Text))
                {
                    contentItems.Add(new ContentItem { Name = entry.Text });
                }
            }

            // Add the module to the view model
            viewModel.AddModule(txtModuleName.Text, txtModuleDescription.Text, contentItems);

           
         

                // Clear input fields
                txtModuleName.Text = "";
                txtModuleDescription.Text = "";
            contentItemsLayout.Children.Clear();
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

