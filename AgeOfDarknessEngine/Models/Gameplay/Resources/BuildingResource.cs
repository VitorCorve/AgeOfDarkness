namespace AgeOfDarknessEngine.Models.Gameplay.Resources
{
    public class BuildingResource : Resource
    {
        public BuildingResource(int count)
        {
            Name = "Building resources";
            Type = ResourceType.Building;
            Count = count;
        }
    }
}
