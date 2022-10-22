namespace AgeOfDarknessEngine.Models.Gameplay.Resources
{
    public class Money : Resource
    {
        public Money(int count)
        {
            Name = "Money";
            Type = ResourceType.Money;
            Count = count;
        }
    }
}
