using MoviesApp.Models;
using AutoMapper;
using MoviesApp.ViewModels.Actors;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class ActorProfile: Profile
    {
        public ActorProfile()
        {
             CreateMap<Actor, InputActorViewModel>().ReverseMap();
             CreateMap<Actor, DeleteActorViewModel>();
             CreateMap<Actor, EditActorViewModel>().ReverseMap();
             CreateMap<Actor, ActorViewModel>();
        }
    }
}