using Microsoft.AspNetCore.Identity;

namespace VetPetRejestration.Models
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
