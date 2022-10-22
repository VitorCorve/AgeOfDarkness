using System.ComponentModel.DataAnnotations;

namespace AgeOfDarknessContext.Models
{
    /// <summary>
    /// Database <see cref="CharacterAsset"/> model.
    /// </summary>
    public class CharacterAsset
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
    }
}
