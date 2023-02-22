using AutoMapper;
using DigitalPark.Application.Common.Extensions;
using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Application.Events.Queries.GetEvents;
using DigitalPark.Domain.Entities;

namespace DigitalPark.Application.Common.Mappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile(ILanguageProvider languageProvider)
    {
        CreateMap<Event, EventDto>()
            .ForMember(t => t.Id, expression => expression.MapFrom(p => p.Id))
            .ForMember(t => t.Date, expression => expression.MapFrom(p => p.Date))
            .ForMember(t => t.Title, expression =>
            {
                expression.PreCondition(p => p.Translations.Where(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Any());
                expression.MapFrom(p => p.Translations.First(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Title);
            })
            .ForMember(t => t.Description, expression =>
            {
                expression.PreCondition(p => p.Translations.Where(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Any());
                expression.MapFrom(p => p.Translations.First(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Description);
            })
            .ForMember(t => t.Image, expression =>
            {
                expression.PreCondition(p => p.Translations.Where(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Any());
                expression.MapFrom(p => p.Translations.First(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Image);
            })
            .ForMember(t => t.Location, expression =>
            {
                expression.PreCondition(p => p.Translations.Where(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Any());
                expression.MapFrom(p => p.Location.Translations.First(t => t.LanguageCode == languageProvider.Language.ToStringCode()).Title);
            });

        /*CreateMap<Event, EventDto>()
            .ForMember(t => t.Id, expression => expression.MapFrom(p => p.Id))
            .ForMember(t => t.Date, expression => expression.MapFrom(p => p.Date))
            .ForMember(t => t.Title, expression => expression.MapFrom(p => p.TitleEng))
            .ForMember(t => t.Image, expression => expression.MapFrom(p => p.ImageEng))
            .ForMember(t => t.Location, expression => expression.MapFrom(p => p.Location.TitleEng));*/
    }
}