using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels.Actors
{
    public class InputActorViewModel
    {
        [Required]
        [MinStringLength(4)]
        public string Name { get; set; }
        
        [Required]
        [MinStringLength(4)]
        public string Surname { get; set; }
        
        [Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
       
    }
}