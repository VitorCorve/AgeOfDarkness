using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.Resources;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Basic class which provides abstractions to manage characters. Derives from <see cref="Society"/>.
    /// </summary>
    public class Character : Society
    {
        public ICollection<Resource>? Resources { get; set; }
        public ICollection<CharacterAbilities>? Abilities { get; set; }
        public bool IsPlayer { get; set; }
        public BasicSocietyKinds SocietyKind { get; set; }
    }
}
