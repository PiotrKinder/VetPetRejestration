using System.ComponentModel.DataAnnotations;

namespace VetPetRejestration.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public string DateOfBirth {get;set;}
        public string Sex { get; set;}
        public string Description { get; set; }
        public IEnumerable <MedicalHistory> MedicalHistories { get; set; }
        
    }
}
