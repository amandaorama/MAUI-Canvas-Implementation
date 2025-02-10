using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Models;

namespace Canvas.Services
{
    public class ModuleService
    {
        private IList<Module> modules;
        private static ModuleService? instance;
        private static object _lock = new object();

        public static ModuleService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ModuleService();
                    }
                }

                return instance;
            }
        }

        private ModuleService()
        {
            modules = new List<Module>();
        }

        public IEnumerable<Module> Modules
        {
            get
            {
                return modules;
            }
        }

        public void AddModule()
        {
            Console.WriteLine("Enter Module Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Module Description: ");
            var description = Console.ReadLine();

            var module = new Module
            {
                Name = name,
                Description = description
            };

            modules.Add(module);
            Console.WriteLine("Module added successfully!");
            Console.Write("\n "); 
        }

        public void UpdateModule()
        {
            Console.WriteLine("Enter Module Name to update: ");
            var moduleName = Console.ReadLine();

            var module = modules.FirstOrDefault(m => m.Name == moduleName);

            if (module == null)
            {
                Console.WriteLine("Module not found.");
                Console.Write("\n "); 
                return;
            }

            Console.WriteLine("Enter new Module Name: ");
            var newName = Console.ReadLine();
            Console.WriteLine("Enter new Module Description: ");
            var newDescription = Console.ReadLine();

            module.UpdateInformation(newName ?? string.Empty, newDescription ?? string.Empty);
            Console.WriteLine("Module information updated successfully!");
            Console.Write("\n "); 
        }

        public void DeleteModule()
        {
            Console.WriteLine("Enter Module Name to delete: ");
            var moduleName = Console.ReadLine();

            var moduleToDelete = modules.FirstOrDefault(m => m.Name == moduleName);

            if (moduleToDelete == null)
            {
                Console.WriteLine("Module not found.");
                return;
            }

            modules.Remove(moduleToDelete);
            Console.WriteLine("Module deleted successfully!");
            Console.Write("\n "); 
        }

        public void ListModules()
        {
            Console.WriteLine("All Modules:");
            foreach (var module in modules)
            {
                Console.WriteLine($"{module.Name}");
            }
        }
    }
}
