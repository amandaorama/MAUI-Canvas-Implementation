using System;

namespace Canvas.Models
{
    public class ContentItem
    {
        public string? Name { get; set; }
       
        public string? Description { get; set; }

        public ContentItem()
        {
            Name = string.Empty;
          //  Path = string.Empty;
            Description = string.Empty;
        }

      //  public override string ToString()
      //  {
      //     // return $"{Name}\nDescription: {Description}\nPath: {Path}";
      //  }

        public void UpdateInformation(string name, string path, string description)
        {
            Name = name ?? string.Empty;
            //Path = path ?? string.Empty;
            Description = description ?? string.Empty;
        }
    }
}
