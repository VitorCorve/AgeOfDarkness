using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Clan;
using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.Abilities;
using AgeOfDarknessEngine.Models.Gameplay.Resources;

namespace AgeOfDarknessEngine.Models.Gameplay.CharactersManagement
{
    /// <summary>
    /// Character builder interface, based on "Builder" pattern.
    /// </summary>
    public interface ICharacterBuilder
    {
        /// <summary>
        /// Build fully randomized <see cref="Vampire"/>-type <see cref="Character"/>.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire();

        /// <summary>
        /// Build randomized <see cref="Vampire"/>-type <see cref="Character"/> with default <see cref="VampireGloryBase"/>, <see cref="VampireGloryStages"/>
        /// and randomized <see cref="VampireKind"/> values, and also specified <see cref="Hunger"/> value.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire(Hunger hunger);

        /// <summary>
        /// Build randomized <see cref="Vampire"/>-type <see cref="Character"/> with default <see cref="VampireGloryBase"/>, <see cref="VampireGloryStages"/>
        /// and randomized <see cref="VampireKind"/> values, and also specified <see cref="Hunger"/> and <see cref="Glory"/> value.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory);

        /// <summary>
        /// Build <see cref="Vampire"/>-type <see cref="Character"/> with default <see cref="VampireGloryBase"/>, <see cref="VampireGloryStages"/>
        /// and randomized <see cref="VampireKind"/> values, and also specified <see cref="Hunger"/>, <see cref="Glory"/> and <paramref name="wanted"/> value.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted);

        /// <summary>
        /// Build <see cref="Vampire"/>-type <see cref="Character"/> with default <see cref="VampireGloryBase"/>, <see cref="VampireGloryStages"/>
        /// and specified <see cref="Hunger"/>, <see cref="Glory"/>, <paramref name="wanted"/> and <see cref="VampireKind"/> value.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted, VampireKind kind);

        /// <summary>
        /// Build <see cref="Vampire"/>-type <see cref="Character"/> with default <see cref="VampireGloryBase"/>, <see cref="VampireGloryStages"/>
        /// and specified <see cref="Hunger"/>, <see cref="Glory"/>, <paramref name="wanted"/>, <see cref="Community"/> and <see cref="VampireKind"/> value.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildVampire(Hunger hunger, Glory glory, bool wanted, VampireKind kind, Community clan);

        /// <summary>
        /// Build randomized Build randomized <see cref="Human"/>-type <see cref="Character"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildHuman();

        /// <summary>
        /// Build randomized <see cref="Human"/>-type <see cref="Character"/>  with specified <see cref="BasicSocietyKinds"/> <paramref name="societyKind"/>.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildHuman(BasicSocietyKinds societyKind);

        /// <summary>
        /// Build randomized <see cref="Human"/>-type <see cref="Character"/> with specified <see cref="BasicSocietyKinds"/> <paramref name="societyKind"/>
        /// and specified <see cref="Community"/> <paramref name="clan"/>.
        /// </summary>
        /// <param name="societyKind"></param>
        /// <param name="clan"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildHuman(BasicSocietyKinds societyKind, Community clan);

        /// <summary>
        /// Build randomized character <see cref="Bio"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildBio();
        /// <summary>
        /// Build randomized character with preferably gender <see cref="Bio"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildBio(Gender preferablyGender);

        /// <summary>
        /// Build concret character <see cref="Bio"/> with specified <paramref name="name"/> and <paramref name="gender"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildBio(string name, Gender gender);
        /// <summary>
        /// Build concret character <see cref="Bio"/> with specified <paramref name="name"/>, <paramref name="birthDate"/> and <paramref name="gender"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildBio(string name, Gender gender, string birthDate);

        /// <summary>
        /// Build concret character <see cref="Bio"/> with specified <paramref name="name"/>, <paramref name="gender"/> and especial parameter <paramref name="isPlayer"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildBio(string name, Gender gender, bool isPlayer);
        /// <summary>
        /// Build concret character <see cref="Bio"/> with specified <paramref name="name"/>, <paramref name="gender"/>, <paramref name="birthDate"/> and especial parameter <paramref name="isPlayer"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildBio(string name, Gender gender, string birthDate, bool isPlayer);

        /// <summary>
        /// Build ranzomly-generacter character <see cref="SocietyClass"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildClass();

        /// <summary>
        /// Build character with randomly-generated <see cref="ICollection{T}"/><see cref="Ability"/> and <see cref="ICollection{T}"/><see cref="Resource"/>.
        /// </summary>
        /// <param name="generateAbilities"></param>
        /// <param name="generateResources"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildCharacter(bool generateAbilities, bool generateResources);

        /// <summary>
        /// Build character <see cref="ICollection{T}"/><see cref="Ability"/> with specified parameter <paramref name="abilities"/>.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildCharacter(ICollection<Ability> abilities);

        /// <summary>
        /// Build character <see cref="ICollection{T}"/><see cref="Resource"/> with specified parameter <paramref name="resources"/>.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildCharacter(ICollection<Resource> resources);

        /// <summary>
        /// Build character <see cref="ICollection{T}"/><see cref="Ability"/> and <see cref="ICollection{T}"/><see cref="Resource"/> 
        /// with specified parameters <paramref name="resources"/> and <paramref name="abilities"/>.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildCharacter(ICollection<Ability> abilities, ICollection<Resource> resources);

        /// <summary>
        /// Build character <see cref="SocietyClass"/> with specified parameter <paramref name="societyClass"/>.
        /// </summary>
        /// <param name="societyClass"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildClass(SocietyClass societyClass);

        /// <summary>
        /// Build character <see cref="Relationship"/>.
        /// </summary>
        /// <param name="relationshipBase"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildRelationships(RelationshipBase relationshipBase);

        /// <summary>
        /// Build randomized <see cref="ICollection{T}"/><see cref="Resource"/> resources.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildResources();

        /// <summary>
        /// Build randomized <see cref="ICollection{T}"/><see cref="Resource"/> resources based on <see cref="SocietyClass"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildResources(SocietyClass societyClass);

        /// <summary>
        /// Build specified <see cref="ICollection{T}"/><see cref="Resource"/> <paramref name="resources"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildResources(ICollection<Resource> resources);

        /// <summary>
        /// Build randomized <see cref="ICollection{T}"/><see cref="CharacterAbilities"/>.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildAbitilies();

        /// <summary>
        /// Build specified <see cref="ICollection{T}"/><see cref="CharacterAbilities"/> <paramref name="abilities"/>.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        public ICharacterBuilder BuildAbitilies(ICollection<CharacterAbilities> abilities);

        /// <summary>
        /// Build randomized character identity value. Identity identifies character as known or unknown.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildIdentity();

        /// <summary>
        /// Build specified character identity by <paramref name="hiddenIdentity"/> value. Identity identifies character as known or unknown.
        /// </summary>
        /// <returns></returns>
        public ICharacterBuilder BuildIdentity(bool hiddenIdentity);

        /// <summary>
        /// Returns builded <see cref="Character"/>.
        /// </summary>
        /// <returns><see cref="Character"/></returns>
        public Character Build();
    }
}
