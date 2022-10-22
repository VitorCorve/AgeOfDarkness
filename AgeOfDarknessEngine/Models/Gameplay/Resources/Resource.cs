namespace AgeOfDarknessEngine.Models.Gameplay.Resources
{
    public abstract class Resource
    {
        public ResourceType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
