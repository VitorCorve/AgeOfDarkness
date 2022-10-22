using AgeOfDarknessEngine.Models.Characters;
using System.ComponentModel.DataAnnotations;

namespace AgeOfDarknessEngine.Models.Clan
{
    /// <summary>
    /// Community representation class. Provides information about <see cref="Leader"/>,
    /// <see cref="Name"/>, and <see cref="Members"/>.
    /// </summary>
    public class Community
    {
        [Key]
        public int CommunityId { get; set; }
        public int LeaderId { get; set; }
        public Character Leader { get; set; } = new Character();
        public string Name { get; set; } = string.Empty;
        public ICollection<Character> Members { get; set; } = new List<Character>();
    }
}
