using AgeOfDarknessContext.Models;
using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.Resources;

#pragma warning disable CS8605 // Распаковка-преобразование вероятного значения NULL.

namespace AgeOfDarknessEngine.Models.Gameplay.CharactersManagement
{
    /// <summary>
    /// Character builder, based on "Builder" pattern.
    /// </summary>
    public class CharacterBuilder : ICharacterBuilder
    {
        private Character _character;
        private readonly Random _random;
        public CharacterBuilder()
        {
            _character = new Character();
            _random = new Random();
        }

        public Character Build()
        {
            Character result = _character;
            _character = new Character();
            return result;
        }

        public ICharacterBuilder BuildHuman()
        {
            Human human = new();

            Array values = Enum.GetValues(typeof(BasicSocietyKinds));
            BasicSocietyKinds humanSocietyKind = (BasicSocietyKinds)values.GetValue(_random.Next(values.Length));

            human.CharacterKind = Kind.Human;
            human.SocietyKind = humanSocietyKind;
            human.TransformationStages = HumanToVampireTransformationStages.Healthly;

            _character = human;
            return this;
        }

        public ICharacterBuilder BuildHuman(BasicSocietyKinds societyKind)
        {
            Human human = new();
            human.CharacterKind = Kind.Human;
            human.SocietyKind = societyKind;
            human.TransformationStages = HumanToVampireTransformationStages.Healthly;

            _character = human;
            return this;
        }

        public ICharacterBuilder BuildHuman(BasicSocietyKinds societyKind, Community clan)
        {
            Human human = new();
            human.CharacterKind = Kind.Human;
            human.SocietyKind = societyKind;
            human.Clan = clan;

            _character = human;
            return this;
        }

        public ICharacterBuilder BuildBio()
        {
            using AgeOfDarknessDbContext context = new();
            int id = _random.Next(0, 1000);
            CharacterAsset asset = context.CharacterAssets.Where(x => x.ID == id).FirstOrDefault();

            if (asset is null)
            {
                BuildBio();
                return this;
            }

            else
            {
                _character.Name = asset.Name;
                _character.CharacterGender = asset.Gender == "Male" ? Gender.Male : Gender.Female;
                _character.BirthDate = asset.BirthDate;
                _character.CharacterStatement = CharacterStatements.Normal;
                _character.Alive = true;
            }

            return this;
        }       
        
        public ICharacterBuilder BuildBio(Gender preferablyGender)
        {
            bool applyPreferability = _random.Next(0, 100) > 99;

            using AgeOfDarknessDbContext context = new();
            int id = _random.Next(0, 1000);

            CharacterAsset asset;

            if (applyPreferability)
            {
                if (id > 990)
                    id = 0;

                List<CharacterAsset> assets = context.CharacterAssets.Skip(id).Take(10).ToList();
                asset = assets.FirstOrDefault(x => x.Gender.Equals(preferablyGender));
            }

            else
                asset = context.CharacterAssets.Where(x => x.ID == id).FirstOrDefault();

            if (asset is null)
            {
                BuildBio();
                return this;
            }

            else
            {
                _character.Name = asset.Name;
                _character.CharacterGender = asset.Gender == "Male" ? Gender.Male : Gender.Female;
                _character.BirthDate = asset.BirthDate;
                _character.CharacterStatement = CharacterStatements.Normal;
                _character.Alive = true;
            }

            return this;
        }

        public ICharacterBuilder BuildBio(string name, Gender gender)
        {
            _character.Name = name;
            _character.CharacterGender = gender;
            _character.BirthDate = "03.02.1211";
            _character.CharacterStatement = CharacterStatements.Normal;
            _character.Alive = true;

            return this;
        }

        public ICharacterBuilder BuildBio(string name, Gender gender, bool isPlayer)
        {
            _character.Name = name;
            _character.CharacterGender = gender;
            _character.BirthDate = "03.02.1211";
            _character.CharacterStatement = CharacterStatements.Normal;
            _character.Alive = true;
            _character.IsPlayer = isPlayer;

            return this;
        }

        public ICharacterBuilder BuildBio(string name, Gender gender, string birthDate)
        {
            _character.Name = name;
            _character.CharacterGender = gender;
            _character.BirthDate = birthDate;
            _character.CharacterStatement = CharacterStatements.Normal;
            _character.Alive = true;

            return this;
        }

        public ICharacterBuilder BuildBio(string name, Gender gender, string birthDate, bool isPlayer)
        {
            _character.Name = name;
            _character.CharacterGender = gender;
            _character.BirthDate = birthDate;
            _character.CharacterStatement = CharacterStatements.Normal;
            _character.Alive = true;
            _character.IsPlayer = isPlayer;

            return this;
        }

