using MoviesApp.Services.Dto;
using AutoMapper;
using MoviesApp.ViewModels.ActorViewModels;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class ActorViewModelsProfile: Profile
    {
        public ActorViewModelsProfile()
        {
             CreateMap<ActorDto, InputActorViewModel>().ReverseMap();
             CreateMap<ActorDto, DeleteActorViewModel>();
             CreateMap<ActorDto, EditActorViewModel>().ReverseMap();
             CreateMap<ActorDto, ActorViewModel>();
        }
    }
}