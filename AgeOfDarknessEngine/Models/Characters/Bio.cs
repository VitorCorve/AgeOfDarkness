using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Basic asbtract entity information class.
    /// </summary>
    public abstract class Bio
    {
        public string Name { get; set; }
        public Gender CharacterGender { get; set; }
        public string BirthDate { get; set; }
        public bool Alive { get; set; }
        public CharacterStatements CharacterStatement { get; set; }
        public bool IdentityHidden { get; set; }
    }
}
