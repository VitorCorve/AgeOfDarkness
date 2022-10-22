using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Characters
{
    /// <summary>
    /// Glory values, which is used to show threatment levels for tracking inheritor <see cref="Glory"/>, until the one will be discovered.
    /// </summary>
    public class Glory
    {
        public VampireGloryBase VampireGloryKind { get; set; }
        public VampireGloryStages VampireGloryStage { get; set; }
    }
}
