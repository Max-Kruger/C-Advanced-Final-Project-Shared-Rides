using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace C__Advanced_Final_Project.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }

        public string DriverUserId { get; set; } = string.Empty;

        public User? DriverUser { get; set; }

        public int remainingPassengers {  get; set; }

        public int MaxCapacity  { get; set; }

        public int? AttendingEventId {  get; set; }

        [Required(ErrorMessage = "Please enter your car make")]
        public string CarMake { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your car model")]
        public string CarModel { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your car color")]
        public string CarColor { get; set; } = string.Empty;

    }
}
