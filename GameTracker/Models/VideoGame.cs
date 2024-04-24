using System;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Model
{
    public class VideoGame
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Genre")]
        public string Genre { get; set; }
    }
}