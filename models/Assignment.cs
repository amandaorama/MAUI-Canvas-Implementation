using System;

namespace Canvas.Models
{
    public class Assignment
    {
        public string? Name { get; set; }
        public string? TotalAvailablePoints { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment()
        {
            Name = string.Empty;
            TotalAvailablePoints = string.Empty;
            Description = string.Empty;
            DueDate = DateTime.MinValue;
        }

        public override string ToString()
        {
            return $"{Name}\nDescription: {Description}\nTotal Available Points: {TotalAvailablePoints}\nDue Date: {DueDate}";
        }

        public void UpdateInformation(string name, string totalAvailablePoints, string description, DateTime dueDate)
        {
            Name = name ?? string.Empty;
            TotalAvailablePoints = totalAvailablePoints ?? string.Empty;
            Description = description ?? string.Empty;
            DueDate = dueDate;
        }
    }
}
