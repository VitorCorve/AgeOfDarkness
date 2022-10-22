using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfDarknessEngine.Models.Gameplay.RefugeManagement
{
    public class LocationDirector
    {
        private readonly LocationBuilder _locationBuilder;
        private readonly Random _random;
        public LocationDirector()
        {
            _locationBuilder = new LocationBuilder();
            _random = new Random();
        }
        public Location BuildPublicHome(SceneTypeComplicationLevel sceneTypeComplicationLevel) 
        {
            Location refuge =  _locationBuilder.BuildGuards(sceneTypeComplicationLevel)
                .BuildPersonal(sceneTypeComplicationLevel, SceneType.PublicHome, Gender.Female)
                .BuildResources(sceneTypeComplicationLevel, SceneType.PublicHome)
                .BuildWithPrice(sceneTypeComplicationLevel, SceneType.PublicHome)
                .BuildScene(BasicSceneType.Town, SceneType.PublicHome, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.PublicHome, Gender.Male)
                .BuildDefense(sceneTypeComplicationLevel, SceneType.PublicHome)
                .BuildOwner()
                .BuildWithTown()
                .Build();

            return refuge;
        }

        public Location BuildClinic(SceneTypeComplicationLevel sceneTypeComplicationLevel)
        {
            Location refuge = _locationBuilder.BuildGuards(sceneTypeComplicationLevel)
                .BuildPersonal(sceneTypeComplicationLevel, SceneType.Clinic)
                .BuildResources(sceneTypeComplicationLevel, SceneType.Clinic)
                .BuildWithPrice(sceneTypeComplicationLevel, SceneType.Clinic)
                .BuildScene(BasicSceneType.Town, SceneType.Clinic, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.Clinic)
                .BuildDefense(sceneTypeComplicationLevel, SceneType.Clinic)
                .BuildOwner()
                .BuildWithTown()
                .Build();

            return refuge;
        }

        public Location BuildCitizanHome(SceneTypeComplicationLevel sceneTypeComplicationLevel)
        {
            Location refuge = _locationBuilder.BuildResources(sceneTypeComplicationLevel, SceneType.CitizanHome)
                .BuildWithPrice(sceneTypeComplicationLevel, SceneType.CitizanHome)
                .BuildScene(BasicSceneType.Town, SceneType.CitizanHome, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.CitizanHome)
                .BuildDefense(sceneTypeComplicationLevel, SceneType.CitizanHome)
                .BuildOwner()
                .BuildWithTown()
                .Build();

            return refuge;
        }

        public Location BuildMarket(SceneTypeComplicationLevel sceneTypeComplicationLevel)
        {
            Location refuge = _locationBuilder.BuildGuards(sceneTypeComplicationLevel)
                .BuildPersonal(sceneTypeComplicationLevel, SceneType.Market)
                .BuildResources(sceneTypeComplicationLevel, SceneType.Market)
                .BuildWithPrice(sceneTypeComplicationLevel, SceneType.Market)
                .BuildScene(BasicSceneType.Town, SceneType.Market, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.Market)
                .BuildDefense(sceneTypeComplicationLevel, SceneType.Market)
                .BuildOwner()
                .BuildWithTown()
                .Build();

            return refuge;
        }

        public Location BuildCastle(SceneTypeComplicationLevel sceneTypeComplicationLevel)
        {
            Location refuge = _locationBuilder.BuildGuards(sceneTypeComplicationLevel)
                .BuildPersonal(sceneTypeComplicationLevel, SceneType.Castle)
                .BuildResources(sceneTypeComplicationLevel, SceneType.Castle)
                .BuildWithPrice(sceneTypeComplicationLevel, SceneType.Castle)
                .BuildScene(BasicSceneType.Town, SceneType.Market, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.Castle)
                .BuildDefense(sceneTypeComplicationLevel, SceneType.Castle)
                .BuildOwner()
                .BuildWithTown()
                .Build();

            return refuge;
        }
        public Location BuildStreet(SceneTypeComplicationLevel sceneTypeComplicationLevel)
        {
            Location refuge = _locationBuilder.BuildGuards(sceneTypeComplicationLevel)
                .BuildPersonal(sceneTypeComplicationLevel, SceneType.Street)
                .BuildScene(BasicSceneType.Town, SceneType.Street, sceneTypeComplicationLevel)
                .BuildCharacters(sceneTypeComplicationLevel, SceneType.Street)
                .BuildWithTown()
                .Build();

            return refuge;
        }
    }
}
