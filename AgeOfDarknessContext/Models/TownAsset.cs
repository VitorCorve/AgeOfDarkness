using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfDarknessContext.Models
{
    public class TownAsset
    {
        public TownAsset()
        {
            StreetAssets = new HashSet<StreetAsset>();
        }
        [Key]
        public int TownId { get; set; }
        public int KingdomId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(KingdomId))]
        [InverseProperty("TownAssets")]
        public virtual KingdomAsset KingdomAsset { get; set; }

        [InverseProperty(nameof(StreetAsset.TownAsset))]
        public virtual ICollection<StreetAsset> StreetAssets { get; set; }
    }
}
