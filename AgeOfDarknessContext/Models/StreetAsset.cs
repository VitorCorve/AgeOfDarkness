using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfDarknessContext.Models
{
    public class StreetAsset
    {
        [Key]
        public int StreetId { get; set; }
        public int TownId { get; set; }
        public int KingdomId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty("StreetAssets")]
        public virtual TownAsset TownAsset { get; set; }
    }
}
