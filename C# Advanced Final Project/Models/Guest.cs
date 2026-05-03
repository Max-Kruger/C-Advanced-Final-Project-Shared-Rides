using System.ComponentModel.DataAnnotations;

namespace C__Advanced_Final_Project.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }

        public User GuestUser { get; set; }

        public string Address { get; set; }
        [Required (ErrorMessage = "Please enter an event")]
        public Event? AttendingEvent { get; set; }

        public int DriverID { get; set; }

        public Driver? AssignedDriver { get; set; }

    }
}
