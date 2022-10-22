namespace AgeOfDarknessEngine.Models.Gameplay.Resources
{
    public class LiveResources : Resource
    {
        public LiveResources(int count)
        {
            Name = "Live resources";
            Type = ResourceType.Live;
            Count = count;
        }
    }
}
