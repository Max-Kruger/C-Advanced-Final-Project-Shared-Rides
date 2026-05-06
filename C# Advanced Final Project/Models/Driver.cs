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

    }
}
