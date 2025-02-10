using Canvas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.viewmodels
{
    public class AddModuleViewModel
    {
        public Course SelectedCourse { get; set; }
        public ObservableCollection<Module> Modules { get; set; }
        public ObservableCollection<ContentItem> ContentItems { get; set; }





        public AddModuleViewModel(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
            Modules = new ObservableCollection<Module>(SelectedCourse.Modules);
            ContentItems = new ObservableCollection<ContentItem>();
        }

        public void AddModule(string name, string description, List<ContentItem> contentItems)
        {


            var newModule = new Module
            {
                Name = name,
                Description = description,
                Content = contentItems
            };

            // Add the module to the list
            Modules.Add(newModule);
            // Add the module to the selected course
            SelectedCourse.Modules.Add(newModule);

        }



    }
}
