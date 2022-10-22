using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Gameplay
{
    public class Hunger
    {
        public HungerBase HungerStatus { get; set; }
        public HungerStages Stage { get; set; }
    }
}
