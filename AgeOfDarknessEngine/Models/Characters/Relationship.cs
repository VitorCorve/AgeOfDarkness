using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Relationships class, which one provides information about entity relationsip levels targeted to player.
    /// Includes <see cref="RelationshipsStages"/> and <see cref="RelationshipBase"/> values.
    /// </summary>
    public class Relationship
    {
        public RelationshipsStages Stage { get; set; }
        public RelationshipBase RelationShipKind { get; set; }
    }
}
