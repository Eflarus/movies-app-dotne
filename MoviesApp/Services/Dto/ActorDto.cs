using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Dto
{
    public class ActorDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }

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