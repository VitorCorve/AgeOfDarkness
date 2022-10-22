using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Basic normal, non-vampire character class, which one derives from <see cref="Character"/>.
    /// Includes <see cref="HumanToVampireTransformationStages"/> value.
    /// </summary>
    public class Human : Character
    {
        public HumanToVampireTransformationStages TransformationStages { get; set; }
    }
}
