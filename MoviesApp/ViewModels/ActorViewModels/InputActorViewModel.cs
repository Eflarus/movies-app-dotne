using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels.ActorViewModels
{
    public class InputActorViewModel
    {
        [Required]
        [MinStringLength(4)]
        public string FirstName { get; set; }
        
        [Required]
        [MinStringLength(4)]
        public string LastName { get; set; }
        
        [Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
       
    }
}