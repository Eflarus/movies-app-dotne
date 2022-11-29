using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels.Actors
{
    public class InputActorViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        [Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
       
    }
}