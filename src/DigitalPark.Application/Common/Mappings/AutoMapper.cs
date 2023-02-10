using AutoMapper;

namespace DigitalPark.Application.Common.Mappings;

public class AutoMapper
{
    private static readonly Lazy<IMapper> Lazy = new(() => {
        var config = new MapperConfiguration(cfg => {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<CustomMappingProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
    public static IMapper Mapper => Lazy.Value;
}