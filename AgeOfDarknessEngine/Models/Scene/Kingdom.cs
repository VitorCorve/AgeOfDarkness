using AgeOfDarknessEngine.Models.Characters;

namespace AgeOfDarknessEngine.Models.Scene
{
    public class Kingdom
    {
        public int KingdomId { get; set; }
        public string KingdomName { get; set; }
        public int LordId { get; set; }
        public Character Lord { get; set; }
        public ICollection<Town> Towns { get; set; }
    }
}
