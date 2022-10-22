using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfDarknessContext.Models
{
    /// <summary>
    /// Database <see cref="KingdomAsset"/> model.
    /// </summary>
    public class KingdomAsset
    {
        public KingdomAsset()
        {
            TownAssets = new HashSet<TownAsset>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int LordId { get; set; }

        [InverseProperty(nameof(TownAsset.KingdomAsset))]
        public virtual ICollection<TownAsset> TownAssets { get; set; }

    }
}
