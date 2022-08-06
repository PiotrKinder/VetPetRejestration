using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetPetRejestration.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [DisplayName("Dzień wizyty")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Należy podać datę wizyty")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                        ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [DisplayName("Godina wizyty")]
        public string Time { get; set; }
        [DisplayName("Cel wizyty")]
        [Required(ErrorMessage = "Należy podać cel wizyty")]
        public string Purpose{ get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("Czy się odbyła")]
        public bool WasHappend { get; set; }

    }
}
