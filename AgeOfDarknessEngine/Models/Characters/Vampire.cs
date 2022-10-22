using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Basic vampire character class, which one derives from <see cref="Character"/>.
    /// Includes <see cref="Glory"/>, <see cref="Hunger"/>, <see cref="Wanted"/> and <see cref="VampireKind"/> values.
    /// </summary>
    public class Vampire : Character
    {
        public Glory VampireGlory { get; set; } = new Glory();
        public Hunger HungerValue { get; set; } = new Hunger();
        public bool Wanted { get; set; }
        public VampireKind Kind { get; set; }
    }
}
