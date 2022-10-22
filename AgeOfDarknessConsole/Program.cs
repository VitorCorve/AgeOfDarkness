using AgeOfDarknessContext.Models;
using AgeOfDarknessEngine.Models.Characters;
using AgeOfDarknessEngine.Models.Enums;
using AgeOfDarknessEngine.Models.Gameplay.CharactersManagement;
using AgeOfDarknessEngine.Models.Gameplay.RefugeManagement;
using AgeOfDarknessEngine.Models.Scene;

CharacterDirector director = new CharacterDirector();

Character player = director.BuildPlayableCharacter("Arthur Morgan", Gender.Male, SocietyClass.Engineer);

LocationDirector locationDirector = new LocationDirector();

Location publicHome = locationDirector.BuildPublicHome(SceneTypeComplicationLevel.Three);
Location clinic = locationDirector.BuildClinic(SceneTypeComplicationLevel.Three);
Location citizanHome = locationDirector.BuildCitizanHome(SceneTypeComplicationLevel.Three);
Location market = locationDirector.BuildMarket(SceneTypeComplicationLevel.Three);
Location castle = locationDirector.BuildCastle(SceneTypeComplicationLevel.Three);
Location street = locationDirector.BuildStreet(SceneTypeComplicationLevel.Three);


while (true)
{

}

void GenerateCharacterAssets()
{
    string[] file = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "data.txt"));

    List<CharacterAssetsMiddleClass> middleClasses = new List<CharacterAssetsMiddleClass>();


    for (int i = 0; i < file.Length; i++)
    {
        CharacterAssetsMiddleClass middleClass = new CharacterAssetsMiddleClass();
        string[] data = file[i].Split(";");
        middleClass.Name = data[0];
        middleClass.LastName = data[1];
        middleClass.Gender = data[2] == "M" ? "Male" : "Female";

        middleClasses.Add(middleClass);
    }

    using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
    {
        Random random = new Random();
        foreach (var middleClass in middleClasses)
        {
            int birthDay = random.Next(0, 30);
            int birthMonth = random.Next(1, 12);
            int birthYear = random.Next(1110, 1205);

            CharacterAsset asset = new CharacterAsset();

            asset.Name = middleClass.Name + " " + middleClass.LastName;
            asset.Gender = middleClass.Gender;
            asset.BirthDate = $"{birthDay}.{birthMonth}.{birthYear}";

            context.CharacterAssets.Add(asset);
        }

        context.SaveChanges();
    }
}

void GenerateKingdoms()
{
    string[] data = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "kingdoms.txt"));

    Random random = new Random();

    using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
    {
        List<KingdomAsset> kingdomAssets = new List<KingdomAsset>();
        for (int i = 0; i < data.Length; i++)
        {
            int lordId = random.Next(1, 36000);
            CharacterAsset characterAsset = context.CharacterAssets.Where(x => x.ID.Equals(lordId)).FirstOrDefault();

            KingdomAsset kingdomAsset = new KingdomAsset
            {
                LordId = characterAsset.ID,
                Name = data[i],
            };

            kingdomAssets.Add(kingdomAsset);
        }

        context.KingdomAssets.AddRange(kingdomAssets);
        context.SaveChanges();
    }
}

void GenerateTowns()
{
    string[] data = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "towns.txt"));

    Random random = new Random();

    using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
    {
        List<TownAsset> townAssets = new List<TownAsset>();

        for (int i = 0; i < data.Length; i++)
        {
            int kingdomId = random.Next(1, context.KingdomAssets.Count()+ 1);
            TownAsset townAsset = new TownAsset
            {
                KingdomId = kingdomId,
                Name = data[i],
            };

            townAssets.Add(townAsset);
        }

        int withId1 = townAssets.Where(x => x.KingdomId == 1).Count();
        int withId2 = townAssets.Where(x => x.KingdomId == 2).Count();
        int withId3 = townAssets.Where(x => x.KingdomId == 3).Count();
        int withId4 = townAssets.Where(x => x.KingdomId == 4).Count();
        int withId5 = townAssets.Where(x => x.KingdomId == 5).Count();
        int withId6 = townAssets.Where(x => x.KingdomId == 6).Count();
        int withId7 = townAssets.Where(x => x.KingdomId == 7).Count();

        int total = withId1 + withId2 + withId3 + withId4 + withId5 + withId6 + withId7;

        context.TownAssets.AddRange(townAssets);

        context.SaveChanges();
    }
}

void GenerateStreets()
{
    string[] data = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "streets.txt"));

    Random random = new Random();

    using (AgeOfDarknessDbContext context = new AgeOfDarknessDbContext())
    {
        List<StreetAsset> streetAssets = new List<StreetAsset>();

        for (int i = 0; i < data.Length; i++)
        {
            int townId = random.Next(1, context.TownAssets.Count() + 1);

            bool generatePrefix = random.Next(0, 100) > 20;
            
            TownAsset townAsset = context.TownAssets.Find(townId);

            StreetAsset streetAsset = new StreetAsset
            {
                KingdomId = townAsset.KingdomId,
                Name = generatePrefix ? $"{data[i]} {GenerateRefix(random)}" : data[i],
                TownId = townAsset.TownId
            };

            streetAssets.Add(streetAsset);
        }

        context.StreetAssets.AddRange(streetAssets);

        context.SaveChanges();
    }
}
string GenerateRefix(Random rand)
{
    List<string> variants = new List<string>();
    variants.Add("str.");
    variants.Add("Blvd");
    variants.Add("Square");
    variants.Add("Lave");
    variants.Add("Ave");

    return variants[rand.Next(0, variants.Count)];
}
class CharacterAssetsMiddleClass
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
}
