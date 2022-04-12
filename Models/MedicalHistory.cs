using System.ComponentModel.DataAnnotations;

namespace VetPetRejestration.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
