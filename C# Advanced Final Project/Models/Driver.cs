using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace C__Advanced_Final_Project.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        public User driverUser { get; set; }

        public int CurrentPassengers {  get; set; }

        public int MaxCapacity  { get; set; }

        [ValidateNever]
        public int EventID { get; set; }
    }
}
