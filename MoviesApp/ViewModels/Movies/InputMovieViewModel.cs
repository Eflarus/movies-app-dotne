using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels.Movies
{
    public class InputMovieViewModel
    {
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        public decimal Price { get; set; }
    }
}