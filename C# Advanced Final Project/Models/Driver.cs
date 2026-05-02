namespace C__Advanced_Final_Project.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        public string DriverName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int CurrentPassengers {  get; set; }

        public int MaxCapacity  { get; set; }
    }
}
