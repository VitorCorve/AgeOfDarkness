using AgeOfDarknessContext.Models;
using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.CharactersManagement;
using AgeOfDarknessEngine.Models.Gameplay.Resources;
using AgeOfDarknessEngine.Models.Scene;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8605 // Распаковка-преобразование вероятного значения NULL.

namespace AgeOfDarknessEngine.Models.Gameplay.RefugeManagement
{
    public class LocationBuilder : ILocationBuilder
    {
        private Location _location;
        private readonly CharacterDirector _characterDirector;
        private readonly Random _random;
        private List<TownAsset> _availableTowns;
        public LocationBuilder()
        {
            _location = new Location();
            _characterDirector = new CharacterDirector();
            _random = new Random();
        }
        public Location Build()
        {
            Location result = _location;
            _location = new Location();
            return result;
        }

        public ILocationBuilder BuildAbilities()
        {
            _location.Abilities = new List<LocationAbilities>();
            return this;
        }

        public ILocationBuilder BuildAbilities(ICollection<LocationAbilities> abilities)
        {
            _location.Abilities = abilities;
            return this;
        }

        public Location Build(int refugeId)
        {
            Location result = _location;
            _location = new Location();
            return result;
        }

        public ILocationBuilder BuildGuards(ICollection<Character> guards)
        {
            _location.Guards = guards;
            return this;
        }
        public ILocationBuilder BuildGuards(SceneTypeComplicationLevel complicationLevel)
        {
            List<Character> guards = new();
            int guardsCount = _random.Next(0, (int)complicationLevel * 5);

            for (int i = 0; i < guardsCount; i++)
            {
                bool buildGuard = _random.Next(0, 100) < 100 - (int)complicationLevel;

                if (buildGuard)
                {
                    Character guard = _characterDirector.BuildRandomGuard();
                    guards.Add(guard);
                }
            }

            if (!guards.Any())
            {
                Character guard = _characterDirector.BuildRandomGuard();
                guards.Add(guard);
            }

            _location.Guards = guards;
            return this;
        }

        public ILocationBuilder BuildGuards(SceneTypeComplicationLevel complicationLevel, Gender preferablyGender)
        {
            List<Character> guards = new();
            int guardsCount = _random.Next(0, (int)complicationLevel * 5);

            for (int i = 0; i < guardsCount; i++)
            {
                bool buildGuard = _random.Next(0, 100) < 100 - (int) complicationLevel;

                if (buildGuard)
                {
                    Character guard = _characterDirector.BuildRandomGuard(preferablyGender);
                    guards.Add(guard);
                }
            }

            if (!guards.Any())
            {
                Character guard = _characterDirector.BuildRandomGuard(preferablyGender);
                guards.Add(guard);
            }

            _location.Guards = guards;
            return this;
        }

        public ILocationBuilder BuildPersonal(SceneTypeComplicationLevel complicationLevel, SceneType sceneType)
        {
            List<Character> personal = new();
            int personalCount = _random.Next(0, (int)complicationLevel * 5);

            for (int i = 0; i < personalCount; i++)
            {
                bool buildPersonal = _random.Next(0, 100) < 100 - (int)complicationLevel;

                if (buildPersonal)
                {
                    Character persone = _characterDirector.BuildSpecifiedPersonal(sceneType);
                    personal.Add(persone);
                }
            }

            if (!personal.Any())
            {
                Character persone = _characterDirector.BuildSpecifiedPersonal(sceneType);
                personal.Add(persone);
            }

            _location.Personal = personal;
            return this;
        }

        public ILocationBuilder BuildPersonal(SceneTypeComplicationLevel complicationLevel, SceneType sceneType, Gender preferablyGender)
        {
            List<Character> personal = new();
            int personalCount = _random.Next(0, (int)complicationLevel * 5);

            for (int i = 0; i < personalCount; i++)
            {
                bool buildPersonal = _random.Next(0, 100) < 100 - (int)complicationLevel;

                if (buildPersonal)
                {
                    Character persone = _characterDirector.BuildSpecifiedPersonal(sceneType, preferablyGender);
                    personal.Add(persone);
                }
            }

            if (!personal.Any())
            {
                Character persone = _characterDirector.BuildSpecifiedPersonal(sceneType, preferablyGender);
                personal.Add(persone);
            }

            _location.Personal = personal;
            return this;
        }

