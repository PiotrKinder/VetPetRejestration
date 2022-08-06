namespace VetPetRejestration.Enums
{
    public enum Species
    {
        Kot,
        Pies,
        Wąż,
        Żółw,
        Ptak,
        Homik,
        Fretka
    }

    public enum Sex
    {
        Samiec,
        Samica    
    }

    public class SexEnum
    {
        public List<string> Sex { get; set; }
    }

    public class SpeciesEnum
    {
        public List<string> Species { get; set; }
    }
}