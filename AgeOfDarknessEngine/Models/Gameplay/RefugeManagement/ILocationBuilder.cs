using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.Resources;
using AgeOfDarknessEngine.Models.Scene;

namespace AgeOfDarknessEngine.Models.Gameplay.RefugeManagement
{
    public interface ILocationBuilder
    {
        public ILocationBuilder BuildScene(BasicSceneType basicScene);
        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType);
        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType, SceneTypeComplicationLevel complicationLevel);
        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType, SceneTypeComplicationLevel complicationLevel, SceneSafetyLevel safetyLevel);
        public ILocationBuilder BuildResources(ICollection<Resource> resources);
        public ILocationBuilder BuildResources(SceneTypeComplicationLevel complicationLevel, SceneType sceneType);
        public ILocationBuilder BuildWithPrice(ICollection<Resource> resources);
        public ILocationBuilder BuildWithPrice(SceneTypeComplicationLevel complicationLevel, SceneType sceneType);
        public ILocationBuilder BuildPersonal(ICollection<Character> personal);
        public ILocationBuilder BuildPersonal(SceneTypeComplicationLevel complicationLevel, SceneType sceneType);
        public ILocationBuilder BuildPersonal(SceneTypeComplicationLevel complicationLevel, SceneType sceneType, Gender preferablyGender);
        public ILocationBuilder BuildGuards(SceneTypeComplicationLevel complicationLevel);
        public ILocationBuilder BuildGuards(SceneTypeComplicationLevel complicationLevel, Gender preferablyGender);
        public ILocationBuilder BuildGuards(ICollection<Character> guards);
        public ILocationBuilder BuildAbilities();
        public ILocationBuilder BuildAbilities(ICollection<LocationAbilities> abilities);
        public ILocationBuilder BuildCharacters(ICollection<Character> characters);
        public ILocationBuilder BuildCharacters(SceneTypeComplicationLevel complicationLevel, SceneType sceneType);
        public ILocationBuilder BuildCharacters(SceneTypeComplicationLevel complicationLevel, SceneType sceneType, Gender preferablyGender);
        public ILocationBuilder BuildDefense(int defenseValue);
        public ILocationBuilder BuildDefense(SceneTypeComplicationLevel complicationLevel, SceneType sceneType);
        public ILocationBuilder BuildWithTown();
        public ILocationBuilder BuildWithTown(Town town);
        public ILocationBuilder BuildOwner();
        public ILocationBuilder BuildOwner(Character owner);
        public ILocationBuilder BuildOwnersCommunity();
        public ILocationBuilder BuildOwnersCommunity(Community clan);
        public ILocationBuilder BuildKingdom(Kingdom kingdom);
        public Location Build(int refugeId);
        public Location Build();
    }
}
