

using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Event
    {
        public int EventID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a date")]
        public DateOnly EventDate { get; set; }

        public int Drivers { get; set; } = 0;

        

        


    }
}
