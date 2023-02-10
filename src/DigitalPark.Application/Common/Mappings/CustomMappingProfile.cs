using AutoMapper;
using DigitalPark.Application.Events.Queries.GetEvents;
using DigitalPark.Domain.Entities;

namespace DigitalPark.Application.Common.Mappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile()
    {
        CreateMap<Event, EventDto>()
            .ForMember(t => t.Id, expression => expression.MapFrom(p => p.Id))
            .ForMember(t => t.Date, expression => expression.MapFrom(p => p.Date))
            .ForMember(t => t.Title, expression => expression.MapFrom(p => p.TitleEng))
            .ForMember(t => t.Image, expression => expression.MapFrom(p => p.ImageEng))
            .ForMember(t => t.Location, expression => expression.MapFrom(p => p.Location.TitleEng));
    }
}