using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WasagaRFC.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        [DisplayName("Player Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Position")]
        public string Position { get; set; }

        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        // Navigation property referencing the Starters model
        public ICollection<Starters>? Starters { get; set; }
    }
}
