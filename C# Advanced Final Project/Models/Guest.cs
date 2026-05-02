using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public string Address { get; set; }
        [Required (ErrorMessage = "Please enter an event")]
        public Event AttendingEvent { get; set; }

    }
}
