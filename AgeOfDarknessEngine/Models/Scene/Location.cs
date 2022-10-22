using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.Resources;
using System.ComponentModel.DataAnnotations;

namespace AgeOfDarknessEngine.Models.Scene
{
    public class Location : Scene
    {
        [Key]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int? OwnerId { get; set; }
        public ICollection<Resource>? Price { get; set; }
        public ICollection<Character>? Guards { get; set; }
        public ICollection<Character>? Personal { get; set; }
        public ICollection<LocationAbilities>? Abilities { get; set; }
        public Community? Community { get; set; }
        public Character? Owner { get; set; }
        public Town? Town { get; set; }
        public Kingdom? Kingdom { get; set; }
        public int Defense { get; set; } = 0;
    }
}
