using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace C__Advanced_Final_Project.Models
{
    public class User : IdentityUser 
    {
        public string FName { get; set; }

        public string LName { get; set; }
        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;
    }
}