        public ICharacterBuilder BuildRelationships(RelationshipBase relationshipBase)
        {
            _character.RelationshipToPlayer = new Relationship
            {
                RelationShipKind = relationshipBase,
                Stage = RelationshipsStages.One
            };

            return this;
        }

        public ICharacterBuilder BuildClass()
        {
            Array values = Enum.GetValues(typeof(SocietyClass));
            SocietyClass societyClass = (SocietyClass)values.GetValue(_random.Next(values.Length));
            _character.Class = societyClass;
            return this;
        }

        public ICharacterBuilder BuildClass(SocietyClass societyClass)
        {
            _character.Class = societyClass;
            return this;
        }

        public ICharacterBuilder BuildCharacter(bool generateAbilities, bool generateResources)
        {
            return this;
        }

        public ICharacterBuilder BuildCharacter(ICollection<Ability> abilities)
        {
            _character.Abilities = (ICollection<CharacterAbilities>?)abilities;
            return this;
        }

        public ICharacterBuilder BuildCharacter(ICollection<Resource> resources)
        {
            _character.Resources = (ICollection<Resource>?)resources;
            return this;
        }

        public ICharacterBuilder BuildCharacter(ICollection<Ability> abilities, ICollection<Resource> resources)
        {
            _character.Abilities = (ICollection<CharacterAbilities>?)abilities;
            _character.Resources = (ICollection<Resource>?)resources;
            return this;
        }

