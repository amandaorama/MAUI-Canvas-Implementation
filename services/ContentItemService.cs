using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.Models;

namespace Canvas.Services
{
    public class ContentItemService
    {
        private IList<ContentItem> contentItems;
        private static ContentItemService? instance;
        private static object _lock = new object();

        public static ContentItemService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ContentItemService();
                    }
                }

                return instance;
            }
        }

        private ContentItemService()
        {
            contentItems = new List<ContentItem>();
        }

        public IEnumerable<ContentItem> ContentItems
        {
            get
            {
                return contentItems;
            }
        }

        public void AddContentItem()
        {
            Console.WriteLine("Enter Content Item Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Content Item Path: ");
            var path = Console.ReadLine();
            Console.WriteLine("Enter Content Item Description: ");
            var description = Console.ReadLine();

            var contentItem = new ContentItem
            {
                Name = name,
               // Path = path,
                Description = description
            };

            contentItems.Add(contentItem);
            Console.WriteLine("Content Item added successfully!");
            Console.Write("\n "); 
        }

        public void UpdateContentItem()
        {
            Console.WriteLine("Enter Content Item Name to update: ");
            var contentItemName = Console.ReadLine();

            var contentItem = contentItems.FirstOrDefault(c => c.Name == contentItemName);

            if (contentItem == null)
            {
                Console.WriteLine("Content Item not found.");
                return;
            }

            Console.WriteLine("Enter new Content Item Name: ");
            var newName = Console.ReadLine();
            Console.WriteLine("Enter new Content Item Path: ");
            var newPath = Console.ReadLine();
            Console.WriteLine("Enter new Content Item Description: ");
            var newDescription = Console.ReadLine();

            contentItem.UpdateInformation(newName ?? string.Empty, newPath ?? string.Empty, newDescription ?? string.Empty);
            Console.WriteLine("Content Item information updated successfully!");
            Console.Write("\n "); 
        }

        public void DeleteContentItem()
        {
            Console.WriteLine("Enter Content Item Name to delete: ");
            var contentItemName = Console.ReadLine();

            var contentItemToDelete = contentItems.FirstOrDefault(c => c.Name == contentItemName);

            if (contentItemToDelete == null)
            {
                Console.WriteLine("Content Item not found.");
                return;
            }

            contentItems.Remove(contentItemToDelete);
            Console.WriteLine("Content Item deleted successfully!");
            Console.Write("\n "); 
        }

        public void ListContentItems()
        {
            Console.WriteLine("All Content Items:");
            foreach (var contentItem in contentItems)
            {
            //    Console.WriteLine($"{contentItem.Name} - Path: {contentItem.Path}");
            }
        }
    }
}
