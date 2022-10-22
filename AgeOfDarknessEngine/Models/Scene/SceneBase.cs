using AgeOfDarknessEngine.Models.Enums;

namespace AgeOfDarknessEngine.Models.Scene
{
    public class SceneBase
    {
        public string Name { get; set; } = string.Empty;
        public BasicSceneType BasicScene { get; set; }
        public SceneType Type { get; set; }
        public SceneSafetyLevel SafetyLevel { get; set; }
        public SceneTypeComplicationLevel ComplicationLevel { get; set; }
    }
}
