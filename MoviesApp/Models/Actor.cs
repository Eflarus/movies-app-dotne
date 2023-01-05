using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}