        public ILocationBuilder BuildPersonal(ICollection<Character> personal)
        {
            _location.Personal = personal;
            return this;
        }

        public ILocationBuilder BuildResources(SceneTypeComplicationLevel complicationLevel, SceneType sceneType)
        {
            _location.Resources = new List<Resource>();

            int cycle = 0;

            while (cycle < 4)
            {
                bool generateResource = _random.Next(0, 100) > 30;

                if (generateResource)
                {
                    int value = 0;

                    switch (sceneType)
                    {
                        case SceneType.Undefined:
                            value = 0;
                            break;
                        case SceneType.Street:
                            value = _random.Next(0, 600);
                            break;
                        case SceneType.CitizanHome:
                            value = _random.Next(0, 1200);
                            break;
                        case SceneType.Clinic:
                            value = _random.Next(0, 800);
                            break;
                        case SceneType.PublicHome:
                            value = _random.Next(0, 3000);
                            break;
                        case SceneType.Market:
                            value = _random.Next(50, 2400);
                            break;
                        case SceneType.Castle:
                            value = _random.Next(100, 4400);
                            break;
                        case SceneType.Bank:
                            value = _random.Next(2000, 1000);
                            break;
                        default:
                            break;
                    }

                    value *= (int)complicationLevel;

                    switch (cycle)
                    {
                        case 0:
                            _location.Resources.Add(new Money(value));
                            break;
                        case 1:
                            _location.Resources.Add(new BuildingResource(value));
                            break;
                        case 2:
                            _location.Resources.Add(new LiveResources(value));
                            break;
                        case 3:
                            _location.Resources.Add(new WarResource(value));
                            break;
                    }
                }
                cycle++;
            }
            return this;
        }

        public ILocationBuilder BuildResources(ICollection<Resource> resources)
        {
            _location.Resources = resources;
            return this;
        }

        public ILocationBuilder BuildWithPrice(SceneTypeComplicationLevel complicationLevel, SceneType sceneType)
        {
            _location.Price = new List<Resource>();

            int value = 0;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    value = 0;
                    break;
                case SceneType.Street:
                    value = 0;
                    break;
                case SceneType.CitizanHome:
                    value = _random.Next(12000, 16000);
                    break;
                case SceneType.Clinic:
                    value = _random.Next(50000, 82000);
                    break;
                case SceneType.PublicHome:
                    value = _random.Next(30000, 70000);
                    break;
                case SceneType.Market:
                    value = _random.Next(15000, 24000);
                    break;
                case SceneType.Castle:
                    value = _random.Next(80000, 120000);
                    break;
                case SceneType.Bank:
                    value = _random.Next(180000, 320000);
                    break;
            }

            value *= (int)complicationLevel;
            Money money = new(value);

            _location.Price.Add(money);
            return this;
        }

        public ILocationBuilder BuildWithPrice(ICollection<Resource> price)
        {
            _location.Price = price;
            return this;
        }

