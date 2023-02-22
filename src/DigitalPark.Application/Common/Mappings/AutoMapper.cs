using AutoMapper;
using DigitalPark.Application.Common.Interfaces;

namespace DigitalPark.Application.Common.Mappings;

public class AutoMapper
{
    private readonly ILanguageProvider _languageProvider;

    public AutoMapper(ILanguageProvider languageProvider)
    {
        _languageProvider = languageProvider;
    }
    
    private static readonly Lazy<IMapper> Lazy = new(() => {
        var config = new MapperConfiguration(cfg => {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<CustomMappingProfile>(_languageProvider);
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
    public static IMapper Mapper => Lazy.Value;
}