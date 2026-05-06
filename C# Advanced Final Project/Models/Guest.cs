using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace C__Advanced_Final_Project.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }

        [ValidateNever]
        public string GuestUserID { get; set; } = string.Empty;

        [ValidateNever]
        public User? GuestUser { get; set; }

        public string Address { get; set; }
        [Required (ErrorMessage = "Please enter an event")]
        public int AttendingEventId { get; set; }

        [Required]

        public int DriverID { get; set; }
        [ValidateNever]
        public Driver? AssignedDriver { get; set; }

    }
}
