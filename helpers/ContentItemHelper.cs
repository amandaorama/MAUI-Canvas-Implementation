using System;
using Canvas.Services;


namespace Canvas.Helpers
{
    public static class ContentItemHelper
    {
        private static ContentItemService contentItemService = ContentItemService.Current;

        public static void HandleContentItemOptions()
        {
            Console.WriteLine("A. Add a Content Item");
            Console.WriteLine("U. Update a Content Item");
            Console.WriteLine("D. Delete a Content Item");

            string? choice = Console.ReadLine();

            switch (choice?.ToUpper())
            {
                case "A":
                    contentItemService.AddContentItem();
                    break;
                case "U":
                    contentItemService.UpdateContentItem();
                    break;
                case "D":
                    contentItemService.DeleteContentItem();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            contentItemService.ListContentItems();
        }
    }
}
