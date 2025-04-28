using Microsoft.AspNetCore.Identity;
using SashoApp.Models.Cars;


namespace SashoApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
