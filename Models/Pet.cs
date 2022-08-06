using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VetPetRejestration.Enums;

namespace VetPetRejestration.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [DisplayName("Gatunek")]
        [Required(ErrorMessage = "Przed dodaniem pupila musisz podać jego gatunek")]
        public string Species { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Podaj imię swojego pupila")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Długość imienia musi byc w zakresie 2 - 20")]
        public string Name { get; set; }
        [DisplayName("Data urodzenia")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Należy podać datę urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                        ApplyFormatInEditMode = true)]
        public string DateOfBirth {get;set;}
        [DisplayName("Płeć")]
        [Required(ErrorMessage = "Należy podać płeć")]
        public string Sex { get; set;}
        [DisplayName("Znaki szczególne")]
        public string Description { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        public List<Registration> Registration { get; set; } = new List<Registration>();
        public bool Visible { get; set; }
    }
}
