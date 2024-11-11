using System.ComponentModel.DataAnnotations;

namespace WasagaRFC.Models
{
    public class Starters
    {
        public int StarterId { get; set; }

        [Required]
        public string Prop1 { get; set; }

        [Required]
        public string Prop2 { get; set; }

        [Required]
        public string Hooker { get; set; }

        [Required]
        public string Lock1 { get; set; }

        [Required]
        public string Lock2 { get; set; }

        [Required]
        public string Flanker1 { get; set; }

        [Required]
        public string Flanker2 { get; set; }

        [Required]
        public string Number8 { get; set; }

        [Required]
        public string ScrumHalf { get; set; }

        [Required]
        public string FlyHalf { get; set; }

        [Required]
        public string Center1 { get; set; }

        [Required]
        public string Center2 { get; set; }

        [Required]
        public string Wing1 { get; set; }

        [Required]
        public string Wing2 { get; set; }

        [Required]
        public string FullBack { get; set; }

        // foreign key property referencing the Player model
        public int PlayerId { get; set; }

        [Display(Name = "Player")]
        public Player? Player { get; set; }
    }
}