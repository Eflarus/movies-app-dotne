using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}