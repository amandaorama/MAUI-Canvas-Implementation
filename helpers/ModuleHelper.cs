using System;
using Canvas.Services;
using Canvas.Models;


namespace Canvas.Helpers
{
    public static class ModuleHelper
    {
        private static ModuleService moduleService = ModuleService.Current;

        public static void HandleModuleOptions()
        {
            Console.WriteLine("A. Add a Module");
            Console.WriteLine("U. Update a Module");
            Console.WriteLine("D. Delete a Module");

            string? choice = Console.ReadLine();

            switch (choice?.ToUpper())
            {
                case "A":
                    moduleService.AddModule();
                    break;
                case "U":
                    moduleService.UpdateModule();
                    break;
                case "D":
                    moduleService.DeleteModule();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            moduleService.ListModules();
        }
    }
}
