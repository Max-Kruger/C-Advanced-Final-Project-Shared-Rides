using Microsoft.AspNetCore.Identity;

namespace C__Advanced_Final_Project.Models
{
    public class User : IdentityUser 
    {

        public string FName { get; set; }

        public string LName { get; set; }
    }
}
