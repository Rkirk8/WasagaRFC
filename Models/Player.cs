using System.ComponentModel.DataAnnotations;

namespace WasagaRFC.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public int age { get; set; }

        // navigation property referencing the Starters model
        public ICollection<Starters> Starters { get; set; }
    }
}