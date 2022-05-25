using Application.Dto;
using AutoMapper;
using Domain.Entites;

namespace WebUI.PersonProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
