using AgeOfDarknessContext.Models;
using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Enums;

#pragma warning disable CS8605 // Распаковка-преобразование вероятного значения NULL.

namespace AgeOfDarknessEngine.Models.Gameplay.CharactersManagement
{
    public class CharacterDirector
    {
        private readonly CharacterBuilder _characterBuilder;
        private readonly Random _random;
        public CharacterDirector()
        {
            _characterBuilder = new CharacterBuilder();
            _random = new Random();
        }
        public Character BuildPlayableCharacter(string name, Gender gender, SocietyClass societyClass)
        {
            Glory glory = new()
            {
                VampireGloryStage = VampireGloryStages.One,
                VampireGloryKind = VampireGloryBase.Unknown,
            };

            Hunger hunger = new()
            {
                Stage = HungerStages.One,
                HungerStatus = HungerBase.Full
            };

            _characterBuilder
                .BuildVampire(hunger, glory, wanted: false, VampireKind.Nosferatu)
                .BuildBio(name, gender, isPlayer: true)
                .BuildIdentity(true)
                .BuildClass(societyClass)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }

        public Character BuildCharacterById(int id, SocietyClass societyClass)
        {
            Glory glory = new()
            {
                VampireGloryStage = VampireGloryStages.One,
                VampireGloryKind = VampireGloryBase.Unknown,
            };

            Hunger hunger = new()
            {
                Stage = HungerStages.One,
                HungerStatus = HungerBase.Full
            };

            using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
            {
                CharacterAsset asset = context.CharacterAssets.Find(id);

                _characterBuilder
                    .BuildHuman(BasicSocietyKinds.Citizen)
                    .BuildBio(asset.Name, asset.Gender == "Male" ? Gender.Male : Gender.Female, asset.BirthDate)
                    .BuildIdentity(true)
                    .BuildClass(societyClass)
                    .BuildRelationships(RelationshipBase.Normal)
                    .BuildResources(societyClass)
                    .BuildAbitilies();
            }

            return _characterBuilder.Build();
        }
        public Character BuildRandomGuard()
        {
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio()
                .BuildIdentity(true)
                .BuildClass(SocietyClass.Soldier)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(SocietyClass.Soldier)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }        
        
        public Character BuildRandomGuard(Gender preferablyGender)
        {
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio(preferablyGender)
                .BuildIdentity(true)
                .BuildClass(SocietyClass.Soldier)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(SocietyClass.Soldier)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }
        public Character BuildRandomCharacter()
        {
            bool isVampire = _random.Next(0, 100) > 90;

            Array societyClassValues = Enum.GetValues(typeof(SocietyClass));
            SocietyClass societyClass = (SocietyClass)societyClassValues.GetValue(_random.Next(societyClassValues.Length));

            if (isVampire)
                _characterBuilder.BuildVampire();
            else
                _characterBuilder.BuildHuman();

            _characterBuilder
                .BuildBio()
                .BuildIdentity(true)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildClass(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }

        public Character BuildRandomCharacter(Gender preferablyGender)
        {
            bool isVampire = _random.Next(0, 100) > 50;

            Array societyClassValues = Enum.GetValues(typeof(SocietyClass));
            SocietyClass societyClass = (SocietyClass)societyClassValues.GetValue(_random.Next(societyClassValues.Length));

            if (isVampire)
                _characterBuilder.BuildVampire();
            else
                _characterBuilder.BuildHuman();

            _characterBuilder
                .BuildBio(preferablyGender)
                .BuildIdentity(true)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildClass(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }
        public Character BuildRandomPersonal(SocietyClass societyClass)
        {
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio()
                .BuildClass(societyClass)
                .BuildIdentity(true)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }        
        
        public Character BuildRandomPersonal(SocietyClass societyClass, Gender preferablyGender)
        {
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio(preferablyGender)
                .BuildClass(societyClass)
                .BuildIdentity(true)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }
        public Character BuildSpecifiedPersonal(SceneType sceneType)
        {
            SocietyClass societyClass = SocietyClass.Servant;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    societyClass = SocietyClass.Homeless;
                    break;
                case SceneType.Street:
                    societyClass = _random.Next(0, 100) > 50 ? SocietyClass.Engineer : SocietyClass.Cabman;
                    break;
                case SceneType.CitizanHome:
                    societyClass = SocietyClass.Servant;
                    break;
                case SceneType.Clinic:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Medic : SocietyClass.Administator;
                    break;
                case SceneType.PublicHome:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Prostitute : SocietyClass.Administator;
                    break;
                case SceneType.Market:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Trader : SocietyClass.Administator;
                    break;
                case SceneType.Castle:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Servant : SocietyClass.Butler;
                    break;
                case SceneType.Bank:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Servant : SocietyClass.Administator;
                    break;
            }
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio()
                .BuildIdentity(true)
                .BuildClass(societyClass)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }        
        
        public Character BuildSpecifiedPersonal(SceneType sceneType, Gender preferablyGender)
        {
            SocietyClass societyClass = SocietyClass.Servant;

            switch (sceneType)
            {
                case SceneType.Undefined:
                    societyClass = SocietyClass.Homeless;
                    break;
                case SceneType.Street:
                    societyClass = _random.Next(0, 100) > 50 ? SocietyClass.Engineer : SocietyClass.Cabman;
                    break;
                case SceneType.CitizanHome:
                    societyClass = SocietyClass.Servant;
                    break;
                case SceneType.Clinic:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Medic : SocietyClass.Administator;
                    break;
                case SceneType.PublicHome:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Prostitute : SocietyClass.Administator;
                    break;
                case SceneType.Market:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Trader : SocietyClass.Administator;
                    break;
                case SceneType.Castle:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Servant : SocietyClass.Butler;
                    break;
                case SceneType.Bank:
                    societyClass = _random.Next(0, 100) > 10 ? SocietyClass.Servant : SocietyClass.Administator;
                    break;
            }
            _characterBuilder
                .BuildHuman(BasicSocietyKinds.Citizen)
                .BuildBio(preferablyGender)
                .BuildIdentity(true)
                .BuildClass(societyClass)
                .BuildRelationships(RelationshipBase.Normal)
                .BuildResources(societyClass)
                .BuildAbitilies();

            return _characterBuilder.Build();
        }
    }
}
