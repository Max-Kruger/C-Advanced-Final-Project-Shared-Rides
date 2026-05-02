namespace C__Advanced_Final_Project.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        public User DriverUser { get; set; }

        public int CurrentPassengers {  get; set; }

        public int MaxCapacity  { get; set; }
    }
}
