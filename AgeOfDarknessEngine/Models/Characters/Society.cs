using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Basuc abstract society-kind class. Derives from <see cref="Bio"/>.
    /// Provides information about <see cref="Kind"/>, <see cref="Relationship"/>, <see cref="SocietyClass"/>,
    /// <see cref="BelongsToClan"/> and <see cref="Nullable"/> <see cref="Community"/>.
    /// </summary>
    public abstract class Society : Bio
    {
        public Kind CharacterKind { get; set; }
        public Relationship RelationshipToPlayer { get; set; } = new Relationship();
        public SocietyClass Class { get; set; }
        public bool BelongsToClan { get; set; }
        public Community? Clan { get; set; }
    }
}
