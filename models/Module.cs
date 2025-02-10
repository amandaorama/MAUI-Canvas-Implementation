using System;
using System.Collections.Generic;
using System.Linq;

namespace Canvas.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ContentItem> Content { get; set; }

        public Module()
        {
            
            Content = new List<ContentItem>();
        }

        public override string ToString()
        {
            return $"{Name}\nDescription: {Description}\nContent: {string.Join(", ", Content.Select(c => c.Name))}";
        }

        public void UpdateInformation(string name, string description)
        {
            Name = name ?? string.Empty;
            Description = description ?? string.Empty;
        }

        public void AddContentItem(ContentItem contentItem)
        {
            Content.Add(contentItem);
        }
    }
}