        public ILocationBuilder BuildScene(BasicSceneType basicScene)
        {
            Array sceneTypeValues = Enum.GetValues(typeof(SceneType));
            Array complicationLevelValues = Enum.GetValues(typeof(SceneTypeComplicationLevel));
            Array safetyLevelValues = Enum.GetValues(typeof(SceneSafetyLevel));
            SceneType sceneType = (SceneType)sceneTypeValues.GetValue(_random.Next(sceneTypeValues.Length));
            SceneTypeComplicationLevel complicationLevel = (SceneTypeComplicationLevel)complicationLevelValues.GetValue(_random.Next(complicationLevelValues.Length));
            SceneSafetyLevel safetyLevel = (SceneSafetyLevel)safetyLevelValues.GetValue(_random.Next(safetyLevelValues.Length));

            _location.Base.BasicScene = basicScene;
            _location.Base.Type = sceneType;
            _location.Base.ComplicationLevel = complicationLevel;
            _location.Base.SafetyLevel = safetyLevel;
            return this;
        }

        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType)
        {
            Array complicationLevelValues = Enum.GetValues(typeof(SceneTypeComplicationLevel));
            Array safetyLevelValues = Enum.GetValues(typeof(SceneSafetyLevel));
            SceneTypeComplicationLevel complicationLevel = (SceneTypeComplicationLevel)complicationLevelValues.GetValue(_random.Next(complicationLevelValues.Length));
            SceneSafetyLevel safetyLevel = (SceneSafetyLevel)safetyLevelValues.GetValue(_random.Next(safetyLevelValues.Length));

            _location.Base.BasicScene = basicScene;
            _location.Base.Type = sceneType;
            _location.Base.ComplicationLevel = complicationLevel;
            _location.Base.SafetyLevel = safetyLevel;
            return this;
        }

        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType, SceneTypeComplicationLevel complicationLevel)
        {
            Array safetyLevelValues = Enum.GetValues(typeof(SceneSafetyLevel));
            SceneSafetyLevel safetyLevel = (SceneSafetyLevel)safetyLevelValues.GetValue(_random.Next(safetyLevelValues.Length));

            _location.Base.BasicScene = basicScene;
            _location.Base.Type = sceneType;
            _location.Base.ComplicationLevel = complicationLevel;
            _location.Base.SafetyLevel = safetyLevel;
            return this;
        }

        public ILocationBuilder BuildScene(BasicSceneType basicScene, SceneType sceneType, SceneTypeComplicationLevel complicationLevel, SceneSafetyLevel safetyLevel)
        {
            _location.Base.BasicScene = basicScene;
            _location.Base.Type = sceneType;
            _location.Base.ComplicationLevel = complicationLevel;
            _location.Base.SafetyLevel = safetyLevel;
            return this;
        }

        public ILocationBuilder BuildCharacters(ICollection<Character> characters)
        {
            _location.Characters = characters;
            return this;
        }

        public ILocationBuilder BuildCharacters(SceneTypeComplicationLevel complicationLevel, SceneType sceneType)
        {
            _location.Characters = new List<Character>();

            int charactersCount = 0;
            int complicationLevelValue = (int)complicationLevel;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    break;
                case SceneType.Street:
                    charactersCount = _random.Next(0, 100 + complicationLevelValue);
                    break;
                case SceneType.CitizanHome:
                    charactersCount = _random.Next(0, 5 + complicationLevelValue);
                    break;
                case SceneType.Clinic:
                    charactersCount = _random.Next(0, 60 + complicationLevelValue);
                    break;
                case SceneType.PublicHome:
                    charactersCount = _random.Next(0, 10 + complicationLevelValue);
                    break;
                case SceneType.Market:
                    charactersCount = _random.Next(0, 15 + complicationLevelValue);
                    break;
                case SceneType.Castle:
                    charactersCount = _random.Next(0, 20 + complicationLevelValue);
                    break;
                case SceneType.Bank:
                    charactersCount = _random.Next(0, 15 + complicationLevelValue);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < charactersCount; i++)
            {
                Character character = _characterDirector.BuildRandomCharacter();
                _location.Characters.Add(character);
            }

            return this;
        }

        public ILocationBuilder BuildCharacters(SceneTypeComplicationLevel complicationLevel, SceneType sceneType, Gender preferablyGender)
        {
            _location.Characters = new List<Character>();

            int charactersCount = 0;
            int complicationLevelValue = (int)complicationLevel;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    break;
                case SceneType.Street:
                    charactersCount = _random.Next(0, 100 + complicationLevelValue);
                    break;
                case SceneType.CitizanHome:
                    charactersCount = _random.Next(0, 5 + complicationLevelValue);
                    break;
                case SceneType.Clinic:
                    charactersCount = _random.Next(0, 60 + complicationLevelValue);
                    break;
                case SceneType.PublicHome:
                    charactersCount = _random.Next(0, 10 + complicationLevelValue);
                    break;
                case SceneType.Market:
                    charactersCount = _random.Next(0, 15 + complicationLevelValue);
                    break;
                case SceneType.Castle:
                    charactersCount = _random.Next(0, 20 + complicationLevelValue);
                    break;
                case SceneType.Bank:
                    charactersCount = _random.Next(0, 15 + complicationLevelValue);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < charactersCount; i++)
            {
                Character character = _characterDirector.BuildRandomCharacter(preferablyGender);
                _location.Characters.Add(character);
            }

            return this;
        }

        public ILocationBuilder BuildDefense(int defenseValue)
        {
            _location.Defense = defenseValue;
            return this;
        }

        public ILocationBuilder BuildDefense(SceneTypeComplicationLevel complicationLevel, SceneType sceneType)
        {
            int basicDefenseValue = 0;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    basicDefenseValue = 0;
                    break;
                case SceneType.Street:
                    basicDefenseValue = 0;
                    break;
                case SceneType.CitizanHome:
                    basicDefenseValue = _random.Next(100, 300);
                    break;
                case SceneType.Clinic:
                    basicDefenseValue = _random.Next(800, 1300);
                    break;
                case SceneType.PublicHome:
                    basicDefenseValue = _random.Next(400, 800);
                    break;
                case SceneType.Market:
                    basicDefenseValue = _random.Next(300, 600);
                    break;
                case SceneType.Castle:
                    basicDefenseValue = _random.Next(1200, 1800);
                    break;
                case SceneType.Bank:
                    basicDefenseValue = _random.Next(2000, 4000);
                    break;
                default:
                    break;
            }

            _location.Defense = basicDefenseValue * (int)complicationLevel;
            return this;
        }

        public ILocationBuilder BuildOwner()
        {
            _location.Owner = _characterDirector.BuildRandomCharacter();
            return this;
        }

        public ILocationBuilder BuildOwner(Character owner)
        {
            _location.Owner = owner;
            return this;
        }

        public ILocationBuilder BuildOwnersCommunity()
        {
            throw new NotImplementedException();
        }

        public ILocationBuilder BuildOwnersCommunity(Community community)
        {
            _location.Community = community;
            return this;
        }

        public ILocationBuilder BuildWithTown(Town town)
        {
            _location.Town = town;
            return this;
        }

        public ILocationBuilder BuildWithTown()
        {
            using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
            {
                _availableTowns = _availableTowns ??= context.TownAssets
                    .Include(x => x.KingdomAsset)
                    .Include(x => x.StreetAssets)
                    .ToList();

                int townId = _random.Next(1, _availableTowns.Count());

                TownAsset asset = _availableTowns.FirstOrDefault();
                int streetsCount = asset.StreetAssets.Count();
                int jumpIndex = _random.Next(1, streetsCount);

                StreetAsset streetAsset = asset.StreetAssets.Skip(jumpIndex).FirstOrDefault();

                if (asset is null)
                {
                    BuildWithTown();
                    return this;
                }
                else
                {
                    Character lord = _characterDirector.BuildCharacterById(asset.KingdomAsset.LordId, SocietyClass.Politic);

                    _location.Town = new Town
                    {
                        TownId = asset.TownId,
                        Name = asset.Name,
                    };

                    _location.Kingdom = new Kingdom
                    {
                        KingdomId = asset.KingdomId,
                        KingdomName = asset.KingdomAsset.Name,
                        Lord = lord,
                        LordId = asset.KingdomAsset.LordId
                    };

                    _location.Name = streetAsset.Name;
                    _location.LocationId = streetAsset.StreetId;

                    _availableTowns.Remove(asset);
                }
            }

            return this;
        }

        public ILocationBuilder BuildKingdom(Kingdom kingdom)
        {
            _location.Kingdom = kingdom;
            return this;
        }
    }
}