        public ICharacterBuilder BuildVampire(Hunger hunger)
        {
            Vampire vampire = new();
            Glory glory = new();

            glory.VampireGloryStage = VampireGloryStages.One;
            glory.VampireGloryKind = VampireGloryBase.Unknown;

            Array vampireKindValues = Enum.GetValues(typeof(VampireKind));
            VampireKind vampireKind = (VampireKind)vampireKindValues.GetValue(_random.Next(vampireKindValues.Length));

            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = vampireKind;
            vampire.Wanted = false;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory)
        {
            Vampire vampire = new();

            Array vampireKindValues = Enum.GetValues(typeof(VampireKind));
            VampireKind vampireKind = (VampireKind)vampireKindValues.GetValue(_random.Next(vampireKindValues.Length));

            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = vampireKind;
            vampire.Wanted = false;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted)
        {
            Vampire vampire = new();

            Array vampireKindValues = Enum.GetValues(typeof(VampireKind));
            VampireKind vampireKind = (VampireKind)vampireKindValues.GetValue(_random.Next(vampireKindValues.Length));

            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = vampireKind;
            vampire.Wanted = wanted;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted, VampireKind kind)
        {
            Vampire vampire = new();
            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = kind;
            vampire.Wanted = wanted;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted, VampireKind kind, Community clan)
        {
            Vampire vampire = new();
            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = kind;
            vampire.Wanted = wanted;
            vampire.Clan = clan;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildVampire()
        {
            Vampire vampire = new();
            Glory glory = new();
            Hunger hunger = new();

            Array vampireKindValues = Enum.GetValues(typeof(VampireKind));
            Array vampireGloryStagesValues = Enum.GetValues(typeof(VampireGloryStages));
            Array vampireGloryKindValues = Enum.GetValues(typeof(VampireGloryBase));
            Array hungerStatusValues = Enum.GetValues(typeof(HungerBase));
            Array stageValues = Enum.GetValues(typeof(HungerStages));

            VampireKind vampireKind = (VampireKind)vampireKindValues.GetValue(_random.Next(vampireKindValues.Length));
            VampireGloryStages vampireGloryStage = (VampireGloryStages)vampireGloryStagesValues.GetValue(_random.Next(vampireGloryStagesValues.Length));
            VampireGloryBase vampireGloryKind = (VampireGloryBase)vampireGloryKindValues.GetValue(_random.Next(vampireGloryKindValues.Length));
            HungerBase hungerStatus = (HungerBase)hungerStatusValues.GetValue(_random.Next(hungerStatusValues.Length));
            HungerStages stage = (HungerStages)stageValues.GetValue(_random.Next(stageValues.Length));

            glory.VampireGloryStage = vampireGloryStage;
            glory.VampireGloryKind = vampireGloryKind;

            hunger.HungerStatus = hungerStatus;
            hunger.Stage = stage;

            vampire.CharacterKind = Kind.Vampire;
            vampire.HungerValue = hunger;
            vampire.VampireGlory = glory;
            vampire.Kind = vampireKind;
            vampire.Wanted = _random.Next(0 , 100) > 60;

            _character = vampire;

            return this;
        }

        public ICharacterBuilder BuildResources()
        {
            _character.Resources = new List<Resource>();

            int cycle = 0;

            while (cycle < 4)
            {
                bool generateResource = _random.Next(0, 100) > 50;

                if (generateResource)
                {
                    int value = _random.Next(1, 1000);

                    switch (cycle)
                    {

                        case 0:
                            _character.Resources.Add(new Money(value));
                            break;
                        case 1:
                            _character.Resources.Add(new BuildingResource(value));
                            break;
                        case 2:
                            _character.Resources.Add(new LiveResources(value));
                            break;
                        case 3:
                            _character.Resources.Add(new WarResource(value));
                            break;
                    }
                }

                cycle++;
            }

            return this;
        }

        public ICharacterBuilder BuildResources(SocietyClass societyClass)
        {
            _character.Resources = new List<Resource>();

            int cycle = 0;

            while (cycle < 4)
            {
                bool generateResource = _random.Next(0, 100) > 50;

                if (generateResource)
                {
                    int value = 0;

                    switch (societyClass)
                    {
                        case SocietyClass.Homeless:
                            value = _random.Next(1, 15);
                            break;
                        case SocietyClass.Medic:
                            value = _random.Next(1, 300);
                            break;
                        case SocietyClass.Soldier:
                            value = _random.Next(1, 100);
                            break;
                        case SocietyClass.Politic:
                            value = _random.Next(1, 1200);
                            break;
                        case SocietyClass.Barmen:
                            value = _random.Next(1, 400);
                            break;
                        case SocietyClass.Trader:
                            value = _random.Next(1, 600);
                            break;
                        case SocietyClass.Unemployed:
                            value = _random.Next(1, 70);
                            break;
                        case SocietyClass.Police:
                            value = _random.Next(1, 350);
                            break;
                        case SocietyClass.VampireHunter:
                            value = _random.Next(1, 250);
                            break;
                        case SocietyClass.Musician:
                            value = _random.Next(1, 170);
                            break;
                        case SocietyClass.Poet:
                            value = _random.Next(1, 90);
                            break;
                        case SocietyClass.Actor:
                            value = _random.Next(1, 2000);
                            break;
                        case SocietyClass.Artist:
                            value = _random.Next(1, 300);
                            break;
                        case SocietyClass.Prostitute:
                            value = _random.Next(1, 500);
                            break;
                        case SocietyClass.Financist:
                            value = _random.Next(1, 1600);
                            break;
                        case SocietyClass.Engineer:
                            value = _random.Next(1, 450);
                            break;
                        case SocietyClass.Servant:
                            value = _random.Next(1, 220);
                            break;
                        case SocietyClass.Priest:
                            value = _random.Next(1, 900);
                            break;
                        case SocietyClass.Prophet:
                            value = _random.Next(1, 666);
                            break;
                        case SocietyClass.Bandit:
                            value = _random.Next(1, 900);
                            break;
                        case SocietyClass.Tailor:
                            value = _random.Next(1, 320);
                            break;
                        case SocietyClass.Blacksmith:
                            value = _random.Next(1, 750);
                            break;
                        case SocietyClass.Cabman:
                            value = _random.Next(1, 300);
                            break;
                        case SocietyClass.Builder:
                            value = _random.Next(1, 600);
                            break;
                    }

                    switch (cycle)
                    {
                        case 0:
                            _character.Resources.Add(new Money(value));
                            break;
                        case 1:
                            _character.Resources.Add(new BuildingResource(value));
                            break;
                        case 2:
                            _character.Resources.Add(new LiveResources(value));
                            break;
                        case 3:
                            _character.Resources.Add(new WarResource(value));
                            break;
                    }
                }
                cycle++;
            }
            return this;
        }

        public ICharacterBuilder BuildResources(ICollection<Resource> resources)
        {
            _character.Resources = resources;
            return this;
        }

        public ICharacterBuilder BuildAbitilies()
        {
            _character.Abilities = new List<CharacterAbilities>();
            return this;
        }

        public ICharacterBuilder BuildAbitilies(ICollection<CharacterAbilities> abilities)
        {
            _character.Abilities = abilities;
            return this;
        }

        public ICharacterBuilder BuildIdentity()
        {
            _character.IdentityHidden = _random.Next(0, 100) > 50;
            return this;
        }

        public ICharacterBuilder BuildIdentity(bool hideIdentity)
        {
            _character.IdentityHidden = hideIdentity;
            return this;
        }
    }
}
