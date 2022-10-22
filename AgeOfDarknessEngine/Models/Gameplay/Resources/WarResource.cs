namespace AgeOfDarknessEngine.Models.Gameplay.Resources
{
    public class WarResource : Resource
    {
        public WarResource(int count)
        {
            Count = count;
            Type = ResourceType.War;
            Name = "War resources";
        }
    }
}
