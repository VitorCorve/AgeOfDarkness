using System.ComponentModel.DataAnnotations;

namespace AgeOfDarknessEngine.Models.Scene
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
