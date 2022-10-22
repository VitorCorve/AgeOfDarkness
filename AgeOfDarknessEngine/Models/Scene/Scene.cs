using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Gameplay.Resources;

namespace AgeOfDarknessEngine.Models.Scene
{
    public class Scene
    {
        public SceneBase Base { get; set; } = new SceneBase();
        public ICollection<Character>? Characters { get; set; }
        public ICollection<Resource>? Resources { get; set; }
    }
}
