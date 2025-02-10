

using System.ComponentModel;

namespace Canvas.Models
{
    public class Student 
    {

        public string? Name { get; set; }
        public int Id { get; set; }
        public StudentClassification Classification { get; set; }

        public override string ToString()
        {
            return $"{Name} {Id} ({Classification})";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateInformation(string name, StudentClassification classification)
        {
            Name = name ?? string.Empty;
            Classification = classification;
        }
    }

    public enum StudentClassification
    {
        Freshman, Sophomore, Junior, Senior
    }
}
