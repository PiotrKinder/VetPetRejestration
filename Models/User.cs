using Microsoft.AspNetCore.Identity;

namespace VetPetRejestration.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Pet> Pets { get; set; }= new List<Pet>();
    }
}
