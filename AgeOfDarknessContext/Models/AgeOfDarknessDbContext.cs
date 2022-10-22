using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace AgeOfDarknessContext.Models
{
    /// <summary>
    /// <see cref="AgeOfDarknessDbContext"/> EntityFramework database context.
    /// </summary>
    public class AgeOfDarknessDbContext : DbContext
    {
        public AgeOfDarknessDbContext()
        {
        }

        public AgeOfDarknessDbContext(DbContextOptions<AgeOfDarknessDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CharacterAsset> CharacterAssets { get; set; }
        public virtual DbSet<KingdomAsset> KingdomAssets { get; set; }
        public virtual DbSet<TownAsset> TownAssets { get; set; }
        public virtual DbSet<StreetAsset> StreetAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*               File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "log.txt"), ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                               var conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                               optionsBuilder.UseSqlServer(conn);*/
                string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=AgeOfDarkness; Integrated Security=True; MultipleActiveResultSets=True; Application Name=EntityFramework";
                optionsBuilder.UseSqlServer(conn);
            }
        }
    }
}
